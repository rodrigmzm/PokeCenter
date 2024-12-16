using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Data.Models
{
    public interface IPokemon
    {
         int PokemonId { get; set; }
         string Name { get; set; }
         int Type { get; set; }
         int Weakness { get; set; }
         int LifePoints { get; set; }
         int MaxLifePoints { get; set; }
    }
}
