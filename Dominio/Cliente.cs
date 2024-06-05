namespace Dominio
{
    /*
    Classe: Cliente
    Contém campos e métodos de validações necessárias sobre os dados
    de cada um dos campos
    */
    public class Cliente
    {
        private int codigo;
        private string nome;
        private string email;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }

        public Cliente(int codigo, string nome, string email) 
        {
            if (codigo < 1) throw new ArgumentException("Código Inválido");
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome Inválido");
            if (string.IsNullOrEmpty(email)
                || 
                !EmailValido(email)) 
                throw new ArgumentException("Email Inválido");

            this.Codigo = codigo;
            this.Nome = nome;
            this.Email = email;
        }

        //Funções de validação a partir daqui
        public bool EmailValido(string email)
        {
            return true;
        }
    }
}