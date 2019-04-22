using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
   public class PaymentStatus
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Status { get; set; }
    }
}
