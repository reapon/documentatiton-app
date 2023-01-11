using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.ViewModel
{
    public class SearchVM
    {

        //c.ContentID, c.MenuID, c.ContentBody, m.MenuText, a.AppID
        public int ID { get; set; }
        public int ContentID { get; set; }
        public int MenuID { get; set; }
        public string ContentBody { get; set; }
        public string ContentTitle { get; set; }
        public string MenuText { get; set; }
        public int AppID { get; set; }

    }
}
