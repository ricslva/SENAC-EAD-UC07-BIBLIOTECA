using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                usuario.Login = u.Login;
                usuario.Senha = u.Senha;

                bc.SaveChanges();
            }
        }

        public void Excluir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                bc.Remove(usuario);
                bc.SaveChanges();
                
            }
        }

          public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        } 

          public Usuario ObterLogin(string Login, string Senha)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {                
                                                  
                return bc.Usuarios.Where(u => (u.Login.Equals(Login) && u.Senha.Equals(Senha))).FirstOrDefault();;

            }
        }

        public ICollection<Usuario> ListarTodos()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                                                   // caso filtro não tenha sido informado
                query = bc.Usuarios;
                             
                //ordenação padrão 
                return query.OrderBy(u => u.Login).ToList();
            }
        }
                      
    }
}