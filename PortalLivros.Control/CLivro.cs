using PortalLivros.Model;
using PortalLivros.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLivros.Control
{
    public class CLivro : IDisposable
    {
        RepositoryLivro _Repository;

        public CLivro()
        {
            _Repository = new RepositoryLivro();
        }

        public void Incluir(LIVRO oLivro)
        {
            _Repository.Incluir(oLivro);
        }

        public void Alterar(LIVRO oLivro, bool attach = true)
        {
            _Repository.Alterar(oLivro, attach);
        }

        public void Excluir(LIVRO oLivro)
        {
            _Repository.Excluir(oLivro);
        }

        public LIVRO SelecionarID(int ID)
        {
            return _Repository.SelecionarID(ID);
        }

        public void Dispose()
        {
            _Repository.Dispose();
        }
    }
}
