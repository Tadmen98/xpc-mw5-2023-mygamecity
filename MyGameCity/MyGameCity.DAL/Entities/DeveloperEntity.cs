﻿using MyGameCity.DAL.DTO;

namespace MyGameCity.DAL.Entities;

public record DeveloperEntity : EntityBase
{
    public DeveloperEntity()
    {

    }

    public DeveloperEntity(DeveloperDTO entity)
    {
        Title = entity.Title;
        Description = entity.Description;
        LogoImg = entity.LogoImg;
        CountryOfOrigin = entity.CountryOfOrigin;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoImg { get; set; }
    public string CountryOfOrigin { get; set;} //TODO: replace with class not string
    public List<GameEntity> GameList { get; set; }
}
