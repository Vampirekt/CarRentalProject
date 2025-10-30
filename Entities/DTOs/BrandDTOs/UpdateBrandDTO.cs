using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BrandDTOs
{
    public class UpdateBrandDTO:IDto
    {
        public string Name { get; set; }
    }
}
