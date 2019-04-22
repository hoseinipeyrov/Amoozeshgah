using Amoozeshgah.Core.UoW;
using System.Collections.Generic;

using System;
using System.Linq;
using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;
using System.Threading.Tasks;

namespace Amoozeshgah.Services
{
    public class UserService : Service, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<User> GetUsers()
        {
            return uow.Repository<User>().GetAll().ToList();
        }
        public IEnumerable<User> GetAllUsers()
        {
            return uow.Repository<User>().GetAll().ToList();
        }
        public User GetUser(string username, string password)
        {
            return uow.Repository<User>().Get(u => u.UserName == username && u.Password == password);
        }

        public User GetUserById(int id)
        {
            return uow.Repository<User>().Get(u => u.Id == id);
        }

        public void InsertUser(User user)
        {
            uow.Repository<User>().Create(user);
            uow.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            uow.Repository<User>().Update(user);
            uow.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            uow.Repository<User>().Delete(user);
            uow.SaveChanges();
        }
        public void DeleteUserById(int id)
        {
            var user = GetUserById(id);
            DeleteUser(user);
        }

        public IEnumerable<UserDto> GetUsersDto()
        {
            return uow.Repository<User>().GetAll().Select(Mapper.Map<User, UserDto>).ToList();
        }
    }

}
