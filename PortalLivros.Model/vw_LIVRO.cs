//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalLivros.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_LIVRO
    {
        public int ID { get; set; }
        public int IDGenero { get; set; }
        public int IDAutor { get; set; }
        public int IDEditora { get; set; }
        public string ISBN { get; set; }
        public System.DateTime DataPublicacao { get; set; }
        public string Titulo { get; set; }
        public string NomeGenero { get; set; }
        public string Editora { get; set; }
        public string NomeAutor { get; set; }
        public string Sinopse { get; set; }
        public string ImagemCaminho { get; set; }
    }
}