using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rk1
{
    public class DetailSupplier
    {
        public int DetailId { get; set; }
        public int SupplierId { get; set; }

        public DetailSupplier(int detailId, int supplierId)
        {
            DetailId = detailId;
            SupplierId = supplierId;
        }
    }
}
