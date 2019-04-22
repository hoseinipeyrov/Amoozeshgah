
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetTeachers();
        IEnumerable<TeacherDto> GetTeachersDto();

        TeacherDto GetTeacherDtoById(int id);
        void UpdateTeacher(Teacher teacher);
        void UpdateTeacherDto(TeacherDto teacherDto);
        Teacher DeleteTeacherById(int id);
        void CreateNewTeacher(Teacher teacher);

        void CreateNewTeacherDto(TeacherDto teacherDto);
    }
}
