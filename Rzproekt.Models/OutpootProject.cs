using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    //[Table("Projects")]
    public class OutpootProject {
        [Key, Column("project_id")]
        public int ProjectId { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Основной заголовок.

        [Column("project_name", TypeName = "nvarchar(1000)")]
        public string ProjectName { get; set; }     // Название проекта.

        [Column("project_detail", TypeName = "nvarchar(max)")]
        public string ProjectDetail { get; set; }  // Детальное описание проекта.

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к изображению.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        [Column("button_text", TypeName = "nvarchar(500)")]
        public string ButtonText { get; set; }  // Текст кнопки - Подробнее.

        [Column("is_main", TypeName = "nvarchar(10)")]
        public string IsMain { get; set; }     // Тип страницы, на которую добавить изображение проекта.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public OutpootProject() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
