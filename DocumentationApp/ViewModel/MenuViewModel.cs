using DocumentationApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.ViewModel
{
    public class MenuViewModel
    {
        public int MenuID { get; set; }
        public string MenuText { get; set; }

        public string MenuTags { get; set; }
        public int? ParentID { get; set; }

        public int AppID { get; set; }

        public string Content { get; set; }
        
        public int VersionNo { get; set; }

        public string ContentTitle { get; set; }

        public bool MenuPublish { get; set; }
        public bool ContentPublish { get; set; }

        public bool IsRestricted { get; set; }


        public int ContentMenuID { get; set; }

        //New Item Add For Content ID
        public int ContentID { get; set; }

        public virtual Menu Parent { get; set; }
        //public virtual List<Menu> Child { get; set; }

        public virtual ICollection<Menu> ChildMenu { get; set; }

        public virtual ICollection<Content> Contents { get; set; }

        public virtual App App { get; set; }



    }

    //public class ContentViewModel
    //{
    //    [Key]
    //    public int ID { get; set; }

    //    public int MenuID { get; set; }

    //    public string MenuText { get; set; }
    //    public int? ParentID { get; set; }

    //    public int AppID { get; set; }

    //    //public string Content { get; set; }

    //    public int ContentMenuID { get; set; }

    //    public virtual Menu Parent { get; set; }
    //    //public virtual List<Menu> Child { get; set; }

    //    public virtual ICollection<Menu> ChildMenu { get; set; }

    //    public virtual Content Content { get; set; }

    //    public virtual App App { get; set; }



    //}
}
