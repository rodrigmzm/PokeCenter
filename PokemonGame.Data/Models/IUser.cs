using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Data.Models
{
    public interface IUser
    {
        int UserId { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        int IdRol { get; set; }
    }
}
