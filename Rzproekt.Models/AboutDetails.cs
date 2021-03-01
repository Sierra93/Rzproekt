using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей доп.изображений О НАС.
    /// </summary>
    [Table("AboutDetails", Schema = "dbo")]
    public class AboutDetails {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("dop_url", TypeName = "nvarchar(max)")]
        public string DopUrl { get; set; }

        [Column("about_id")]
        public int AboutId { get; set; }

        [Column("block")]
        public string Block { get; set; }

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public AboutDetails() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
