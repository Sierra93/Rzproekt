using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей сообщений.
    /// </summary>
    public class MessageDto {
        [Key, Column("message_id")]
        public int MessageId { get; set; }

        [Column("message_text", TypeName = "nvarchar(max)")]
        public string MessageText { get; set; }     // Текст сообщения.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public MessageDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
