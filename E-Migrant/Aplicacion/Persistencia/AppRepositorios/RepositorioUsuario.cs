using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Dominio.Entidades;

namespace Persistencia
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly AppContext _appContext;
        public RepositorioUsuario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _appContext.Usuarios;
        }

        public Usuario AddUsuario(Usuario usuario)
        {

            var userDefault = "admin";
            var claveDefault = "12345$";
            var usuarioAdicionado = _appContext.Usuarios.Add(usuario);
            usuarioAdicionado.Entity.User = userDefault;
            usuarioAdicionado.Entity.Contrasena = claveDefault;

            _appContext.SaveChanges();
            return usuarioAdicionado.Entity;
        }

        public Usuario ResgistrarUsuario(Usuario usuario)
        {
            var usuarioAdicionado = _appContext.Usuarios.Add(usuario);

            _appContext.SaveChanges();
            return usuarioAdicionado.Entity;
        }

        public Usuario DeleteUsuario(int idUsuario)
        {
            var usuarioEncontrado = _appContext.Usuarios.FirstOrDefault(m => m.Id == idUsuario);
            if (usuarioEncontrado == null)
                return null;
            _appContext.Usuarios.Remove(usuarioEncontrado);
            _appContext.SaveChanges();
            return usuarioEncontrado;
        }

        Usuario IRepositorioUsuario.GetUsuario(string correo)
        {

            var usuarioEncontrado = _appContext.Usuarios.FirstOrDefault(c => c.Correo == correo);
            return usuarioEncontrado;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            var usuarioEncontrado = _appContext.Usuarios.FirstOrDefault(m => m.Id == usuario.Id);
            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.User = usuario.User;
                usuarioEncontrado.Rol = usuario.Rol;
                usuarioEncontrado.Correo = usuario.Correo;
                usuarioEncontrado.Contrasena = usuario.Contrasena;

                _appContext.SaveChanges();
            }
            return usuarioEncontrado;
        }

        // public Usuario AsignarMigrante(Usuario usuario)
        // {
        //   _appContext.Entry(usuario).State=EntityState.Modified;
        //   _appContext.SaveChanges();
        //   return usuario;
        // }

        // public Usuario UpdateAsignarMigrante(Usuario usuario)
        // {
        //     _appContext.Entry(usuario).State=EntityState.Modified;
        //   _appContext.SaveChanges();
        //   return usuario;
        // }

        Usuario IRepositorioUsuario.GetUsuarioID(int idUsuario){
            return _appContext.Usuarios.FirstOrDefault(c => c.Id == idUsuario);
            
        }


    }
}