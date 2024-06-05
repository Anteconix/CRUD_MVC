using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    /* 
    Classe: ClienteServico 
    Possui apenas métodos para realizar as operações
    sobre os dados deum cliente
    */
    public class ClienteServico
    {
        private IClienteRepositorio clienteRepositorio;
        public ClienteServico(IClienteRepositorio clienteRepositorio) 
        {
            this.clienteRepositorio = clienteRepositorio;
        }

        public void Inserir(ClienteDTO clienteDTO) 
        {
            var cliente = new Cliente(
                clienteDTO.Codigo,
                clienteDTO.Nome,
                clienteDTO.Email
                );

            clienteRepositorio.Adicionar(cliente);
        }

        public ClienteDTO Consultar(int codigo)
        {
            var cliente = clienteRepositorio.Consultar(codigo);
            if (cliente == null) return null;

            return new ClienteDTO
            {
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                Email = cliente.Email
            };
        }

        public void Alterar(ClienteDTO clienteDTO)
        {
            var cliente = clienteRepositorio.Consultar(
                clienteDTO.Codigo);
            if (cliente == null) throw new Exception(
                "Cliente não encontrado");

            cliente.Nome = clienteDTO.Nome;
            cliente.Email = clienteDTO.Email;
            clienteRepositorio.Atualizar(cliente);

        }

        public void Apagar(int codigo)
        {
            clienteRepositorio.Apagar(codigo);
        }
    }
}
