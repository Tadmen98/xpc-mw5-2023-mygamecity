﻿using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record GameResponseDTO : EntityBase
{
    public GameResponseDTO()
    {

    }

    public GameResponseDTO(GameEntity game)
    {
        Id = game.Id;
        Title = game.Title;
        ImagePath = game.ImagePath;
        Description = game.Description;
        Price = game.Price;
        Weight = game.Weight;
        NumberInStock = game.NumberInStock;

    }

    public string Title { get; set; } 
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Weight { get; set; }
    public int NumberInStock { get; set; }
    

}
