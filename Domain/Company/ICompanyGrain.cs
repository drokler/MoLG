using Dto.Company;

namespace Domain.Company;

public interface ICompanyGrain : IGrainWithStringKey
{
    Task<CompanyDto> GetCompany();
    Task Save();
}