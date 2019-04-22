
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface ILessonService
    {
        IEnumerable<Lesson> GetAll();
        IEnumerable<LessonDto> GetAllDto();

        LessonDto GetDtoById(int id);
        void Update(Lesson lesson);
        void UpdateDto(LessonDto lessonDto);
        Lesson DeleteById(int id);
        void CreateNew(Lesson lesson);

        void CreateNewDto(LessonDto lessonDto);
    }
}
