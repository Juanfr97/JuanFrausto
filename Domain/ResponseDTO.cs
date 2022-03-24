using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ResponseDTO
    {
        public List<Product> Products { get; set; }
        public int Total { get; set; }
    }
}
