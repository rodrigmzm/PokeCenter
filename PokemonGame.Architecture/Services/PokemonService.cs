using PokemonGame.Architecture.Repository;
using PokemonGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Architecture.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _pokemomRepository;
        private readonly Pokemon _pokemon;

        public PokemonService()
        {
            _pokemomRepository = new PokemonRepository();
            _pokemon = new Pokemon();
        }

        public IEnumerable<Pokemon> GetPokemonsDB()
        {
            var pokemons = _pokemomRepository.GetPokemons();
            
            return pokemons;
        }

    }
}
