using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model
{
    [MetadataType(typeof(MD_AUTOR))]
    public partial class AUTOR
    {
        internal class MD_AUTOR
        {
            [DisplayName("ID")]
            public int ID { get; set; }

            [DisplayName("Autor")]
            public string NomeAutor { get; set; }
        }

    }
}
