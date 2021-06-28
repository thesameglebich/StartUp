using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Boolean Oplachen { get; set; }
        public Guid? PlaceId { get; set; }
        public Place Place { get; set; }
        public Int32 Price { get; set; }
        public DateTime Date { get; set; }
        public String PhoneCustomer {get;set;}
        public String NameCustomer { get; set; }
        public String Status { get; set; }
        public String Type { get; set; }
        public String Comment { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<OrderDish> OrderDishes { get; set; }
        //public ICollection<OrderAdd> OrderAdds { get; set; }

    }
}
