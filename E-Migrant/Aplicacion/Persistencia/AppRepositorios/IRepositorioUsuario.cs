using System.Collections.Generic;
using Dominio.Entidades;


namespace Persistencia
{
    public interface IRepositorioUsuario
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario AddUsuario(Usuario usuario);
        Usuario UpdateUsuario(Usuario usuario);
        Usuario DeleteUsuario(int idUsuario);
        Usuario GetUsuario(string correo);
        Usuario GetUsuarioID(int idUsuario);
        Usuario ResgistrarUsuario(Usuario usuario);
         
    } 
}