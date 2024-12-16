using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGame.Data;
using PokemonGame.Data.Models;

namespace PokemonGame.Architecture.Repository
{
    public class RepositoryUserBase<T> where T : class, IUser
    {
        protected readonly PokemonBDEntities PokemonBDEntities;

        public RepositoryUserBase()
        {
            PokemonBDEntities = new PokemonBDEntities();
        }

        public bool Create(T entity)
        {
            PokemonBDEntities.Set<T>().Add(entity);
            return PokemonBDEntities.SaveChanges() > 0;
        }

        public T SearchUser(string email, string password)
        {
            return PokemonBDEntities.Set<T>().SingleOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
