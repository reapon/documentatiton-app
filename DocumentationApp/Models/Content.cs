using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.Models
{
    public class Content
    {
        public int ContentID { get; set; }

        public string ContentTitle { get; set; }
        public string ContentBody { get; set; }

        public int VersionNo { get; set; } = 1;


        //Added For Pubished and Track User and Time
        public bool IsPublished { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // 

        public int MenuID { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
