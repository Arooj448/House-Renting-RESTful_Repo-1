namespace WebApplicationWebApi_Arooj.Model
{
    public class House
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }  //house description
        public string? Images { get; set; } // You can store image URLs or paths
        public decimal Rent { get; set; }
        public bool IsAvailable { get; set; }
    }
}
