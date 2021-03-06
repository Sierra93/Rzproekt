﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей о нас.
    /// </summary>
    [Table("Abouts")]
    public class AboutDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Основной заголовок.

        [Column("title", TypeName = "nvarchar(1000)")]
        public string Title { get; set; }   // Доп.заголовок.

        [Column("text", TypeName = "nvarchar(max)")]
        public string Text { get; set; }    // Текст.

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к изображению.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        [Column("button_text", TypeName = "nvarchar(500)")]
        public string ButtonText { get; set; }  // Текст кнопки.

        [Column("dop_main_title", TypeName = "nvarchar(1000)")]
        public string DopMainTitle { get; set; }    // Заголовок на странице "Подробнее".

        [Column("dop_title", TypeName = "nvarchar(1000)")]
        public string DopTitle { get; set; }    // Дополнительный заголовок.

        [Column("dop_text", TypeName = "nvarchar(max)")]
        public string DopText { get; set; }     // Дополнительный текст.

        [Column("dop_url", TypeName = "nvarchar(max)")]
        public string DopUrl { get; set; }      // Дополнительное фото на страницу подробнее.

        [Column("cert_url", TypeName = "nvarchar(max)")]
        public string CertUrl { get; set; }      // Дополнительные фото сертификатов.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public AboutDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
