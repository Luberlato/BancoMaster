using BancoMaster.Contexts;
using BancoMaster.Domains;
using BancoMaster.Interfaces;

namespace BancoMaster.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoMasterContext _context;
        public UsuarioRepository(BancoMasterContext context)
        {
            _context = context;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
        public void AtualizarUsuario(Usuario usuario)
        {
            Usuario usuarioBanco = _context.
                Usuario.FirstOrDefault(usuarioAux => usuarioAux.UsuarioId == usuario.UsuarioId);
            if (usuarioBanco != null)
            {
                return;
            }
            
            usuarioBanco.CPF = usuario.CPF;
            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Senha = usuario.Senha;

            _context.SaveChanges();
        }

        public void DeletarUsuario(int id)
        { 
            Usuario usuarioAux = _context.Usuario.FirstOrDefault(usuario => usuario.UsuarioId == id);
            _context.Usuario.Remove(usuarioAux);
            _context.SaveChanges();
        }

        public Usuario? ObterUsuarioPorId(int id)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.UsuarioId == id);
        }

        public Usuario? ObterPorEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.Email == email);
        }

        public Usuario? ObterPorCpf(string cpf)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.CPF == cpf);
        }

        public Usuario? ObterPorNome(string nome)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.Nome == nome);
        }





    }
}
