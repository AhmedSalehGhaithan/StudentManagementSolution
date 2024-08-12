using StudentManagementShared.CountryRepository;
using StudentManagementShared.Models;

using System.Net.Http;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class CountryService(HttpClient _httpClient) : ICountryRepository
    {
        private const string BaseAddress = "api/Countries";
        public async Task<CountryTable> AddCountryAsync(CountryTable country)
        {
            var newtudent = await _httpClient.PostAsJsonAsync($"{BaseAddress}/Add-Country", country);
            var response = await newtudent.Content.ReadFromJsonAsync<CountryTable>();
            return response!;
        }
        public async Task<CountryTable> DeleteCountryAsync(int countryId)
        {
            var delStudent = await _httpClient.DeleteAsync($"{BaseAddress}/Delete-Country/{countryId}");
            var response = await delStudent.Content.ReadFromJsonAsync<CountryTable>();
            return response!;
        }

        public async Task<List<CountryTable>> GetAllCountriesAsync()
        {
            var allStudent = await _httpClient.GetAsync($"{BaseAddress}/All-Countries");
            var response = await allStudent.Content.ReadFromJsonAsync<List<CountryTable>> ();
            return response!;
        }

        public async Task<CountryTable> GetCountryByIdAsync(int countryId)
        {
            var singleStudent = await _httpClient.GetAsync($"{BaseAddress}/Single-Country/{countryId}");
            var response = await singleStudent.Content.ReadFromJsonAsync<CountryTable> ();
            return response!;
        }

        public async Task<CountryTable> UpdateCountryAsync(CountryTable country)
        {
            var updateStudent = await _httpClient.PostAsJsonAsync($"{BaseAddress}/Update-Country/", country);
            var response = await updateStudent.Content.ReadFromJsonAsync<CountryTable> ();
            return response!;
        }

    }
}
