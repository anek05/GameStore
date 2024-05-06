using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = 
    [
        new(){
            Id = 1,
            Name = "Elden Ring",
            Genre = "Adventure",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2022, 01, 19)
        },
        new(){
            Id = 2,
            Name = "Guild Wars 2",
            Genre = "MMORPG",
            Price = 49.99M,
            ReleaseDate = new DateOnly(2012, 08, 22)
        },
        new(){
            Id = 3,
            Name = "ROcket League",
            Genre = "Sports",
            Price = 19.99M,
            ReleaseDate = new DateOnly(2013, 10, 05)
        }
    ];

    public GameSummary[] GetGames() => [.. games];
}
