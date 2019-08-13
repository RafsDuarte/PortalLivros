using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model
{
    [MetadataType(typeof(MD_EDITORA))]
    public partial class EDITORA
    {
        internal class MD_EDITORA
        {
            [DisplayName("ID")]
            public int ID { get; set; }

            [DisplayName("Editora")]
            public string Editora { get; set; }
        }

    }
}
