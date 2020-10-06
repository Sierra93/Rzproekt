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

        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес.")]
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
