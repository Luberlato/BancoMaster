using BancoMaster.Domains;

namespace BancoMaster.Interfaces
{
    public interface IUsuarioRepository
    {
        public void AdicionarUsuario(Usuario usuario);
        public void AtualizarUsuario(Usuario usuario);
        public void DeletarUsuario(int id);
        public Usuario? ObterUsuarioPorId(int id);
        public Usuario? ObterPorEmail(string email);
        public Usuario? ObterPorCpf(string cpf);
        public Usuario? ObterPorNome(string email);

    }
}
