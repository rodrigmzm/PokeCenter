using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGame.Data;

namespace PokemonGame.Architecture.Repository
{
    public class PokemonRepository : RepositoryPokemonBase<Pokemon>
    {
        public IEnumerable<Pokemon> GetPokemons()
        {
            return GetEntities();
        }
    }
}
