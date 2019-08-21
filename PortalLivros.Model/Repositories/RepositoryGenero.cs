using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model.Repositories
{
    public class RepositoryGenero : IDisposable
    {
        private PortalLivrosEntities odb;
        private bool LiberaContexto = false;
        public RepositoryGenero()
        {
            odb = Helper.Data.getContexto();
            LiberaContexto = true;
        }

        public RepositoryGenero(PortalLivrosEntities _obd)
        {
            _obd = odb;
        }


        public void Incluir(GENERO oGenero)
        {
            odb.GENERO.Add(oGenero);
            odb.SaveChanges();
        }

        public void Alterar(GENERO oGenero, bool attach = true)
        {
            if (attach)
            {
                odb.Entry(oGenero).State = System.Data.Entity.EntityState.Modified;
            }
            odb.SaveChanges();
        }

        public void Excluir(GENERO oGenero)
        {
            odb.GENERO.Attach(oGenero);
            odb.GENERO.Remove(oGenero);
            odb.SaveChanges();
        }


        public List<GENERO> ListarGeneros()
        {
            return odb.GENERO.OrderBy(p => p.NomeGenero).ToList();
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
