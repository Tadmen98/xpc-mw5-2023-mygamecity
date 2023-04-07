using MyGameCity.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.DataTransferObjects;

public record CategoryDto : EntityBase
{
    public string Name { get; set; }
    public List<Guid> Games { get; set; }
}