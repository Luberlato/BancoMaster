using BancoMaster.Applications.Conversão;
using BancoMaster.Domains;
using BancoMaster.DTOs.UsuarioDTO;
using BancoMaster.Exceptions;
using BancoMaster.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace BancoMaster.Applications.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        private static byte[] HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new DomainException("Senha é obrigatória.");
            }

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        public LerUsuarioDTO AdicionarUsuario(CadastrarUsuarioDto criarUsuario)
        {
            
            Usuario usuario = new Usuario
            {
                Nome = criarUsuario.Nome,
                Email = criarUsuario.Email,
                CPF = criarUsuario.CPF,
                Senha = HashSenha(criarUsuario.Senha)
            };

            return UsuarioParaDto.ConverterParaDto(usuario);

        }
    }
}
