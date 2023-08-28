using Domain.Company;
using Orleans.Providers;

namespace Grains;

[StorageProvider]
public class CompanyGrain : Grain<CompanyState>, ICompanyGrain
{
    
    public Task ShowLog()
    {
        Console.WriteLine(State.Name);
        return Task.CompletedTask;
    }
}