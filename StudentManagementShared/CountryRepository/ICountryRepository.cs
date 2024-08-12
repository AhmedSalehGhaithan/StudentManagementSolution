using StudentManagementShared.Models;

namespace StudentManagementShared.CountryRepository
{
    public interface ICountryRepository
    {
        Task<CountryTable> AddCountryAsync(CountryTable country);
        Task<CountryTable> UpdateCountryAsync(CountryTable country);
        Task<CountryTable> DeleteCountryAsync(int countryId);
        Task<List<CountryTable>> GetAllCountriesAsync();
        Task<CountryTable> GetCountryByIdAsync(int countryId);
    }
}
