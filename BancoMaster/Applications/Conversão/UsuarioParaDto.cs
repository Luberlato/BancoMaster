using BancoMaster.Domains;
using BancoMaster.DTOs.UsuarioDTO;

namespace BancoMaster.Applications.Conversão
{
    public class UsuarioParaDto
    {
        public static LerUsuarioDTO ConverterParaDto(Usuario usuario)
        {
            LerUsuarioDTO LerUsuario = new LerUsuarioDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF
            };
            return LerUsuario;

        }
    }
}
