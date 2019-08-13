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

        public LIVRO SelecionarNome(string Sinopse)
        {
            return (from p in odb.LIVRO where p.Sinopse.Contains(Sinopse) select p).FirstOrDefault();
        }

        public LIVRO SelecionarID(int ID)
        {
            return (from p in odb.LIVRO where p.ID == ID select p).FirstOrDefault();
        }

        public void Incluir(LIVRO oLivro)
        {
            odb.LIVRO.Add(oLivro);
            odb.SaveChanges();
        }

        public void Alterar(LIVRO oLivro, bool attach = true)
        {
            if (attach)
            {
                odb.Entry(oLivro).State = System.Data.Entity.EntityState.Modified;
            }
            odb.SaveChanges();
        }

        public void Excluir(LIVRO oLivro)
        {
            odb.LIVRO.Attach(oLivro);
            odb.LIVRO.Remove(oLivro);
            odb.SaveChanges();
        }

        public List<vw_LIVRO> ListarLivros()
        {
            return odb.vw_LIVRO.OrderBy(p => p.ISBN).ToList();
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
