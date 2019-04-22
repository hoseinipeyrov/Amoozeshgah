using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Core.UoW;

using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Services
{
    public class ClassroomService : Service, IClassroomService
    {
        public ClassroomService(IUnitOfWork uow) : base(uow)
        {
        }
        public IEnumerable<Classroom> GetClassrooms()
        {
            return uow.Repository<Classroom>().GetAll();
        }
        public IEnumerable<ClassroomDto> GetClassroomsDto()
        {
            return GetClassrooms().Select(Mapper.Map<Classroom, ClassroomDto>);
        }
        public Classroom GetClassroomById(int id)
        {
            return uow.Repository<Classroom>().Get(d => d.Id == id);
        }

        public ClassroomDto GetClassroomDtoById(int id)
        {
            return Mapper.Map<ClassroomDto>(GetClassroomById(id));
        }

        public void UpdateClassroom(Classroom classroom)
        {
            uow.Repository<Classroom>().Update(classroom);
            uow.SaveChanges();
        }
        public void UpdateClassroomDto(ClassroomDto classroomDto)
        {
            var classroom = Mapper.Map<Classroom>(classroomDto);
            UpdateClassroom(classroom);
        }

        public Classroom DeleteClassroomById(int id)
        {
            var classroom = GetClassroomById(id);
            uow.Repository<Classroom>().Delete(classroom);
            uow.SaveChanges();
            return classroom;
        }

        public void CreateNewClassroom(Classroom classroom)
        {
            uow.Repository<Classroom>().Create(classroom);
            uow.SaveChanges();
        }

        public void CreateNewClassroomDto(ClassroomDto classroomDto)
        {
            var classroom = Mapper.Map<Classroom>(classroomDto);
            //var lesson = new Lesson
            //{
            //    Name = lessonDto.Name,
            //    Description = lessonDto.Description,
            //    DepartmentId = lessonDto.DepartmentId,
            //    CreatedDate = DateTime.Now,
            //    CreatedBy = "test"
            //};
            CreateNewClassroom(classroom);
        }

        
    }
}
