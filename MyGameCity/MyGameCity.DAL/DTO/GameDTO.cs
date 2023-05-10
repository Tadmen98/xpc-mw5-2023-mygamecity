﻿using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record GameDTO : EntityBase
{
    public GameDTO()
    {
        
    }

    public GameDTO(GameEntity game)
    {
        Id = game.Id;
        Title = game.Title;
        ImagePath = game.ImagePath;
        Description = game.Description;
        Price = game.Price;
        Weight = game.Weight;
        NumberInStock = game.NumberInStock;
        //Category = game.Category;
        //Developer = game.Developer;
    }

    public string Title { get; init; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Weight { get; set; }
    public int NumberInStock { get; set; }
    public List<Guid> CategoryIds { get; set; }
    public Guid DeveloperId { get; set; }
    //public List<ReviewEntity> Reviews { get; set; }

}
