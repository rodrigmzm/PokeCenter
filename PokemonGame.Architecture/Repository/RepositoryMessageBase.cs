using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGame.Data;
using PokemonGame.Data.Models;

namespace PokemonGame.Architecture.Repository
{
    public class RepositoryMessageBase<T> where T : class, IMessage
    {
        protected readonly PokemonBDEntities PokemonBDEntities;

        public RepositoryMessageBase()
        {
            PokemonBDEntities = new PokemonBDEntities();
        }

        public bool Create (T entity)
        {
            PokemonBDEntities.Set<T>().Add(entity);

            return PokemonBDEntities.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Message message = PokemonBDEntities.Messages.Find(id);
            PokemonBDEntities.Messages.Remove(message);

            return PokemonBDEntities.SaveChanges() > 0;
        }

        public IEnumerable<T> GetMessages(int id)
        {
            return PokemonBDEntities.Set<T>().ToList().Where(x => x.ReceiverId == id);
        }
    }
}
