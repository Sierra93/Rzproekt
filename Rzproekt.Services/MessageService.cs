using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
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

                // Проверяет есть ли такой хэш.
                bool isHash = await IdentityAnonymousHash(messageDto.UserCode);

                if (!isHash) {
                    // Пользователь новый, значит создать новый диалог вернув его Id.
                    MainInfoDialog oNewDialog = await CreateDialog();

                    // Записывает сообщение.
                     bool sStatusAd = await AddMessage(messageDto.MessageText, oNewDialog.DialogId, messageDto.IsAdmin);

                    var oMessages = await _db.DialogMessages.Where(d => d.DialogId == oNewDialog.DialogId).ToListAsync();

                    // Добавляет участника диалога.
                    await AddDialogMember(messageDto.UserCode);

                    var resultNewObj = new {
                        aDialogs = oNewDialog,
                        aMessages = oMessages,
                        userCode = messageDto.UserCode,
                        isAdmin = sStatusAd
                    };

                    return resultNewObj;
                }

                // Пользователь не новый, значит найти участника диалога.
                DialogMember oMember = await SearchMember(messageDto.UserCode);

                // if (oMember != null) {
                // Находит существующий диалог по его Id.
                MainInfoDialog mainInfoDialog = await SearchDialog(oMember.DialogId);

                int oOldDialogId = await _db.DialogMembers.Where(m => m.UserId.Equals(messageDto.UserCode)).Select(d => d.DialogId).FirstOrDefaultAsync();

                 // Записывает сообщение.
                  bool sStatus = await AddMessage(messageDto.MessageText, oOldDialogId, messageDto.IsAdmin);

                // Находит сообщения диалога.
                var dialogMessage = await SearchDialogMessages(mainInfoDialog.DialogId);

                var resultOldObj = new {
                    aDialogs = mainInfoDialog,
                    aMessages = dialogMessage,
                    userCode = messageDto.UserCode,
                    isAdmin = sStatus
                }; 

                return resultOldObj;
                //}                            
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
        async Task AddDialogMember(string userId) {
            DialogMember dialogMember = new DialogMember() {
                UserId = userId,
                Joined = DateTime.Now
            };

            await _db.DialogMembers.AddAsync(dialogMember);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Метод находит участника диалога.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        async Task<DialogMember> SearchMember(string userId) {
            DialogMember oMember = await _db.DialogMembers.Where(m => m.UserId.Equals(userId)).FirstOrDefaultAsync();

            if (oMember == null) {
                throw new ArgumentNullException("Участника диалога не найдено");
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
    }
}
