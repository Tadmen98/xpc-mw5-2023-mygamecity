using MyGameCity.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.DataTransferObjects;

public record GameDto : EntityBase
{
    public required string Name { get; init; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public int Weight { get; set; }
    public int NumberInStock { get; set; }
    //public ICollection<CategoryEntity> Category { get; set; }
    //public ManufacturerEntity Developer { get; set; }
    //public ManufacturerEntity Publisher { get; set; }
    public List<Guid> ReviewIds { get; set; }

}
