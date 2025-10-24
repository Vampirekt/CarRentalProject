using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDTO : IDto
    {
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
