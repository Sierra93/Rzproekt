using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей дополнительных изображений проектов.
    /// </summary>
    [Table("ProjectDetails")]
    public class ProjectDetailDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к изображению.

        [Column("project_id", TypeName = "int")]
        public int ProjectId { get; set; }    // Id проекта из основной таблиц проектов.

        [Column("is_main", TypeName = "nvarchar(10)")]
        public string IsMain { get; set; }     // Тип страницы, на которую добавить изображение проекта.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public ProjectDetailDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}