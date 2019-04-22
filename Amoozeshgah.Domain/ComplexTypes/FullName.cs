using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.ComplexTypes
{
    [ComplexType]
    public class FullName
    {
        [MaxLength(50, ErrorMessage = "حداکثر 50 حرف")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "حداکثر 50 حرف")]
        public string LastName { get; set; }

    }
}
