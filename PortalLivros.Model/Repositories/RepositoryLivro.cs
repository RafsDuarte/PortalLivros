using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model.Repositories
{
    public class RepositoryLivro : IDisposable
    {
        private PortalLivrosEntities odb;
        private bool LiberaContexto = false;
        public RepositoryLivro()
        {
            odb = Helper.Data.getContexto();
            LiberaContexto = true;
        }

        public RepositoryLivro(PortalLivrosEntities _obd)
        {
            _obd = odb;
        }

        public LIVRO SelecionarNome(string Texto)
        {
            return (from p in odb.LIVRO where p.Texto.Contains(Texto) select p).FirstOrDefault();
        }

        public LIVRO SelecionarID(int ID)
        {
            return (from p in odb.LIVRO where p.ID == ID select p).FirstOrDefault();
        }

        //public AMIGO Selecionar(int ID)
        //{
        //    return (from p in odb.AMIGO where p.IDA == ID select p).FirstOrDefault();
        //}

        //public AMIGO Selecionar(int? ID)
        //{
        //    return (from p in odb.AMIGO where p.IDA == ID select p).FirstOrDefault();
        //}

        //public AMIGO VerificaLogin(string Email, string Senha)
        //{
        //    return (from p in odb.AMIGO where p.Email.Equals(Email) && p.Senha.Equals(Senha) select p).FirstOrDefault();
        //}
        //// ok
        //public List<AMIGO> SelecionarTodos(string amigo)
        //{
        //    if (amigo.Trim() == "")
        //    {
        //        return (from p in odb.AMIGO orderby p.Nome select p).ToList();
        //    }
        //    else
        //    {
        //        return (from p in odb.AMIGO where p.Nome.Contains(amigo) select p).ToList();
        //    }
        //}

        //public List<AMIGO> SelecionarTodosAmigos()
        //{
        //    return odb.AMIGO.OrderBy(p => p.Nome).ToList();
        //}

        //public List<AMIGO> ListarAmigos()
        //{
        //    return odb.AMIGO.OrderBy(p => p.Nome).ToList();
        //}

        public void Incluir(LIVRO oLivro)
        {
            odb.LIVRO.Add(oLivro);
            odb.SaveChanges();
        }

        public void Alterar(LIVRO oAmigo, bool attach = true)
        {
            if (attach)
            {
                odb.Entry(oAmigo).State = System.Data.Entity.EntityState.Modified;
            }
            odb.SaveChanges();
        }

        public void Excluir(LIVRO oAmigo)
        {
            odb.LIVRO.Attach(oAmigo);
            odb.LIVRO.Remove(oAmigo);
            odb.SaveChanges();
        }

        public List<LIVRO> ListarLivros()
        {
            return odb.LIVRO.OrderBy(p => p.ISBN).ToList();
        }

        public void Dispose()
        {
            if (LiberaContexto)
            {
                odb.Dispose();
            }
        }
    }
}
