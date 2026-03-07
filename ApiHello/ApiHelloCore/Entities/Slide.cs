using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelloCore.Entities
{
    public class Slide:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURl {  get; set; }
    }
}
