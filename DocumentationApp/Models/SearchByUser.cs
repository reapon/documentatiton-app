using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.Models
{
    public class SearchByUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SearchByUserID { get; set; }
        public string SearchedWord { get; set; }
        public string UserName { get; set; }
        public DateTime SearchedTime { get; set; }
    }
}
