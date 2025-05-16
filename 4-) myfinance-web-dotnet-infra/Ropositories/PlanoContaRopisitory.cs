using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Repositories;

namespace myfinance_web_dotnet_infra.Ropositories
{
    public class PlanoContaRopisitory : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRopisitory(MyFinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
