using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Amoozeshgah.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string NationalCode { get; set; }
        public string MobileNo { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateJalali { get; set; }
        public int SexId { get; set; }
        [ForeignKey("SexId")]
        public virtual Sex Sex { get; set; }
        public string FatherFirstName { get; set; }

        public virtual User User { get; set; }


    }
}
