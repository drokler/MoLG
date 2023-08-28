namespace Domain.Company;

public interface ICompanyGrain : IGrainWithStringKey
{
    Task ShowLog();
}