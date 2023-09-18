using Domain.Company;
using Domain.CompanyCharacter;
using Dto.Company;
using Dto.CompanyCharacter;
using Orleans.Providers;

namespace Grains.Company;

[StorageProvider]
public class CompanyAggregateGrain: Grain<CompanyAggregateState>, ICompanyAggregateGrain
{
    public async Task<List<CompanyDto>> GetCompanies()
    {
        var ret = new List<CompanyDto>();

        foreach (var id in State.Ids)
        {
            ret.Add(await GrainFactory.GetGrain<ICompanyGrain>(id).GetCompany());
        }
        
        return ret;
    }

    public async Task<CompanyDto> NewCompany()
    {
        var id = Guid.NewGuid().ToString();
        State.Ids.Add(id);
        await WriteStateAsync();
        var company = GrainFactory.GetGrain<ICompanyGrain>(id);
        await company.Save();
        return await company.GetCompany();
    }

    public async Task AddCharacter(CompanyCharacterAddDto dto)
    {
        await GrainFactory.GetGrain<ICompanyCharacterGrain>(dto.CompanyId).AddCharacter(dto.CharacterId);
    }
}