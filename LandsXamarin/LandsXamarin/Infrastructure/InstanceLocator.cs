using LandsXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandsXamarin.Infrastructure
{
    public class InstancesLocator
    {
    #region Contructores
    public InstancesLocator()
    {
      this.Main = new MainViewModel();
    }
    #endregion
    #region Propiedaes
    public MainViewModel Main { get; set; }
    #endregion

  }
}
