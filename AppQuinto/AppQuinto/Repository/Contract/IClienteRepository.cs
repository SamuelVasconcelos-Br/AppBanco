using AppQuinto.Models;

namespace AppQuinto.Repository.Contract
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObterTodosClientes();

        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);

        Cliente ObterCliente(int id);
        void Excluir(int id);
    }
}
