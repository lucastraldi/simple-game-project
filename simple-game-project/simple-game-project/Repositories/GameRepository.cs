using simple_game_project.Entities;
using simple_game_project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_game_project.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private List<Game> _games = new List<Game>();

        public void Add(Game entity)
        {
            entity.CreatedAt = DateTime.Now;
            _games.Add(entity);
        }

        public void Delete(int id)
        {
            _games[id].Delete();
        }

        public List<Game> GetAll()
        {
            return _games;
        }

        public Game GetById(int id)
        {
            return _games[id];
        }

        public int NextId()
        {
            return _games.Count;
        }

        public void Update(int id, Game entity)
        {
            entity.Id = id;
            entity.CreatedAt = _games[id].CreatedAt;
            entity.UpdatedAt = DateTime.Now;
            _games[id] = entity;
        }
    }
}
