using Amoozeshgah.Resource;
using System.ComponentModel.DataAnnotations;

namespace Amoozeshgah.ViewModel
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Username", ResourceType = typeof(BaseResx))]
        public string Username { get; set; }

    }
}
