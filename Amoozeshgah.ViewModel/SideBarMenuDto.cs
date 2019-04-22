using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
    public class SideBarMenuDto
    {
        public string Menu { get; set; }
        public string Item { get; set; }
        public string MenuIcon { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        public string Active { get; set; }
    }
}
