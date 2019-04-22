using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Amoozeshgah.Common.DateConverter;

namespace Amoozeshgah.Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        = DateTime.Now;
        public string CreatedDateJalali { get; set; }
            = DateTime.Now.ToJalalDateTime(DateFormat.FullDateTime);

        //[Timestamp]
        //public byte[] TimeStamp { get; set; }
    }
}
