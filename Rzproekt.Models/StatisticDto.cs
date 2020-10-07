using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Таблица сопоставляется с таблицей статистики.
    /// </summary>
    [Table("Statistic")]
    public class StatisticDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("number", TypeName = "int")]
        public int Number { get; set; } 

        [Column("text", TypeName = "nvarchar(max)")]
        public string Text { get; set; }    // Текст.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public StatisticDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
