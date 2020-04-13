namespace Model.Dao
{
    public class Validadores
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        public int IdCliente { get; set; }
        public string Usuário { get; set; }
        public string Operacao { get; set; }
        public string Email { get; set; }
        public Validadores(int id)
        {
            this.Id = id;
        }
        public Validadores()
        {

        }
    }
}