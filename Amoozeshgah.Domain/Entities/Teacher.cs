using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public virtual User User { get; set; }

        public int? TeacherCode { get; set; }
        public string FatherName { get; set; }


        public int? MaritalStatusId { get; set; }
        [ForeignKey(nameof(MaritalStatusId))]
        public virtual MaritalStatus MaritalStatus { get; set; }

        public int? ReligionId { get; set; }
        [ForeignKey(nameof(ReligionId))]
        public virtual Religion Religions { get; set; }

        public int? EducationDegreeId { get; set; }
        [ForeignKey(nameof(EducationDegreeId))]
        public virtual EducationDegree EducationDegrees { get; set; }

        public int? RecruitmentTypeId { get; set; }
        [ForeignKey("RecruitmentTypeId")]
        public virtual RecruitmentType RecruitmentType { get; set; }

        public int? MilitaryStatusId { get; set; }
        [ForeignKey(nameof(MilitaryStatusId))]
        public virtual MilitaryStatus MilitaryStatus { get; set; }

        public string EducationDegreeFieldName { get; set; }
        public float? EducationDegreeGrade { get; set; }
        public string EducationDegreeGetDateJalali { get; set; }
        public DateTime? EducationDegreeGetDate { get; set; }


        public string EducationDegreeUniversityName { get; set; }

        public bool? HaveWorkExperience { get; set; }

        public int? TeachExperienceInYear { get; set; }

        public int? WorkExperienceInYear { get; set; }
        public bool? MidCareerTraining { get; set; }
        public int? InsuranceNumber { get; set; }

        public int? ChildCount { get; set; }


        public string FreeAndOldSelectionDateJalali { get; set; }

        public string FreeAndOldSelectionNumber { get; set; }



        public int? TrainingCourse { get; set; }

        public string EncouragementDeputy { get; set; }
        public string EncouragementManagers { get; set; }
        public int? PunishmentCount { get; set; }
        public string PunishmentCause { get; set; }
        public int? CompilationCount { get; set; }
        public string CompilationTitle { get; set; }
        public string OfficialArea { get; set; }
        public string OfficialProvince { get; set; }
        public string OfficialCountry { get; set; }
        public int? TiredNo { get; set; }
        public DateTime? TiredDate { get; set; }
        public int? CommunicatedNo { get; set; }
        public string CommunicatedDate { get; set; }
        public int? FrontCountMount { get; set; }
        public int? WarZoneCountMount { get; set; }


        public int? HourInWeek { get; set; }
        public string InsuranceCode { get; set; }
        public int? InsuranceNo { get; set; }
        public int? DefaultWage { get; set; }
        public string Description { get; set; }



        public int? SacrificialLevelId { get; set; }
        [ForeignKey("SacrificialLevelId")]
        public SacrificialLevel SacrificialLevel { get; set; }

        public virtual ICollection<EducationalCenterJoinTeacher> EducationalCentersJoinTeachers { get; set; }
            = new HashSet<EducationalCenterJoinTeacher>();

        public virtual ICollection<Course> Courses { get; set; }
            = new HashSet<Course>();
    }
}
