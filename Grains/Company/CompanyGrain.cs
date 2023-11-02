using Domain.Company;
using Dto.Company;
using Orleans.Providers;

namespace Grains.Company;

[StorageProvider]
public class CompanyGrain : Grain<CompanyState>, ICompanyGrain
{
    
    public Task ShowLog()
    {
        Console.WriteLine(State.Name);
        return Task.CompletedTask;
    }

    public Task<CompanyDto> GetDto()
    {
        return Task.FromResult(new CompanyDto()
        {
            Id = this.GetPrimaryKeyString(),
            Name = State.Name
        });
    }

    public async Task Save()
    {
        await WriteStateAsync();
    }

    public async Task Update(CompanyUpdateDto dto)
    {
        State.Name = dto.Name;
        await WriteStateAsync();
    }
}