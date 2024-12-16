using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGame.Data;

namespace PokemonGame.Architecture.Repository
{
    public class TeamRepository : RepositoryTeamBase<Team> 
    {
        public bool DeleteTeam(int id)
        {
            //PokemonBDEntities.Entry<Team>(team).State = System.Data.Entity.EntityState.Deleted;
            //PokemonBDEntities.Teams.Remove(team);

            return Delete(id);
        }
    }
}
