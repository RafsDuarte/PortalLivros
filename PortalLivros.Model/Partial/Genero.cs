using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model
{
    [MetadataType(typeof(MD_GENERO))]
    public partial class GENERO
    {
        internal class MD_GENERO
        {
            [DisplayName("ID")]
            public int ID { get; set; }

            [DisplayName("Gênero")]
            public string NomeGenero { get; set; }
        }

    }
}
