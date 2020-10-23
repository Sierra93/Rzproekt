using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей сообщений.
    /// </summary>
    [Table("DialogMessages")]
    public class DialogMessage {
        [Key, Column("message_id")]
        public int MessageId { get; set; }

        [Column("dialog_id", TypeName = "int")]
        public int DialogId { get; set; }   // Id диалога, который включает в себя свои сообщения.

        [Column("message", TypeName = "nvarchar(max)")]
        public string Message { get; set; }     // Текст сообщения.

        [Column("created", TypeName = "datetime")]
        public DateTime Created { get; set; }   // Дата и время создания сообщения.

        [Column("is_admin", TypeName = "nvarchar(5)")]
        public string isAdmin { get; set; }   // Админ пишет или нет.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public DialogMessage() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
