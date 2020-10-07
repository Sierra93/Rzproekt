using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей услуг.
    /// </summary>
    [Table("Orders")]
    public class OrderDto {
        [Key, Column("order_id")]
        public int OrderId { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Основной заголовок.

        [Column("title", TypeName = "nvarchar(1000)")]
        public string Title { get; set; }   // Заголовок.

        [Column("text", TypeName = "nvarchar(max)")]
        public string Text { get; set; }

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        [Column("button_text", TypeName = "nvarchar(500)")]
        public string ButtonText { get; set; }  // Текст кнопки.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public OrderDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
