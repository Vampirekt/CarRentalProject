using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO: IDto
    {
        public string CompanyName { get; set; }
    }
}
