using myfinance_web_dotnet_domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_dotnet_domain.Entities;

public class PlanoConta : EntityBase
{
    public string Descricao { get; set; }
    
    public string Tipo { get; set; }
}
