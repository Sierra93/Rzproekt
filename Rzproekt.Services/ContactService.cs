using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы работы с контактами.
    /// </summary>
    public class ContactService : ContactBase {
        ApplicationDbContext _db;

        public ContactService(ApplicationDbContext db) => _db = db;
       
        /// <summary>
        /// Метод получает контактную информацию.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetContactsCompany() {
            return await _db.ContactsCompany.ToListAsync();
        }

        /// <summary>
        /// Метод получает контактную информацию.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetContactsLeads() {
            return await _db.ContactLeads.ToListAsync();
        }

        /// <summary>
        /// Метод добавляет контакты.
        /// </summary>
        /// <param name="filesCert"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public async override Task AddContactCompany(ContactCompanyDto contactCompanyDto) {
            try {
                ContactCompanyDto oOldCompany = await _db.ContactsCompany.FirstOrDefaultAsync();
                _db.ContactsCompany.Remove(oOldCompany);

                contactCompanyDto.Block = BlockType.CONTACT_COMPANY;
                contactCompanyDto.ButtonText = ButtonType.BTN_DETAIL;
                _db.ContactsCompany.Add(contactCompanyDto);
                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод удаляет контакт.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task RemoveContact(int id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод изменяет контакты.
        /// </summary>
        /// <param name="filesCert"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public override Task ChangeContact(IFormCollection filesCert, ContactCompanyDto contactDto) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод находит руководителя.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> SearchLead(string name) {
            try {
                if (string.IsNullOrEmpty(name)) {
                    throw new ArgumentNullException();
                }

                var oLead = await _db.ContactLeads.Where(c => c.LeadName.ToLower().Contains(name.ToLower())).Select(c => new { c.LeadId, c.LeadName }).ToListAsync();

                return oLead;
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Не передан текст поиска", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async override Task ChangeContactLead(IFormCollection filesClient, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                ContactLeadDto newLead = JsonSerializer.Deserialize<ContactLeadDto>(jsonString);
                ContactLeadDto isLead = new ContactLeadDto();


                if (filesClient.Files.Count > 0) {
                    var path = await common.UploadSingleFile(filesClient);
                    path = path.Replace("wwwroot", "");

                    isLead = await GetEditLead(newLead.LeadId);
                    isLead.Url = path;
                }

                isLead = await _db.ContactLeads.FirstOrDefaultAsync();

                // Если изменяет только заголовок.
                if (filesClient.Files.Count == 0 && !string.IsNullOrEmpty(newLead.MainTitle)) {                    
                    isLead.MainTitle = newLead.MainTitle;                    
                }

                if (isLead != null) {
                    if (isLead.MainTitle != null) {
                        isLead.MainTitle = newLead.MainTitle;
                    }

                    isLead.LeadName = newLead.LeadName;
                    isLead.LeadPosition = newLead.LeadPosition;
                    isLead.LeadNumber = newLead.LeadNumber;
                    isLead.LeadFax = newLead.LeadFax;
                    isLead.LeadEmail = newLead.LeadEmail;
                }
                isLead.Block = BlockType.CONTACT_LEAD;

                _db.ContactLeads.Update(isLead);
                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод выбирает руководителя, которого нужно изменить.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async Task<ContactLeadDto> GetEditLead(int id) {
            return await _db.ContactLeads.Where(o => o.LeadId == id).FirstOrDefaultAsync();
        }
    }
}