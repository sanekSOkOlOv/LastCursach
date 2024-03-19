namespace MYCARS.Models
{
    public class ReportViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Bike> Bikes { get; set; }
        public IEnumerable<Skateboard> Skateboards { get; set; }
    }

}
