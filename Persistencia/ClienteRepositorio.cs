using Dominio;
using System.Reflection.Metadata;

namespace Persistencia
{
    /*
    Classe: ClienteRepositorio
    implementa todos os serviços descritos na interface
    (ICLienteRepositorio) da camada de controle
    */
    public class ClienteRepositorio : IClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void Adicionar(Cliente cliente)
        {
            // IRL haveria um Insert no BD
            // Lista apenas simulando o BD
            clientes.Add(cliente);
        }

        public void Apagar(int codigo)
        {
            // IRL haveria um Delete no BD
            // Lista apenas simulando o BD
            var cliente = this.Consultar(codigo);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }

        public void Atualizar(Cliente cliente)
        {
            /*
            Forma noob

            int x;
            for(x=-; x<clientes.Count; x++)
            {
                if (clientes[x].Codigo == cliente.Codigo)
                {
                    clientes[x].Nome = cliente.Nome;
                    clientes[x].Email = cliente.Email;
                }

            }
            */
            // Forma de gente
            var clienteExistente = this.Consultar(cliente.Codigo);
            if (clienteExistente != null)
            {
                clienteExistente
                    .GetType()
                    .GetProperty("Nome")
                    .SetValue(clienteExistente, cliente.Nome);
                clienteExistente
                    .GetType()
                    .GetProperty("Email")
                    .SetValue(clienteExistente, cliente.Email);
            }
        }

        public Cliente Consultar(int codigo)
        {
            return clientes.SingleOrDefault(cli => cli.Codigo == codigo);
        }
    }
}