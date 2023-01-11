using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.Models
{
    public class MarkAsRead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarkAsReadID { get; set; }

        public string UserName { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("Menu")]
        public int MenuID { get; set; }

        public virtual Menu Menu { get; set; }

    }
}
