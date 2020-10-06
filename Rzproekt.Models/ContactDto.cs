﻿using System;
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

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }

        [Column("title", TypeName = "nvarchar(1000)")]
        public string  Title { get; set; }

        [Column("text", TypeName = "nvarchar(max)")]
        public string Text { get; set; }

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public ContactDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
