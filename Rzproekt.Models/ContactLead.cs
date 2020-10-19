using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей контактов сотрудника.
    /// </summary>
    [Table("ContactsLead")]
    public class ContactLead {
        [Key, Column("lead_id")]
        public int LeadId { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Заголовок РУКОВОДСТВО.

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }

        [Column("lead_name", TypeName = "nvarchar(1000)")]
        public string LeadName { get; set; }     // ФИО руководителя.

        [Column("lead_position", TypeName = "nvarchar(1000)")]
        public string LeadPosition { get; set; }    // Должность руководителя.

        [Column("lead_number", TypeName = "nvarchar(500)")]
        public string LeadNumber { get; set; }    // Телефон руководителя.

        [Column("lead_fax", TypeName = "nvarchar(1000)")]
        public string LeadFax { get; set; }    // Факс руководителя.

        [Column("lead_email", TypeName = "nvarchar(1000)")]
        public string LeadEmail { get; set; }    // Email руководителя.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public ContactLead() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
