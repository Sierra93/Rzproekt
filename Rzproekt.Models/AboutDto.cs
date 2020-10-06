using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей о нас.
    /// </summary>
    [Table("Abouts")]
    public class AboutDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Основной заголовок.

        [Column("title", TypeName = "nvarchar(1000)")]
        public string Title { get; set; }   // Доп.заголовок.

        [Column("text", TypeName = "nvarchar(max)")]
        public string Text { get; set; }    // Текст.

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к изображению.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public AboutDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
