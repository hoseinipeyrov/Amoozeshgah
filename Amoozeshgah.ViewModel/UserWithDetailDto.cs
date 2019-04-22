using Amoozeshgah.Domain.Entities;


namespace Amoozeshgah.ViewModel
{
    public class UserWithDetailDto
    {
        public User User { get; set; }
        public SiteUserRole Role { get; set; }
        public Site Site { get; set; }
    }
}
