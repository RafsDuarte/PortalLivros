using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model.Repositories
{
    public class RepositoryEditora : IDisposable
    {
        private PortalLivrosEntities odb;
        private bool LiberaContexto = false;
        public RepositoryEditora()
        {
            odb = Helper.Data.getContexto();
            LiberaContexto = true;
        }

        public RepositoryEditora(PortalLivrosEntities _obd)
        {
            _obd = odb;
        }

        public void Incluir(EDITORA oEditora)
        {
            odb.EDITORA.Add(oEditora);
            odb.SaveChanges();
        }

        public void Alterar(EDITORA oEditora, bool attach = true)
        {
            if (attach)
            {
                odb.Entry(oEditora).State = System.Data.Entity.EntityState.Modified;
            }
            odb.SaveChanges();
        }

        public void Excluir(EDITORA oEditora)
        {
            odb.EDITORA.Attach(oEditora);
            odb.EDITORA.Remove(oEditora);
            odb.SaveChanges();
        }

        public List<EDITORA> ListarEditoras()
        {
            return odb.EDITORA.OrderBy(p => p.Editora).ToList();
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
