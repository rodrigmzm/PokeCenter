using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGame.Data.Models;
using PokemonGame.Data;
using System.Data.Entity;

namespace PokemonGame.Architecture.Repository
{
    public class RepositoryTeamBase<T> where T : class, ITeam
    {
        protected readonly PokemonBDEntities PokemonBDEntities;

        public RepositoryTeamBase()
        {
            PokemonBDEntities = new PokemonBDEntities();
        }

        public bool Delete(int id)
        {
            Team team = PokemonBDEntities.Teams.Find(id);
            PokemonBDEntities.Teams.Remove(team);
            return PokemonBDEntities.SaveChanges() > 0;
        }

    }
}
