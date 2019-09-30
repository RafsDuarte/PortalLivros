using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model
{
    [MetadataType(typeof(MD_USUARIO))]
    public partial class USUARIO
    {
        internal class MD_USUARIO
        {
            [DisplayName("ID")]
            public int ID { get; set; }

            [DisplayName("Usuário")]
            public string Usuario { get; set; }

            [DisplayName("Senha")]
            public string Senha { get; set; }

            [DisplayName("Role")]
            public string Role { get; set; }
        }
    }
}
