
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface IFieldService
    {
        IEnumerable<Field> GetFields();
        IEnumerable<FieldDto> GetFieldsDto();

        FieldDto GetFieldDtoById(int id);
        void UpdateField(Field field);
        void UpdateFieldDto(FieldDto fieldDto);
        Field DeleteFieldById(int id);
        void CreateNewField(Field field);

        void CreateNewFieldDto(FieldDto fieldDto);
    }
}
