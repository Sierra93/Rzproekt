using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей анонимных польхователей.
    /// </summary>
    [Table("AnonymousUsers")]
    public class AnonymousUserDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("user_id", TypeName = "nvarchar(max)")]
        public string UserId { get; set; }  // Id пользователя куки.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public AnonymousUserDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
