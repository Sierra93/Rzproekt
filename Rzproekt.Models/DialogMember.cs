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
        [Key, Column("dialog_id")]
        public int DialogId { get; set; }

        [Column("user_id", TypeName = "int")]
        public int UserId { get; set; }     // Id участника диалога.

        [Column("joined", TypeName = "datetime")]
        public DateTime Joined { get; set; }    // Дата и время, когда участник присоединился к диалогу.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public DialogMember() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
