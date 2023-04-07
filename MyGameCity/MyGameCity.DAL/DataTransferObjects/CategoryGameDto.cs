using MyGameCity.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.DataTransferObjects;

public record CategoryGameDto
{
    public Guid GameId { get; set; }
    public Guid CategoryId { get; set; }
}
