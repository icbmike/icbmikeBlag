using System;
using System.Linq;
using IcbmikeBlag.Application.DAL;
using IcbmikeBlag.Application.Entities;

namespace IcbmikeBlag.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlagContext _context;

        public UserRepository(BlagContext context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            var maybeUser = _context.Users.SingleOrDefault(user => user.Username == username);
            
            //No user with that username
            if (maybeUser == null) return null;

            //If the password matches return the user otherwise null
            return maybeUser.Validate(password) ? maybeUser : null;
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }
    }
}