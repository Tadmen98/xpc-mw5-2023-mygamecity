using MyGameCity.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.DataTransferObjects;

public record ManufacturerDto : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoImg { get; set; }
    public string CountryOfOrigin { get; set; } //TODO: replace with class not string
    public List<Guid> ComodityList { get; set; }
}
