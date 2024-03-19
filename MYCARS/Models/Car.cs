using System.ComponentModel.DataAnnotations.Schema;

namespace MYCARS.Models
{
    public class Car
    {
        public int id { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public int raiting { get; set; }
        public string name { get; set; }

    }
}
