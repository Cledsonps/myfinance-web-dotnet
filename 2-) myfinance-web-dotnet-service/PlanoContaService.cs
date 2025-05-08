using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service.Interfaces
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbContext;   
        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            // Inicializa o contexto do banco de dados
            _dbContext = dbContext;
        }

        public void Cadastrar(PlanoConta Entidade)
        {
            var dbSet = _dbContext.PlanoConta;

            if  (Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else
            {
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var planoConta = new PlanoConta { Id = Id };
            _dbContext.Attach(planoConta);
            _dbContext.Remove(planoConta);
            _dbContext.SaveChanges();      
        }

        public List<PlanoConta> ListarRegistros()
        {
            return _dbContext.PlanoConta.ToList();
        }

        public PlanoConta RetornarRegistr(int Id)
        {
            return _dbContext.PlanoConta.FirstOrDefault(x => x.Id == Id);
        }

    }
}