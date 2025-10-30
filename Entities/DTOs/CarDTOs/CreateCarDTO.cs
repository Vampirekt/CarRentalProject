using Core.Entities;

namespace Entities.DTOs.CarDTOs
{
    public class CreateCarDTO : IDto
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
