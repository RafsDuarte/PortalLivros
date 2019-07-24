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

            [DisplayName("Nome")]
            public string Nome { get; set; }

            [DisplayName("Senha")]
            public string Senha { get; set; }

            [DisplayName("Email")]
            public string Email { get; set; }
        }
    }
}
