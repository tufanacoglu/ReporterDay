using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.EntityLayer.Entities
{
    //Class'ımız Internal olursa diğer katmanlardan ulaşım sağlanamaz, Public olursa diğer katmanlardan erişim sağlanabilir.
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Article> Articles { get; set; }
    }
}
