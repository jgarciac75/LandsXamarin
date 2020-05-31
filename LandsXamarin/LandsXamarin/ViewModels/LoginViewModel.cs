using GalaSoft.MvvmLight.Command;
using LandsXamarin.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace LandsXamarin.ViewModels
{
  /// <summary>
  /// Modelo de la Pagina LoginPage
  /// </summary>
  public class LoginViewModel : BaseViewModel
  {
    #region Eventos
    #endregion

    #region Constructores
    public LoginViewModel()
    {
      this.IsRemember = true;
      this.IsEnabled = true;

      this.Email = "jgarciac75@gmail.com";
      this.Password = "Camila";

      // Url Api: http://restcountries.eu/rest/v2/all
    }
    #endregion

    #region Atributos
    private string _email;
    private string _password;
    private bool _isrunning;
    private bool _isenabled = true;
    #endregion
    #region Propiedades
    public string Email { get => _email; set { SetValue(ref _email, value); } }
    public string Password
    {
      get { return _password; }
      set
      {
        SetValue(ref _password, value);
      }
    }

    public bool IsRunning
    {
      get { return _isrunning; }
      set
      {
        SetValue(ref _isrunning, value);
      }
    }

    public bool IsRemember { get; set; }
    public bool IsEnabled
    {
      get { return _isenabled; }
      set
      {
        SetValue(ref _isenabled, value);
      }
    }
    #endregion

    #region Comandos
    public ICommand LoginCommand
    {
      get
      {
        return new RelayCommand(Login);
      }
    }



    private async void Login()
    {
      if (string.IsNullOrEmpty(this.Email))
      {
        await Application.Current.MainPage.DisplayAlert(
          "Error", "Debes Ingresar el Correo Electronico", "Aceptar");
        return;
      }
      if (string.IsNullOrEmpty(this.Password))
      {
        // Esta es la Forma de Mandar Alertas en Xamarin
        await Application.Current.MainPage.DisplayAlert(
          "Error", "Debes Ingresar La Contraseña", "Aceptar");
        return;
      }
      this.IsRunning = true;
      this.IsEnabled = false;
      if (this.Email != "jgarciac75@gmail.com" || this.Password != "Camila")
      {
        await Application.Current.MainPage.DisplayAlert(
          "Error", "EMail o Contraseña Incorrecta", "Aceptar");
        this.Password = string.Empty;
        this.IsRunning = false;
        this.IsEnabled = true;
        return;
      }
      this.IsRunning = false;
      this.IsEnabled = true;
      //await Application.Current.MainPage.DisplayAlert("OK", "Todo Bien", "Aceptar");
      this.Email = this.Password = string.Empty;
      // Apilamos enviamos la nueva página
      MainViewModel.GetInstance().Lands = new LandsViewModel();
      await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
    }
    #endregion
  }//fin clase
}//fin namespace


