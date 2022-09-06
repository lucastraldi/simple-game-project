using simple_game_project.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_game_project.Entities
{
    public class Game : BaseEntity
    {
        public GameGenre Genre { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }
        public double IMDBScore { get; private set; }

        public Game(int id, GameGenre genre, string name, string description, int year, double iMDBScore)
        {
            Id = id;
            Genre = genre;
            Name = name;
            Description = description;
            Year = year;
            IMDBScore = iMDBScore;
        }

        public string ToString(bool getAllInformation)
        {
            
            string _return = string.Empty;
            if (getAllInformation) { 
                _return += "Gênero: " + this.Genre + Environment.NewLine;
                _return += "Nome: " + this.Name + Environment.NewLine;
                _return += "Descrição: " + this.Description + Environment.NewLine;
                _return += "Ano: " + this.Year + Environment.NewLine;
                _return += "Nota no IMDB: " + this.IMDBScore + Environment.NewLine;
                _return += "Registro criado em: " + base.CreatedAt.ToString("dd/MM/yyyy");
                _return += (base.UpdatedAt.HasValue ? Environment.NewLine + "Registro atualizado em: " + base.UpdatedAt.Value.ToString("dd/MM/yyyy") : string.Empty);
                _return += (base.IsDeleted ? Environment.NewLine + "*EXCLUÍDO*" : string.Empty);
            }
            else
            {
                _return = string.Format("#ID {0}: - {1} {2}", Id, Name, (IsDeleted ? "*EXCLUÍDO*" : ""));
            }

            return _return;
        }
    }
}
