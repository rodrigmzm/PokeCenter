using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGame.Data;

namespace PokemonGame.Architecture.Repository
{
    public class UserRepository : RepositoryUserBase<User>
    {
        public bool CreateUser(User user)
        {
            return Create(user);
        }

        public User LoginUser (string email,  string password)
        {
            return SearchUser(email, password);
        }
    }
}
