using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }

        [Required(ErrorMessage = "Menu Name Required")]
        public string MenuText { get; set; }

        [Required(ErrorMessage ="Tags Are Required")]
        public string MenuTags { get; set; }
        public int? ParentID { get; set; }

        public int AppID { get; set; }

        //Added For Pubished and Track User and Time
        public bool IsPublished { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // 

        //Added For Restricted Menu
        public bool IsRestricted { get; set; }
        //

        public virtual Menu Parent { get; set; }
        //public virtual List<Menu> Child { get; set; }

        public virtual ICollection<Menu> ChildMenu { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        //public virtual Content Content { get; set; }


        public virtual App App { get; set; }

        public virtual ICollection<MarkAsRead> MarkAsReads { get; set; }


    }


}
