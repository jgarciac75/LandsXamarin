using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandsXamarin.ViewModels
{
  /// <summary>
  /// Clase ViewModel Principal de la Aplicación
  /// </summary>
  public class MainViewModel
  {
    #region Constructores
    /// <summary>
    /// Constructor por Defecto
    /// </summary>
    public MainViewModel()
    {
      this.Login = new LoginViewModel();
    }
    #endregion

    #region ViewModel
    /// <summary>
    /// Modelo Asociado al LoginViewModel
    /// </summary>
    public LoginViewModel Login { get; set; }
    public LandsViewModel Lands { get; set; }
    #endregion

    #region Singleton
    private static MainViewModel instance;
    public static MainViewModel GetInstance()
    {
      if (instance == null) instance = new MainViewModel();
      return instance;
    }
    #endregion
  }
}
