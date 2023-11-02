using Dto.Company;

namespace Domain.Company;

public interface ICompanyGrain : IGrainWithStringKey
{
    Task<CompanyDto> GetDto();
    Task Save();
    Task Update(CompanyUpdateDto dto);
}