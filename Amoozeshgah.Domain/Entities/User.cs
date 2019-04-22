using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public virtual Person Person { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual EducationalCenterUser EducationalCenterUser { get; set; }




        public virtual ICollection<SiteUserRole> UsersRoles { get; set; }
        = new HashSet<SiteUserRole>();
    }
}
