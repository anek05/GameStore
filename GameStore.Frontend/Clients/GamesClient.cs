﻿using GameStore.Frontend.Models;

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
            Name = "Rocket League",
            Genre = "Sports",
            Price = 19.99M,
            ReleaseDate = new DateOnly(2013, 10, 05)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }


    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var genre = genres.Single(genre => genre.Id == int.Parse(id));
        return genre;
    }
}
