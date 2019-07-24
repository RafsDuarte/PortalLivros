using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model.Repositories
{
    public class RepositoryUsuario : IDisposable
    {
        private PortalLivrosEntities odb;
        private bool LiberaContexto = false;
        public RepositoryUsuario()
        {
            odb = Helper.Data.getContexto();
            LiberaContexto = true;
        }

        public RepositoryUsuario(PortalLivrosEntities _obd)
        {
            _obd = odb;
        }

        public USUARIO SelecionarID(int ID)
        {
            return (from p in odb.USUARIO where p.ID == ID select p).FirstOrDefault();
        }

        //public USUARIO VerificaLogin(string Email, string Senha)
        //{
        //    return (from p in odb.USUARIO where p.Email.Equals(Email) && p.Senha.Equals(Senha) select p).FirstOrDefault();
        //}

        public void Incluir(USUARIO oUsuario)
        {
            odb.USUARIO.Add(oUsuario);
            odb.SaveChanges();
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
