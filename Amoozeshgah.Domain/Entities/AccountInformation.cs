using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class AccountInformation:BaseEntity
    {
        public int EducationalCenterId { get; set; }
        [ForeignKey(nameof(EducationalCenterId))]
        public EducationalCenter EducationalCenter { get; set; }
        public string AccountOwnerFirstName { get; set; }
        public string AccountOwnerLastName { get; set; }
        public int BankId { get; set; }

        [ForeignKey(nameof(BankId))]
        public Bank Bank { get; set; }

        public string BrancheName { get; set; }
        public int BrancheCode { get; set; }
        public string AccountNumber { get; set; }

        //شماره شبا
        public string IdPay { get; set; }
        public string IdPayNumbers { get; set; }














        public bool? IsConfermed { get; set; }
        public string ConfermedBy { get; set; }
        public DateTime? ConfermedDate { get; set; }
        public string ConfermedDateJalali { get; set; }


    }
}
