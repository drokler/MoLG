using Dto.Company;
using Dto.CompanyCharacter;

namespace Domain.Company;

public interface ICompanyAggregateGrain: IGrainWithIntegerKey
{
    Task<List<CompanyDto>> GetCompanies();
    Task<CompanyDto> NewCompany();
    Task AddCharacter(CompanyCharacterAddDto dto);
}