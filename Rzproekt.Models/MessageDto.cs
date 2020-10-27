using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей сообщений.
    /// </summary>
    [Table("Messages")]
    public class MessageDto {
        [Key, Column("message_id")]
        public int MessageId { get; set; }

        [Column("message_text", TypeName = "nvarchar(max)")]
        public string MessageText { get; set; }     // Текст сообщения.

        [Column("user_code")]
        public string UserCode { get; set; }    // Код временного пользователя без регистрации.      

        [Column("is_admin")]
        public string IsAdmin { get; set; }

        public int AdminDialogId { get; set; }   // Id диалога для админа.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public MessageDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}