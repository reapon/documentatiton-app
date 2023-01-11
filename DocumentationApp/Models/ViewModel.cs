using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.Models
{
    public class ViewModel
    {
        public int MenuID { get; set; }
        public string MenuText { get; set; }

        public int? ParentID { get; set; }

        [ForeignKey("ParentID")]

        public virtual ICollection<ViewModel> Child { get; set; }
    }
}
