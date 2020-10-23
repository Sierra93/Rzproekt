using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей главной информации о диалоге.
    /// </summary>
    [Table("MainInfoDialogs")]
    public class MainInfoDialog {
        [Key, Column("dialog_id")]
        public int DialogId { get; set; }

        [Column("dialog_name", TypeName = "nvarchar(1000)")]
        public string DialogName { get; set; }      // Название диалога.

        [Column("created", TypeName = "datetime")]
        public DateTime Created { get; set; }   // Время и дата создания диалога.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public MainInfoDialog() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
