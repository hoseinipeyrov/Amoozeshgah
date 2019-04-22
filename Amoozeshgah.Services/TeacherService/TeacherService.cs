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
    public class TeacherService : Service, ITeacherService
    {
        public TeacherService(IUnitOfWork uow) : base(uow)
        {
        }
        public IEnumerable<Teacher> GetTeachers()
        {
            return uow.Repository<Teacher>().GetAll();
        }
        public IEnumerable<TeacherDto> GetTeachersDto()
        {
            return GetTeachers().Select(Mapper.Map<Teacher, TeacherDto>);
        }
        public Teacher GetTeacherById(int id)
        {
            return uow.Repository<Teacher>().Get(d => d.Id == id);
        }

        public TeacherDto GetTeacherDtoById(int id)
        {
            return Mapper.Map<TeacherDto>(GetTeacherById(id));
        }

        public void UpdateTeacher(Teacher teacher)
        {
            uow.Repository<Teacher>().Update(teacher);
            uow.SaveChanges();
        }
        public void UpdateTeacherDto(TeacherDto teacherDto)
        {
            var teacher = Mapper.Map<Teacher>(teacherDto);
            UpdateTeacher(teacher);
        }

        public Teacher DeleteTeacherById(int id)
        {
            var teacher = GetTeacherById(id);
            uow.Repository<Teacher>().Delete(teacher);
            uow.SaveChanges();
            return teacher;
        }

        public void CreateNewTeacher(Teacher teacher)
        {
            uow.Repository<Teacher>().Create(teacher);
            uow.SaveChanges();
        }

        public void CreateNewTeacherDto(TeacherDto teacherDto)
        {
            var teacher = Mapper.Map<Teacher>(teacherDto);
            //var lesson = new Lesson
            //{
            //    Name = lessonDto.Name,
            //    Description = lessonDto.Description,
            //    DepartmentId = lessonDto.DepartmentId,
            //    CreatedDate = DateTime.Now,
            //    CreatedBy = "test"
            //};
            CreateNewTeacher(teacher);
        }
    }
}
