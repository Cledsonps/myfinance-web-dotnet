using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service.Interfaces
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;   
        public TransacaoService(MyFinanceDbContext dbContext)
        {
            // Inicializa o contexto do banco de dados
            _dbContext = dbContext;
        }        

        public void Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;

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
            var transacao = new Transacao { Id = Id };
            _dbContext.Attach(transacao);
            _dbContext.Remove(transacao);
            _dbContext.SaveChanges(); 
        }

        public List<Transacao> ListarRegistros()
        {
            var lista = _dbContext.Transacao.Include(x => x.PlanoConta).ToList();
            return lista;
        }

        public Transacao RetornarRegistro(int Id)
        {
            return _dbContext.Transacao.FirstOrDefault(x => x.Id == Id);
            // if (Id == 0)
            // {
            //     // Lança uma exceção se o ID não for válido
            //     throw new ArgumentException("O ID não pode ser zero.");
            // }else
            // {
            //     // Retorna um registro de plano de conta específico com base no ID
            //     return _dbContext.Transacao.FirstOrDefault(x => x.Id == Id);
            // }
        }

    }
}