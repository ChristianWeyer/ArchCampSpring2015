using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Contracts
{
    public interface IModule
    {
        void Initialize(IServicePool pool);
        FrameworkElement GetView();
    }
}
