using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей контактов.
    /// </summary>
    [Table("ContactsCompany")]
    public class ContactCompanyDto {
        [Key, Column("contact_id")]
        public int ContactId { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Заголовок КОНТАКТЫ.

        [Column("title", TypeName = "nvarchar(1000)")]
        public string Title { get; set; }   // Заголовок центр.офис.

        [Column("address_company", TypeName = "nvarchar(max)")]
        public string AddressCompany { get; set; }  // Адрес компании.

        [Column("email_company", TypeName = "nvarchar(max)")]
        public string EmailCompany { get; set; }  // Email компании.

        [Column("company_number", TypeName = "nvarchar(500)")]
        public string NumberCompany { get; set; }  // Номер компании.   

        [Column("button_text", TypeName = "nvarchar(500)")]
        public string ButtonText { get; set; }

        [Column("block", TypeName = "nvarchar(500)")]
        public string Block { get; set; }

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public ContactCompanyDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}