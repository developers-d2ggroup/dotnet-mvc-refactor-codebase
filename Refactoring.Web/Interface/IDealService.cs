using System;

namespace Refactoring.Web.Services
{
    public interface IDealService
    {
        decimal GenerateDeal(DateTime dateTime);
        string GetRandomLocalBusiness();
    }
}