﻿using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Exceptions;
//using MyGameCity.DataModel;

namespace MyGameCity.DAL.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;
        public GameService(DataContext context)
        {
            _context = context;
        }
        public GameEntity AddGame(GameDTO game_dto)
        {
            var game_check = _context.Game.Where(c => c.Id == game_dto.Id).FirstOrDefault();
            if (game_check != null)
            {
                throw new AlreadyExistException($"Game {game_dto.Id} already exists");
            }
            List<CategoryEntity> categories = _context.Categories.Where(c => game_dto.CategoryIds.Contains(c.Id)).ToList();
            if (!categories.Any())
            {
                throw new NotFoundException($"Categories were not found");
            }
            var developer = _context.Developer.Where(c => c.Id == game_dto.DeveloperId).FirstOrDefault();
            if (developer == null)
            {
                throw new NotFoundException($"Review {game_dto.DeveloperId} was not found");
            }
            var game = new GameEntity(game_dto) {Category = categories, Developer = developer};
            _context.Game.Add(game);
            _context.SaveChanges();
            //var gam = new GameEntity() { Title="sdfsd"};
            return game;
        }

        public GameEntity DeleteGame(Guid id)
        {
            var game = _context.Game.Find(id);
            if (game is null)
            {
                throw new NotFoundException($"Game {id} was not found");
            }

            _context.Game.Remove(game);
            _context.SaveChanges();
            return game;
        }

        public List<GameEntity> GetAllGames()
        {
            var games = _context.Game.ToList();
            return games;
        }

        public GameEntity GetGameById(Guid id)
        {
            var game = _context.Game.Where(c => c.Id == id).FirstOrDefault();
            if (game is null)
            {
                throw new NotFoundException($"Game {id} was not found");
            }
            return game;
        }

        public GameEntity UpdateGame(GameDTO game_dto)
        {
            var game = _context.Game.Find(game_dto.Id);
            if (game == null)
            {
                throw new NotFoundException($"Game {game_dto.Id} was not found");
            }
            game.Id = game_dto.Id;
            game.Title = game_dto.Title;
            game.ImagePath = game_dto.ImagePath;
            game.Description = game_dto.Description;
            game.Price = game_dto.Price;
            game.Weight = game_dto.Weight;
            game.NumberInStock = game_dto.NumberInStock;

            _context.SaveChanges();
            return game;
        }
    }
}
