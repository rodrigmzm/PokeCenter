using PokemonGame.Data.Models;
using PokemonGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Architecture.Repository
{
    public class RepositoryPokemonBase<T> where T : class, IPokemon
    {
        protected readonly PokemonBDEntities PokemonBDEntities;

        public RepositoryPokemonBase()
        {
            PokemonBDEntities = new PokemonBDEntities();
        }

        public IEnumerable<T> GetEntities()
        {
            return PokemonBDEntities.Set<T>().ToList();
        }
    }

}
