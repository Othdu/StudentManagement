using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<product>? Products { get; set; }
    }
}
