using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
  public  class CourseJoinStudentMap:EntityTypeConfiguration<CourseJoinStudent>
    {
        public CourseJoinStudentMap()
        {
            //Key
            HasKey(cs => new { cs.CourseId, cs.StudentId });

            //TableName
            ToTable("CoursesJoinStudents");
        }
    }
}
