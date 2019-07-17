using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model.Partial
{
    [MetadataType(typeof(MD_LIVRO))]
    public partial class LIVRO
    {
        internal class MD_LIVRO
        {
            [DisplayName("ID")]
            public int ID { get; set; }

            [DisplayName("ISBN")]
            public string ISBN { get; set; }

            [DisplayName("Imagem")]
            public byte ImagemCapa { get; set; }

            [DisplayName("Data de Publicação")]
            public DateTime DataPublicacao { get; set; }

            [DisplayName("Título")]
            public string Titulo { get; set; }

            [DisplayName("Editora")]
            public string Editora { get; set; }

            [DisplayName("Autor")]
            public string Autor { get; set; }

            [DisplayName("Texto")]
            public string Texto { get; set; }
        }
    }
}
