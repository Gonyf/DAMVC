using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.Data;
using DAMVC.Interfaces;
using DAMVC.Models;

namespace DAMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User Get(int id)
        {
            var entity = _context.Users.FirstOrDefault(u => u.Id == id);
            if (entity == null)
                return null;

            return new User
            {
                Id = entity.Id,
                UserName = entity.Username
            };
        }
    }
}
