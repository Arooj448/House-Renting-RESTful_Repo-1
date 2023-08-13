using Client.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Client.Services
{
    public class HouseService
    {
        private readonly HttpClient _httpClient;

        public HouseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7118"); // Replace with your Web API URL
        }

        //public async Task<IEnumerable<HouseDTO>> GetHousesAsync()
        //{
        //    var response = await _httpClient.GetAsync("/api/Houses");

        //    response.EnsureSuccessStatusCode();

        //    var content = await response.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<IEnumerable<HouseDTO>>(content);
        //}




        public async Task<HouseDTO> GetHouseAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Houses/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<HouseDTO>(content);
        }

        public async Task<IEnumerable<HouseDTO>> GetHousesAsync()
        {
            var response = await _httpClient.GetAsync("/api/Houses");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var houses = JsonSerializer.Deserialize<IEnumerable<HouseDTO>>(content);
            return houses ?? Enumerable.Empty<HouseDTO>();
        }


        public async Task<HouseDTO> CreateHouseAsync(HouseDTO house)
        {
            var houseJson = JsonSerializer.Serialize(house);
            var content = new StringContent(houseJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Houses", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<HouseDTO>(responseContent);
        }

        public async Task UpdateHouseAsync(HouseDTO house)
        {
            var houseJson = JsonSerializer.Serialize(house);
            var content = new StringContent(houseJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/api/Houses/{house.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteHouseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Houses/{id}");
            response.EnsureSuccessStatusCode();
        }


    }



}
