using System;
using System.Collections.Generic;

namespace BancoMaster.Domains;

public partial class Transacao
{
    public int TransacaoId { get; set; }

    public int? EnviadorId { get; set; }

    public int? RepecetorId { get; set; }

    public decimal? Valor { get; set; }

    public virtual Usuario? Enviador { get; set; }

    public virtual Usuario? Repecetor { get; set; }
}
