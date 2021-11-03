using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 가게관리_최종
{
    class Product
    {
        public string Isbn { get; set; }
        public string ProductName { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public bool IsNeeded { get; set; }
        public bool Reservation { get; set; }
        public DateTime At { get; set; }

    }
}
