using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Core.UoW;

using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Common.Domain;

namespace Amoozeshgah.Services
{
    public class CourseService : Service, ICourseService
    {
        public CourseService(IUnitOfWork uow) : base(uow)
        {
        }
        public IEnumerable<Course> GetClasses()
        {
            return uow.Repository<Course>().GetAll();
        }
        public IEnumerable<CourseDto> GetClassesDto()
        {
            return GetClasses().Select(Mapper.Map<Course, CourseDto>);
        }
        public Course GetCourseById(int id)
        {
            return uow.Repository<Course>().Get(d => d.Id == id);
        }

        public CourseDto GetCourseDtoById(int id)
        {
            return Mapper.Map<CourseDto>(GetCourseById(id));
        }

        public void UpdateCourse(Course course)
        {
            uow.Repository<Course>().Update(course);
            uow.SaveChanges();
        }
        public void UpdateClassDto(CourseDto courseDto)
        {
            var course = Mapper.Map<Course>(courseDto);
            UpdateCourse(course);
        }

        public Course DeleteClassById(int id)
        {
            var course = GetCourseById(id);
            uow.Repository<Course>().Delete(course);
            uow.SaveChanges();
            return course;
        }

        public void CreateNewCourse(Course course)
        {
            uow.Repository<Course>().Create(course);
            uow.SaveChanges();
        }

        public void CreateNewCourseDto(CourseDto courseDto)
        {
            var course = Mapper.Map<Course>(courseDto);
            course.CreatedBy = WebUserInfo.UserId.ToString();
            CreateNewCourse(course);
        }
    }
}
