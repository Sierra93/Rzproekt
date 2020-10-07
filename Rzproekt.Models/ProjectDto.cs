using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей проектов.
    /// </summary>
    [Table("Projects")]
    public class ProjectDto {
        [Key, Column("project_id")]
        public int ProjectId { get; set; }

        [Column("main_title", TypeName = "nvarchar(1000)")]
        public string MainTitle { get; set; }   // Основной заголовок.

        [Column("title", TypeName = "nvarchar(1000)")]
        public string Title { get; set; }

        [Column("detail", TypeName = "nvarchar(max)")]
        public string Detail { get; set; }  // Детальное описание проекта.

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к изображению.

        [Column("block")]
        public string Block { get; set; }   // Тип блока, в который нужно вставлять контент.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public ProjectDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
