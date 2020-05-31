

namespace LandsXamarin.ViewModels
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using LandsXamarin.Models;
  using LandsXamarin.Services;
  using Xamarin.Forms;

  public class LandsViewModel:BaseViewModel
    {

    #region Servicios
    private ApiService _apiService;
    #endregion
    #region Atributos
    private ObservableCollection<Land> _lands;
    #endregion

    #region Properties
    public ObservableCollection<Land> Lands {get => _lands; set => SetValue(ref _lands,value); }
    #endregion

    #region Construcores
    public LandsViewModel()
    {
      this._apiService = new ApiService();
      this.LoadLands();
    }
    #endregion

    #region Métodos
    private async void LoadLands()
    {
      var connection = await this._apiService.CheckConnection();
      if (!connection.IsSuccess)
      {
        await Application.Current.MainPage.DisplayAlert(
  "Error", connection.Message, "Aceptar");
        // Devolvemos a la Pagina Anterior
        await Application.Current.MainPage.Navigation.PopAsync();
        return;
      }
      var response = await this._apiService.GetList<Land>(
        "http://restcountries.eu", "/rest", "/v2/all");
      if (!response.IsSuccess)
      {
        await Application.Current.MainPage.DisplayAlert(
          "Error", response.Message, "Aceptar");
        return;
      }
      // Completo Llego la Lista se convierte a ObsevableCollection
      var list = (List<Land>)response.Result;
      this.Lands = new ObservableCollection<Land>(list);
    }

    #endregion
  }
}
