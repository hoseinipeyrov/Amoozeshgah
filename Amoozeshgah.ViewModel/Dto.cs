using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
    public class Dto
    {
        public Dto()
        {
            PageTitle = "";
            LobiPanelDataId = GetType().Name.ToLower();
        }
        [ScaffoldColumn(false)]
        public string PageTitle { get; set; }
        [ScaffoldColumn(false)]
        public string LobiPanelDataId { get; set; }

    }
}
