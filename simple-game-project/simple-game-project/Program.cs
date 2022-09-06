using simple_game_project.Entities;
using simple_game_project.Enum;
using simple_game_project.Repositories;
using System.Xml.Linq;

class Program
{

    static GameRepository _repository = new GameRepository();

    static void Main(string[] args)
    {
        Seed();

        string userOption = GetUserOptions();

        while (userOption != "X")
        {
            switch (userOption)
            {
                case "1":
                    GetAllGames();
                    break;
                case "2":
                    AddGame();
                    break;
                case "3":
                    UpdateGame();
                    break;
                case "4":
                    DeleteGame();
                    break;
                case "5":
                    ViewGame();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            userOption = GetUserOptions();
        }

        Console.WriteLine("OBRIGADO!!!! VOLTE SEMPRE =]");
        Console.ReadLine();
    }

    private static void GetAllGames()
    {
        Console.WriteLine("Lista com todos games cadastrados");
        Console.WriteLine("--------------------------------");

        var games = _repository.GetAll();
        if (games.Any())
        {
            foreach (var game in games)
            {
                Console.WriteLine(game.ToString(false));
            }
        }
        else
        {
            Console.WriteLine("Nenhum game cadastrado.");
            return;
        }

        Console.WriteLine("--------------------------------");
    }

    private static void ViewGame()
    {
        Console.Write("Digite o id do game: ");
        int gameId = int.Parse(Console.ReadLine());

        var game = _repository.GetById(gameId);
        Console.WriteLine("--------------------------------");
        Console.WriteLine(game.ToString(true));
        Console.WriteLine("--------------------------------");
    }

    private static void DeleteGame()
    {
        Console.Write("Digite o id do game: ");
        int gameId = int.Parse(Console.ReadLine());

        _repository.Delete(gameId);
    }

    private static void AddGame()
    {
        Console.WriteLine("Inserir novo Game");
        _repository.Add(AddUpdateGame());
    }

    private static void UpdateGame()
    {
        Console.Write("Digite o id do Game: ");
        int gameId = int.Parse(Console.ReadLine());

        Console.WriteLine("Atualizar Game");
        _repository.Update(gameId, AddUpdateGame());
    }

    private static Game AddUpdateGame()
    {
        foreach (int i in Enum.GetValues(typeof(GameGenre)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GameGenre), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int genreOption = int.Parse(Console.ReadLine());

        Console.Write("Digite o Nome do Game: ");
        string name = Console.ReadLine();

        Console.Write("Digite o Ano de Lançamento do Game: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição do Game: ");
        string description = Console.ReadLine();

        Console.Write("Digite a nota do IMDB do Game: ");
        double IMDB = double.Parse(Console.ReadLine());

        return new Game(_repository.NextId(), (GameGenre)genreOption, name, description, year, IMDB);
    }

    private static string GetUserOptions()
    {
        Console.WriteLine();
        Console.WriteLine("SIMPLE GAME PROJECT");
        Console.WriteLine("Selecione uma opção:");

        Console.WriteLine("1- Listar games");
        Console.WriteLine("2- Inserir novo game");
        Console.WriteLine("3- Atualizar game");
        Console.WriteLine("4- Excluir game");
        Console.WriteLine("5- Visualizar game");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string userOption = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return userOption;
    }

    private static void Seed()
    {
        _repository.Add(new Game
        (
            _repository.NextId(),
            GameGenre.RPG,
            "Chrono Trigger", 
            "Crono, a young boy, is thrust to adventure by destiny to destroy an oncoming threat that will destroy the world in 1999.",
            1995,
            9.5
        ));

        _repository.Add(new Game
       (
            _repository.NextId(),
           GameGenre.RPG,
           "Pokémon Fire Red",
           "A Pokémon trainer adventures through the Kanto Region to achieve their destiny of becoming a Pokemon Champion.",
           2004,
           8.7
       ));

        _repository.Add(new Game
       (
            _repository.NextId(),
           GameGenre.HacknSlash,
           "God of War II",
           "After being betrayed by the gods of Olympus and annulled of his divine powers, Kratos must embark on a journey to meet the Sisters of Fate and take his revenge on Olympus.",
           2007,
           9.2
       ));
    }

}