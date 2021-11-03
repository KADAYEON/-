using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 가게관리_최종
{
    class Reservation
    {
        public string ProductName { get; set; } //품목 이름
        public string Name { get; set; } //담당자 이름
        public string Isbn { get; set; } //품목 번호
        public bool Buy { get; set; }//결제 여부
        public string BuyName { get; set; }//고객성함
        public DateTime PickUp { get; set; } //픽업날짜
    }
}
