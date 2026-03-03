using System;
using System.Collections.Generic;

namespace BancoMaster.Domains;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string CPF { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public virtual ICollection<Conta> Conta { get; set; } = new List<Conta>();

    public virtual ICollection<Transacao> TransacaoEnviador { get; set; } = new List<Transacao>();

    public virtual ICollection<Transacao> TransacaoRepecetor { get; set; } = new List<Transacao>();
}
