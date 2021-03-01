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

        [Column("manu_item", TypeName = "nvarchar(1000)")]
        public string MainItem { get; set; }    // Пункт меню хидера.

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Главный заголовок.

        [Column("background", TypeName = "nvarchar(1000)")]
        public string Background { get; set; }  // Фоновое изображение хидера или видео.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        [Column("main_text", TypeName = "nvarchar(1000)")]
        public string MainText { get; set; }    // Заголовок хидера.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public HeaderDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
