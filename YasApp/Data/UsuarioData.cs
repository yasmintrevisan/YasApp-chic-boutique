using SQLite;
using YasApp.Model;

namespace YasApp.Data
{
   
    public class UsuarioData
    {
        private SQLiteAsyncConnection _conexaoDB;

        public UsuarioData(SQLiteAsyncConnection conexaoDB)
        {
            _conexaoDB = conexaoDB;
        }

        public Task<List<Usuario>> GetUsuariosAsync()
        {
            var lista = _conexaoDB
                .Table<Usuario>()
                .ToListAsync();

            return lista;
        }

        public Task<Usuario> GetUsuarioAsync(string email, string senha)
        {
            var usuario = _conexaoDB
                .Table<Usuario>()
                .Where(u => u.Email == email && u.Senha == senha)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public Task<Usuario> ObtemIdUsuario(Guid id)
        {
            var usuario = _conexaoDB
                .Table<Usuario>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<int> SalvarUsuario(Usuario usuario)
        {
            var novoUsuario = await ObtemIdUsuario(usuario.Id);

            if (novoUsuario == null)
            {
                return await _conexaoDB.InsertAsync(usuario);
            }
            else
            {
                return await _conexaoDB.UpdateAsync(usuario);
            }
        }

        public Task<int> AtualizarUsuario (Usuario usuario)
        {
            return _conexaoDB.UpdateAsync(usuario);
        }
        public async Task<int> DeletarUsuario(Usuario usuario)
        {
            var usuarioExiste = await ObtemIdUsuario(usuario.Id);

            if (usuarioExiste == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            return await _conexaoDB.DeleteAsync(usuario);
        }
    }
}


