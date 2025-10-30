using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CustomerDTOs
{
    public class CustomerDetailDTO: IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
}
