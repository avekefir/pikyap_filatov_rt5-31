using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rk1
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }

        public Detail(int id, string name, decimal price, int supplierId)
        {
            Id = id;
            Name = name;
            Price = price;
            SupplierId = supplierId;
        }
    }
}
