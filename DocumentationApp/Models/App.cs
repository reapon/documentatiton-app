using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.Models
{
    public class App
    {
        [Key]
        public int AppID { get; set; }
        [Required(ErrorMessage ="App Name Required")]
        public string AppName { get; set; }

        [Required(ErrorMessage = "App Title Required")]

        public string AppTitle { get; set; }

        
        public bool IsPublished { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

    }
}
