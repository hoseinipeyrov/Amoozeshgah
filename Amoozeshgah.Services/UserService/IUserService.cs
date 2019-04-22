
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amoozeshgah.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(string username, string password);

        IEnumerable<UserDto> GetUsersDto();

        User GetUserById(int id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
