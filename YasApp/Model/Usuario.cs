using SQLite;

namespace YasApp.Model
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Foto { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
