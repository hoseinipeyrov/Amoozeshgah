
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface IClassroomService
    {
        IEnumerable<Classroom> GetClassrooms();
        IEnumerable<ClassroomDto> GetClassroomsDto();

        ClassroomDto GetClassroomDtoById(int id);
        void UpdateClassroom(Classroom classroom);
        void UpdateClassroomDto(ClassroomDto classroomDto);
        Classroom DeleteClassroomById(int id);
        void CreateNewClassroom(Classroom classroom);

        void CreateNewClassroomDto(ClassroomDto classroomDto);
    }
}
