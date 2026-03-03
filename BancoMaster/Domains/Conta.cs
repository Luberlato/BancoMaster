using System;
using System.Collections.Generic;

namespace BancoMaster.Domains;

public partial class Conta
{
    public int ContaId { get; set; }

    public int? UsuarioId { get; set; }

    public decimal Saldo { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
