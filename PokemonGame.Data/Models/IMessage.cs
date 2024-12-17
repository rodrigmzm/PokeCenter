using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Data.Models
{
    public interface IMessage
    {
         int MessageId { get; set; }
         int SenderId { get; set; }
         int ReceiverId { get; set; }
         string Content { get; set; }
         System.DateTime SentDate { get; set; }
    }
}
