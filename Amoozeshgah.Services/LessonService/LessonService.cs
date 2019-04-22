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
    public class LessonService : Service, ILessonService
    {
        public LessonService(IUnitOfWork uow) : base(uow)
        {
        }
        public IEnumerable<Lesson> GetAll()
        {
            return uow.Repository<Lesson>().GetAll();
        }
        public IEnumerable<LessonDto> GetAllDto()
        {
            return GetAll().Select(Mapper.Map<Lesson, LessonDto>);
        }
        public Lesson GetById(int id)
        {
            return uow.Repository<Lesson>().Get(d => d.Id == id);
        }

        public LessonDto GetDtoById(int id)
        {
            return Mapper.Map<LessonDto>(GetById(id));
        }

        public void Update(Lesson entity)
        {
            uow.Repository<Lesson>().Update(entity);
            uow.SaveChanges();
        }
        public void UpdateDto(LessonDto entityDto)
        {
            var lesson = Mapper.Map<Lesson>(entityDto);
            Update(lesson);
        }

        public Lesson DeleteById(int id)
        {
            var item = GetById(id);
            uow.Repository<Lesson>().Delete(item);
            uow.SaveChanges();
            return item;
        }

        public void CreateNew(Lesson entity)
        {
            uow.Repository<Lesson>().Create(entity);
            uow.SaveChanges();
        }

        public void CreateNewDto(LessonDto entityDto)
        {
            var item = Mapper.Map<Lesson>(entityDto);
            CreateNew(item);
        }
    }
}
