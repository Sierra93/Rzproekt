using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы сообщений.
    /// </summary>
    public class MessageService : MessageBase {
        ApplicationDbContext _db;

        public MessageService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод реализует отправку сообщений.
        /// </summary>
        /// <param name="messageDto"></param>
        /// <returns></returns>
        public async override Task<object> Send(MessageDto messageDto) {
            try {
                if (string.IsNullOrEmpty(messageDto.UserCode) || string.IsNullOrEmpty(messageDto.MessageText)) {
                    throw new ArgumentNullException();
                }
                bool bAdmin = Convert.ToBoolean(messageDto.IsAdmin);

                // Проверяет есть ли такой хэш.
                bool isHash = await IdentityAnonymousHash(messageDto.UserCode);

                if (!isHash && !bAdmin) {
                    // Пользователь новый, значит создать новый диалог вернув его Id.
                    MainInfoDialog oNewDialog = await CreateDialog();

                    // Записывает сообщение.
                    bool sStatusAd = await AddMessage(messageDto.MessageText, oNewDialog.DialogId, messageDto.UserCode);

                    var oMessages = await _db.DialogMessages.Where(d => d.DialogId == oNewDialog.DialogId).ToListAsync();

                    // Добавляет участника диалога.
                    await AddDialogMember(messageDto.UserCode, oNewDialog.DialogId, messageDto.IsAdmin);

                    var resultNewObj = new {
                        aDialogs = oNewDialog,
                        aMessages = oMessages,
                        userCode = messageDto.UserCode,
                        isAdmin = sStatusAd
                    };

                    return resultNewObj;
                }

                // Если пишет админ, значит добавить его к диалогу, который открыт.
                if (bAdmin) {
                    await AddDialogAdmin(messageDto);                                      
                }

                // Пользователь не новый, значит найти участника диалога.
                DialogMember oMember = await SearchMember(messageDto.UserCode, messageDto.IsAdmin, messageDto.AdminDialogId);

                // Находит существующий диалог по его Id.
                MainInfoDialog mainInfoDialog = await SearchDialog(oMember.DialogId);

                int oldDialogId = !bAdmin ? await _db.DialogMembers.Where(m => m.UserId.Equals(messageDto.UserCode)).Select(d => d.DialogId).FirstOrDefaultAsync() : messageDto.AdminDialogId;

                // Записывает сообщение.
                bool sStatus = await AddMessage(messageDto.MessageText, oldDialogId, messageDto.UserCode);

                // Находит сообщения диалога.
                var dialogMessage = await SearchDialogMessages(mainInfoDialog.DialogId);

                var resultOldObj = new {
                    aDialogs = mainInfoDialog,
                    aMessages = dialogMessage,
                    userCode = messageDto.UserCode,
                    isAdmin = sStatus
                };

                return resultOldObj;
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Не переданы обязательный параметры", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод проверяет есть ли такой хэш в БД.
        /// </summary>
        /// <param name="anonymousUserDto"></param>
        /// <returns></returns>
        async Task<bool> IdentityAnonymousHash(string userHash) {
            AnonymousUserDto oUser = await _db.AnonymousUsers.Where(u => u.UserId.Equals(userHash)).FirstOrDefaultAsync();
            AnonymousUserDto anonymousUserDto = new AnonymousUserDto();

            if (oUser != null) {
                return true;
            }

            anonymousUserDto.UserId = userHash;
            await _db.AnonymousUsers.AddAsync(anonymousUserDto);
            await _db.SaveChangesAsync();

            return false;
        }

        /// <summary>
        /// Метод создает новый диалог.
        /// </summary>
        /// <returns></returns>
        async Task<MainInfoDialog> CreateDialog() {
            MainInfoDialog mainInfo = new MainInfoDialog() {
                DialogName = default,
                Created = DateTime.Now
            };

            // Создает новый диалог.
            await _db.MainInfoDialogs.AddAsync(mainInfo);
            await _db.SaveChangesAsync();

            return await _db.MainInfoDialogs.OrderByDescending(o => o.DialogId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Метод добавляет сообщение в таблицу сообщений.
        /// </summary>
        /// <returns></returns>
        async Task<bool> AddMessage(string message, int dialogId, string isAdmin) {
            bool bAdmin = isAdmin.Contains("admin");
            bool bStatus = false;

            if (bAdmin) {
                bStatus = true;
            }

            DialogMessage dialogMessage = new DialogMessage() {
                DialogId = dialogId,
                Message = message,
                Created = DateTime.Now,
                isAdmin = bStatus.ToString()
            };


            await _db.DialogMessages.AddAsync(dialogMessage);
            await _db.SaveChangesAsync();

            return bStatus;
        }

        /// <summary>
        /// Метод добавляет участника диалога.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        async Task AddDialogMember(string userId, int dialogId, string isAdmin) {
            DialogMember dialogMember = new DialogMember() {
                UserId = userId,
                Joined = DateTime.Now
            };
            bool bAdmin = Convert.ToBoolean(isAdmin);

            if (bAdmin) {
                DialogMember dialogAdminMember = new DialogMember() {
                    UserId = "admin",
                    DialogId = dialogId,
                    Joined = DateTime.Now
                };

                await _db.DialogMembers.AddAsync(dialogAdminMember);
                await _db.SaveChangesAsync();
            }

            if (!bAdmin) {
                await _db.DialogMembers.AddAsync(dialogMember);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Метод находит участника диалога.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        async Task<DialogMember> SearchMember(string userId, string isAdmin, int dialogId) {
            DialogMember oMember = await _db.DialogMembers.Where(m => m.UserId.Equals(userId)).FirstOrDefaultAsync();
            bool bAdmin = Convert.ToBoolean(isAdmin);

            if (oMember == null && !bAdmin) {
                throw new ArgumentNullException("Участника диалога не найдено");
            }

            if (bAdmin) {
                DialogMember dialogMember = new DialogMember() {
                    UserId = userId,
                    DialogId = dialogId,
                    Joined = DateTime.Now
                };

                await _db.DialogMembers.AddAsync(dialogMember);
                await _db.SaveChangesAsync();

                return dialogMember;
            }

            return oMember;
        }

        /// <summary>
        /// Метод находит существующий диалог по его Id.
        /// </summary>
        /// <returns></returns>
        async Task<MainInfoDialog> SearchDialog(int dialogId) {
            return await _db.MainInfoDialogs.Where(d => d.DialogId == dialogId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Метод находит сообщения диалога.
        /// </summary>
        /// <returns></returns>
        async Task<IList<DialogMessage>> SearchDialogMessages(int dialogId) {
            return await _db.DialogMessages.Where(d => d.DialogId == dialogId).ToListAsync();
        }

        /// <summary>
        /// Метод получает список всех диалогов.
        /// </summary>
        /// <returns></returns>
        public async override Task<IList> GetDialogs() {
            return await _db.MainInfoDialogs.ToListAsync();
        }

        /// <summary>
        /// Метод получает сообщений диалога по его Id.
        /// </summary>
        public async override Task<IList<DialogMessage>> GetDialogMessages(int dialogId) {
            try {
                if (dialogId == 0) {
                    throw new ArgumentNullException();
                }

                return await _db.DialogMessages.Where(d => d.DialogId == dialogId).ToListAsync();
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Id диалога не передан", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод удаляет диалог по его Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async override Task RemoveDialog(int id) {
            try {
                if (id == 0) {
                    throw new ArgumentNullException();
                }

                // Получает диалог, который нужно удалить.
                MainInfoDialog oDialog = await _db.MainInfoDialogs.Where(d => d.DialogId == id).FirstOrDefaultAsync();

                // Получает сообщения диалога, которые нужно удалить.
                IList<DialogMessage> ADialogMessages = await _db.DialogMessages.Where(m => m.DialogId == id).ToListAsync();

                IList<DialogMember> oDialogMembers = await _db.DialogMembers.Where(d => d.DialogId == id).ToListAsync();

                _db.RemoveRange(oDialog, ADialogMessages, oDialogMembers);
                await _db.SaveChangesAsync();
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Id диалога не передан", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод добавляет админа к диалогу, который открыт в админке.
        /// </summary>
        /// <param name="messageDto"></param>
        /// <returns></returns>
        async Task AddDialogAdmin(MessageDto messageDto) {
            DialogMember dialog = await _db.DialogMembers.Where(d => d.DialogId == messageDto.AdminDialogId).FirstOrDefaultAsync();

            if (dialog == null) {
                DialogMember dialogMember = new DialogMember() {
                    DialogId = messageDto.AdminDialogId,
                    UserId = messageDto.UserCode,
                    Joined = DateTime.Now
                };

                await _db.DialogMembers.AddAsync(dialogMember);
                await _db.SaveChangesAsync();
            }
        }
    }
}
