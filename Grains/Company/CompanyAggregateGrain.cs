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
        var tasks = State.Ids.Select(async id => await GrainFactory.GetGrain<ICompanyGrain>(id).GetDto()).ToList();
        await Task.WhenAll(tasks);
        
        return tasks.Select(t => t.Result).ToList();
    }

    public async Task<CompanyDto> NewCompany()
    {
        var id = Guid.NewGuid().ToString();
        State.Ids.Add(id);
        await WriteStateAsync();
        var company = GrainFactory.GetGrain<ICompanyGrain>(id);
        await company.Save();
        return await company.GetDto();
    }

    public async Task AddCharacter(CompanyCharacterAddDto dto)
    {
        await GrainFactory.GetGrain<ICompanyCharacterGrain>(dto.CompanyId).AddCharacter(dto.CharacterId);
    }

    public async Task<CompanyDto> Update(CompanyUpdateDto dto)
    {
        var company = GrainFactory.GetGrain<ICompanyGrain>(dto.Id);
        await company.Update(dto);
        return await company.GetDto();
    }
}