using System.ComponentModel.DataAnnotations;

namespace simple_game_project.Enum
{
    public enum GameGenre
    {
        FPS,
        RPG,
        Action,
        [Display(Name = "Beat'em Up")]
        BeatemUp,
        [Display(Name = "Hack'n Slash")]
        HacknSlash
    }
}
