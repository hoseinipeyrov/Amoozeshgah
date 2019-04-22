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
    public class FieldService : Service, IFieldService
    {
        int siteId;
        public FieldService(IUnitOfWork uow) : base(uow)
        {
            siteId = WebUserInfo.SiteId;
        }
        public IEnumerable<Field> GetFields()
        {
            var fields= uow.Repository<Field>().GetAll(f=>f.Department.DepartmentType.EducationalCenterId== siteId).ToList();
            return fields;
        }
        public IEnumerable<FieldDto> GetFieldsDto()
        {

            var fields = uow.Repository<Field>()
                .GetAll(f => f.Department.DepartmentType.EducationalCenterId == siteId,includeProperties: "Department.DepartmentType")
                .ToList()
                .Select(f => new FieldDto
                {
                    Name = f.Name ,
                    DepartmentName = f.Department.Name,
                    DepartmentTypeName = f.Department.DepartmentType.Name,
                    Id = f.Id,
                    Description = f.Description,
                });
            return fields;

        }
        public Field GetFieldById(int id)
        {
            return uow.Repository<Field>().Get(d => d.Id == id);
        }

        public FieldDto GetFieldDtoById(int id)
        {
            return Mapper.Map<FieldDto>(GetFieldById(id));
        }

        public void UpdateField(Field field)
        {
            uow.Repository<Field>().Update(field);
            uow.SaveChanges();
        }
        public void UpdateFieldDto(FieldDto fieldDto)
        {
            var field = Mapper.Map<Field>(fieldDto);
            UpdateField(field);
        }

        public Field DeleteFieldById(int id)
        {
            var field = GetFieldById(id);
            uow.Repository<Field>().Delete(field);
            uow.SaveChanges();
            return field;
        }

        public void CreateNewField(Field field)
        {
            uow.Repository<Field>().Create(field);
            uow.SaveChanges();
        }

        public void CreateNewFieldDto(FieldDto fieldDto)
        {
            var field = Mapper.Map<Field>(fieldDto);
            //var field = new Field
            //{
            //    Name = fieldDto.Name,
            //    Description = fieldDto.Description,
            //    DepartmentId = fieldDto.DepartmentId,
            //    CreatedDate = DateTime.Now,
            //    CreatedBy = "test"
            //};
            CreateNewField(field);
        }
    }
}
