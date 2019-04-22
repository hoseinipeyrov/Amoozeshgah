using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
    class EducationalCenterJoinTeacherMap : EntityTypeConfiguration<EducationalCenterJoinTeacher>
    {
        public EducationalCenterJoinTeacherMap()
        {
            //Key
            HasKey(ect => new { ect.EducationalCenterId, ect.TeacherId });

            //TableName
            ToTable("EducationalCentersJoinTeachers");
        }
    }
}
