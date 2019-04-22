
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetClasses();
        IEnumerable<CourseDto> GetClassesDto();

        CourseDto GetCourseDtoById(int id);
        void UpdateCourse(Course _class);
        void UpdateClassDto(CourseDto classDto);
        Course DeleteClassById(int id);
        void CreateNewCourse(Course _class);

        void CreateNewCourseDto(CourseDto classDto);
    }
}
