using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model.Helper
{
    public class Data
    {
        public static PortalLivrosEntities getContexto()
        {
            PortalLivrosEntities odb = new PortalLivrosEntities(); // instancia a conexão com o Banco de dados
            odb.Configuration.ProxyCreationEnabled = false; // desabilita o proxy
            return odb; // retorna a conexão com o bd
        }
    }
}
