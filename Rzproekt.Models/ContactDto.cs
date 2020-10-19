using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей контактов.
    /// </summary>
    [Table("Contacts")]
    public class ContactDto {
        [Key, Column("contact_id")]
        public int ContactId { get; set; }

        [Column("contact_name", TypeName = "nvarchar(max)")]
        public string ContactName { get; set; }     // Имя контакта.

        [Column("position_name", TypeName = "nvarchar(max)")]
        public string  PositionName { get; set; }   // Название позиции.

        [Column("contact_number", TypeName = "nvarchar(max)")]
        public string ContactNumber { get; set; }   // Номер контакта.

        [Column("contact_fax", TypeName = "nvarchar(max)")]
        public string ContactFax { get; set; }   // Факс.

        [Column("contact_email", TypeName = "nvarchar(max)")]
        public string ContactEmail { get; set; }   // Номер контакта.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        [Column("button_text", TypeName = "nvarchar(500)")]
        public string ButtonText { get; set; }  // Текст кнопки.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public ContactDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}