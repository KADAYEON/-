using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 가게관리_최종
{
    class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Attend { get; set; }
        public DateTime AttendTime { get; set; }
    }
}
