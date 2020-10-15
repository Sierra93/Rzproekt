using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rzproekt.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей дополнительных изображений проектов.
    /// </summary>
    public class DetailProject {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("url", TypeName = "nvarchar(max)")]
        public string Url { get; set; }     // Путь к изображению.

        [Column("project_id", TypeName = "int")]
        public int ProjectCategory { get; set; }    // Id проекта.

        [Column("is_main_image", TypeName = "nvarchar(5)")]
        public string IsMainImage { get; set; }     // Флаг, который определяет основное изображение или дополнительное.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public DetailProject() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
