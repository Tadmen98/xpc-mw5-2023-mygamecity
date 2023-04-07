using MyGameCity.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.DataTransferObjects;

public record CategoryGameDto
{
    public Guid CategoryId { get; set; }
    public Guid SkillId { get; set; }
}
