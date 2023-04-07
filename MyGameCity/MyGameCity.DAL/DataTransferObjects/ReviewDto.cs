using MyGameCity.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.DataTransferObjects;

public record ReviewDto : EntityBase
{
    public int StarsCount { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid GameId { get; set; }
}
