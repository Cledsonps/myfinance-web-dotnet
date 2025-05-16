using myfinance_web_dotnet_domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_dotnet_domain.Entities;

public class Transacao : EntityBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Historico { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public int PlanoContaId { get; set; }
    public PlanoConta PlanoConta { get; set; }
}
