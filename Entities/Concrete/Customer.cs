using Core.Entities;

namespace Entities.Concrete
{
    public class Customer : User, IEntity
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
