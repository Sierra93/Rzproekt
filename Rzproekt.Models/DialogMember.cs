using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей участников диалога.
    /// </summary>
    [Table("DialogMembers")]
    public class DialogMember {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("user_id", TypeName = "nvarchar(max)")]
        public string UserId { get; set; }     // Id участника диалога.

        [Column("joined", TypeName = "datetime")]
        public DateTime Joined { get; set; }    // Дата и время, когда участник присоединился к диалогу.

        [Column("dialog_id")]
        public int DialogId { get; set; }

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public DialogMember() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
