using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.Interfaces;
using DAMVC.Models;

namespace DAMVC.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
