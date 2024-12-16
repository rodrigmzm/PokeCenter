using PokemonGame.Architecture.Repository;
using PokemonGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Architecture.Services
{
    public class TeamService
    {
        private readonly TeamRepository _teamRepository;
        private readonly Team _team;

        public TeamService()
        {
            _teamRepository = new TeamRepository();
            _team = new Team();
        }

        public bool DeleteTeamDB(int id)
        {
            //_team.TeamID = id;

            return _teamRepository.DeleteTeam(id);    
        }
    }
}
