using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей хидера.
    /// </summary>
    [Table("Headers")]
    public class HeaderDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("logo", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к логотипу.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public HeaderDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
