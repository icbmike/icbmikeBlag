using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using IcbmikeBlag.Application.Entities;

namespace IcbmikeBlag.Application.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);

        void CreateUser(User user);

        void DeleteUser(int userID);
    }
}
