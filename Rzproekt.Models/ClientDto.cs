using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей клиентов.
    /// </summary>
    [Table("Clients")]
    public class ClientDto {
        [Key, Column("client_id")]
        public int ClientId { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к изображению.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        [Column("client_name", TypeName = "nvarchar(1000)")]
        public string ClientName { get; set; }  // Название клиента.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public ClientDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
