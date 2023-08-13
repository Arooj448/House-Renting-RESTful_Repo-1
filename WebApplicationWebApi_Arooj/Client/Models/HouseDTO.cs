namespace Client.Models
{
    using System.Text.Json.Serialization;

    
        public class HouseDTO
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("title")]
            public string? Title { get; set; }

            [JsonPropertyName("description")]
            public string? Description { get; set; }

            [JsonPropertyName("images")]
            public string? Images { get; set; }

            [JsonPropertyName("rent")]
            public decimal Rent { get; set; }

            [JsonPropertyName("isAvailable")]
            public bool IsAvailable { get; set; }
        
    }

}
