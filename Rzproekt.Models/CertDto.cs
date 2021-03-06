﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей сертификатов.
    /// </summary>
    [Table("Certs")]
    public class CertDto {
        [Key, Column("cert_id")]
        public int CertId { get; set; }

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Фото сертификата.

        [Column("cert_detail", TypeName = "nvarchar(max)")]
        public string CertDetail { get; set; }  // Описание сертификата.

        [Column("block", TypeName = "nvarchar(500)")]
        public string Block { get; set; }   // Тип блока сертификатов.

        [Column("cert_title", TypeName = "nvarchar(1000)")]
        public string CertTitle { get; set; }   // Заголовок сертификаты.

        [Column("cert_name", TypeName = "nvarchar(1000)")]
        public string CertName { get; set; }    // Название сертификата.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public CertDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
