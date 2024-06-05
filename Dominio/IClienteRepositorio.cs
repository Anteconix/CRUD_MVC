using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IClienteRepositorio
    {
        void Adicionar(Cliente cliente);
        Cliente Consultar(int codigo);
        void Atualizar(Cliente cliente);
        void Apagar(int codigo);
    }
}
