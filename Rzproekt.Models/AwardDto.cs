using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей наград.
    /// </summary>
    [Table("Awards")]
    public class AwardDto {
        [Key, Column("award_id")]
        public int AwardId { get; set; }

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Фото награды.

        [Column("award_detail", TypeName = "nvarchar(max)")]
        public string AwardDetail { get; set; }  // Описание сертификата.

        [Column("block", TypeName = "nvarchar(500)")]
        public string Block { get; set; }   // Тип блока сертификатов.

        [Column("award_title", TypeName = "nvarchar(1000)")]
        public string AwardTitle { get; set; }   // Заголовок сертификаты.

        [Column("award_name", TypeName = "nvarchar(1000)")]
        public string AwardName { get; set; }    // Название сертификата.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public AwardDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}