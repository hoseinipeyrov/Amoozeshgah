using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common
{
    public enum ApplicationType
    {
        [Display(Name = "آموزشی")]
        Learning = 1,

        [Display(Name = "غیر آموزشی")]
        NoneLearning = 0,
    }

    public enum HaveNotHave
    {
        [Display(Name = "دارد")]
        Have = 1,

        [Display(Name = "ندارد")]
        NotHave = 0,
    }
    public enum YesNo
    {
        [Display(Name = "بله")]
        بله = 1,

        [Display(Name = "خیر")]
        خیر = 0,
    }
    public static class Enums
    {
        public enum RoleCode
        {
            Setad = 1,
            ProvinceUser = 2,
            AreaUser = 3,
            EducationalCenterUser = 4,
            Teacher = 6,
            Student = 7,
        }
        public enum CategoryItemCode
        {
            LanguageCenter = 1,
            ElementaryScienceficCenter = 2,
            FirstLevelScienceficCenter = 3,
            SecondLevelAndKonkorScienceficCenter = 4,


        }
        public enum SexCode
        {
            Son = 1,
            Daughter = 2

        }
        public enum EducationalCenterTypeCode
        {
            Language = 1,
            ElementaryScientific = 2,
            FirstMiddleScientific = 3,
            SecondMiddleScientific = 4,
            Entrance = 5,
            Exam = 6

        }





    }
}
