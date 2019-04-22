using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common.DateConverter
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
        DateTime Now { get; }
        string JalaliNow { get; }


    }
}
