using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
    public class MyCoursesDto : Dto
    {
        public MyCoursesDto()
        {
            PageTitle = "کلاس های من";
        }

        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseStartDate { get; set; }
        public string CourseDescription { get; set; }
        public string EducationalCenterName { get; set; }
        public string LessonName { get; set; }
        public string FieldName { get; set; }


    }
}
