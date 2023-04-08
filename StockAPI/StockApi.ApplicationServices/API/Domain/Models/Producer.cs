namespace StockApi.ApplicationServices.API.Domain.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ProducersItems { get; set; }
    }
}
