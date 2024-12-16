using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Data.Models
{
    public interface ITeam
    {
         int TeamID { get; set; }
         int UserId { get; set; }
         int PokemonId1 { get; set; }
         int PokemonId2 { get; set; }
         int PokemonId3 { get; set; }
         int PokemonId4 { get; set; }
         string Description { get; set; }
    }
}
