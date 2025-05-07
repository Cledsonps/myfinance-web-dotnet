using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_dotnet_domain.Entities;

public class PlanoConta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string Descricao { get; set; }
    
    public string Tipo { get; set; }
}
