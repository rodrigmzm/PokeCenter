using PokemonGame.Architecture.Repository;
using PokemonGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Architecture.Services
{
    public class MessageService
    {
        private readonly MessageRepository _messageRepository;
        private readonly Message _message;

        public MessageService()
        {
            _messageRepository = new MessageRepository(); 
            _message = new Message();
        }

        public bool CreateMessageDB(int senderId, int receiverId, string content)
        {
            _message.SenderId = senderId;
            _message.ReceiverId = receiverId;
            _message.Content = content;
            _message.SentDate = DateTime.Now;

            return _messageRepository.CreateMessage(_message);
        }

        public bool DeleteMessageDB(int id)
        {
            return _messageRepository.DeleteMessage(id);
        }

        public IEnumerable<Message> GetMesagesDB(int id)
        {
            var messages = _messageRepository.GetMessagesById(id);

            return messages;
        }
    }
}
