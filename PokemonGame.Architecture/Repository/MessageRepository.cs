using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGame.Data;

namespace PokemonGame.Architecture.Repository
{
    public class MessageRepository : RepositoryMessageBase<Message>
    {
        public bool CreateMessage(Message message)
        {
            return Create(message);
        }

        public bool DeleteMessage(int id)
        {
            return Delete(id);
        }

        public IEnumerable<Message> GetMessagesById(int id)
        {
            return GetMessages(id);
        }

    }
}
