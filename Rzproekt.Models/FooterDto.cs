using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей футера.
    /// </summary>
    [Table("Footers")]
    public class FooterDto {
        [Key, Column("footer_id")]
        public int Id { get; set; }

        [Column("copy_str", TypeName = "nvarchar(1000)")]
        public string CopyStr { get; set; }     // Строка копирайта.

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к иконке.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public FooterDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
