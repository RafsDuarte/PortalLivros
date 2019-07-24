using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Model
{
    [MetadataType(typeof(MD_vw_LIVRO))]
     public partial class vw_LIVRO
    {
        internal class MD_vw_LIVRO
        {
            [DisplayName("ID")]
            public int ID { get; set; }

            [DisplayName("ISBN")]
            public string ISBN { get; set; }

            [DisplayName("Imagem")]
            public byte ImagemCaminho { get; set; }

            [DisplayName("Data de Publicação")]
            public DateTime DataPublicacao { get; set; }

            [DisplayName("Título")]
            public string Titulo { get; set; }

            [DisplayName("Editora")]
            public string Editora { get; set; }

            [DisplayName("Autor")]
            public string NomeAutor { get; set; }

            [DisplayName("Gênero")]
            public string NomeGenero { get; set; }

            [DisplayName("Sinopse")]
            public string Sinopse { get; set; }
        }

    }
}
