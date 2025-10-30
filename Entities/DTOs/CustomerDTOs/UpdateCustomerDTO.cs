using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CustomerDTOs
{
    public class UpdateCustomerDTO: IDto
    {
        public string CompanyName { get; set; }
    }
}
