using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class EducationalCenter : BaseEntity
    {
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }


        public string MoassesFirstName { get; set; }
        public string MoassesLastName { get; set; }
        public string MoassesNationalCode { get; set; }
        public string MoassesMobileNo { get; set; }


        public virtual Site Site { get; set; }
        public string CertificateCode { get; set; }
        public string Category { get; set; }
        public int SexId { get; set; }
        [ForeignKey(nameof(SexId))]
        public virtual Sex Sex { get; set; }

        public int ShiftId { get; set; }
        [ForeignKey(nameof(ShiftId))]
        public virtual Shift Shift { get; set; }

        public virtual ICollection<CategoryItem> CategoryItems { get; set; }
        = new HashSet<CategoryItem>();

        public virtual ICollection<DepartmentType> DepartmentTypes { get; set; }
         = new HashSet<DepartmentType>();
        public virtual ICollection<Term> Terms { get; set; }
         = new HashSet<Term>();


        public virtual ICollection<EducationalCenterJoinTeacher> Teachers { get; set; }
            = new HashSet<EducationalCenterJoinTeacher>();
        public virtual ICollection<Classroom> Classrooms { get; set; }
            = new HashSet<Classroom>();

        public string Rule { get; set; }





        public virtual ICollection<LanguageDeterminationLevelRequest> LanguageDeterminationLevelRequests { get; set; }
            = new HashSet<LanguageDeterminationLevelRequest>();



        public bool? HavePrayerRoom { get; set; }
        public bool? HaveLibrary { get; set; }
        public bool? HavePlaceConfirmation { get; set; }
        public int? EstateStatusId { get; set; }
        [ForeignKey(nameof(EstateStatusId))]
        public EstateStatus EstateStatus { get; set; }
        public int? MonthlyRentCost { get; set; }
        public int? AreaArenaMeter { get; set; }
        public int? AreaLordMeter { get; set; }
        public int? FloorCount { get; set; }
        public bool? IsApplicationTypeForLearning { get; set; }
        public bool? HaveLanguageLaborator { get; set; }
        public bool? HaveSmartSystem { get; set; }
        public bool? HaveAdvisorRoom { get; set; }
        public bool? HaveSite { get; set; }
        public bool? HaveDedicatedBuffet { get; set; }
        public bool? HaveDedicatedDrinking { get; set; }
        public bool? HaveWarmWc { get; set; }


















        public string PostalCode { get; set; }

        public int? CertificateTypeId { get; set; }
        public virtual CertificateType CertificateType { get; set; }

        public int? EstablishmentDate { get; set; }

        public virtual ICollection<CourseHoldingType> CourseHoldingTypes { get; set; }
            = new HashSet<CourseHoldingType>();

        public bool? IsIndependentEducationalCenter { get; set; }
        public string SitePlace { get; set; }



















        public DateTime? TemporaryEstablishmentCertificateGeorgianDate { get; set; }
        public string TemporaryEstablishmentCertificateJalaliDate { get; set; }

        public DateTime? BootCertificateGeorgianDate { get; set; }
        public string BootCertificateJalaliDate { get; set; }

        public DateTime? MovementCertificateGeorgianDate { get; set; }
        public string MovementCertificateJalaliDate { get; set; }

        public DateTime? EvenOddCertificateGeorgianDate { get; set; }
        public string EvenOddCertificateJalaliDate { get; set; }

        public string TemporaryEstablishmentCertificateNumber { get; set; }
        public string BootCertificateNumber { get; set; }
        public string EvenOddCertificateNumber { get; set; }











        public ICollection<AccountInformation> AccountInformations { get; set; }
        = new HashSet<AccountInformation>();



    }
}
