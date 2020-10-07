using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Модель описывает пользователя.
    /// </summary>
    [Table("Users")]
    public class UserDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public UserDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
