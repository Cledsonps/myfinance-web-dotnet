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
            // Adiciona a entidade ao contexto do banco de dados
            var dbSet = _dbContext.Transacao;
            if  (dbSet == null)
            {
                dbSet.Add(Entidade);
            }
            // Altera a entidade ao contexto do banco de dados
            else
            {
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }
            // Salva as alterações no banco de dados
            _dbContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            // Verifica se o ID é válido
            if(Id != 0)
            {
                // Remove a entidade do contexto do banco de dados
                var transacao = new Transacao { Id = Id };
                _dbContext.Attach(transacao);
                _dbContext.Remove(transacao);
                _dbContext.SaveChanges();                
            }
            else
            {
                // Lança uma exceção se o ID não for válido
                throw new ArgumentException("O ID não pode ser zero.");
            }
        }

        public List<Transacao> ListarRegistros()
        {
            // Retorna todos os registros de plano de conta do banco de dados
            return _dbContext.Transacao.ToList();
        }

        public Transacao RetornarRegistr(int Id)
        {
            if (Id == 0)
            {
                // Lança uma exceção se o ID não for válido
                throw new ArgumentException("O ID não pode ser zero.");
            }else
            {
                // Retorna um registro de plano de conta específico com base no ID
                return _dbContext.Transacao.FirstOrDefault(x => x.Id == Id);
            }
        }

    }
}