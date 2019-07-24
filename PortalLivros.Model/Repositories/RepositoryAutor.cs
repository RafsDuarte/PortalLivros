using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model.Repositories
{
    public class RepositoryAutor
    {
        private PortalLivrosEntities odb;
        private bool LiberaContexto = false;
        public RepositoryAutor()
        {
            odb = Helper.Data.getContexto();
            LiberaContexto = true;
        }

        public RepositoryAutor(PortalLivrosEntities _obd)
        {
            _obd = odb;
        }

        public void Incluir(AUTOR oAutor)
        {
            odb.AUTOR.Add(oAutor);
            odb.SaveChanges();
        }

        public void Alterar(AUTOR oAutor, bool attach = true)
        {
            if (attach)
            {
                odb.Entry(oAutor).State = System.Data.Entity.EntityState.Modified;
            }
            odb.SaveChanges();
        }

        public void Excluir(AUTOR oAutor)
        {
            odb.AUTOR.Attach(oAutor);
            odb.AUTOR.Remove(oAutor);
            odb.SaveChanges();
        }

        public List<AUTOR> ListarAutores()
        {
            return odb.AUTOR.OrderBy(p => p.NomeAutor).ToList();
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
