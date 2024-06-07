using YasApp.Model;

namespace YasApp.Pages;

public partial class PerfilPage : ContentPage
{

    private Usuario  _usuario;
    public PerfilPage()
    {

        InitializeComponent();

        _usuario = App.Usuario;

        this.BindingContext = _usuario;

        Ftperfil.Clicked += async (sender, e) =>
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var file = await MediaPicker.PickPhotoAsync();
                if (file != null)
                {
                    var filePath = file.FullPath;

                    Ftperfil.Source = ImageSource.FromFile(filePath);

                    _usuario.Foto = filePath;
                    await App.BancoDados.UsuarioDataTable.SalvarUsuario(_usuario);

                }
            }
        };
    }

    private async void btnAtualizar_Clicked(object sender, EventArgs e)
    {
        await App.BancoDados.UsuarioDataTable.AtualizarUsuario(_usuario);
        await DisplayAlert("Sucesso", "Usuário Atualizado com Sucesso", "Fechar");
    }
}