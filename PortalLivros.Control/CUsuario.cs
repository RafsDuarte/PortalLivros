using PortalLivros.Model;
using PortalLivros.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Control
{
    public class CUsuario : IDisposable
    {
        RepositoryUsuario _Repository;

        public CUsuario()
        {
            _Repository = new RepositoryUsuario();
        }

        public void Incluir(USUARIO oUsuario)
        {
            _Repository.Incluir(oUsuario);
        }

        public void Dispose()
        {
            _Repository.Dispose();
        }

    }
}
