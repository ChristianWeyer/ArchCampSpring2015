using Contracts;
using System.ComponentModel.Composition;
using System.Windows;

namespace SpeakerModule
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ModuleMetadata("SpeakerModule", "Sprecher")]
    public class SpeakerViewModel : IModule
    {
        public void Initialize(IServicePool pool)
        {
            //var moduleService = pool.GetService<IModuleService>();
        }

        public FrameworkElement GetView()
        {
            return new UserControl1() { DataContext = this };
        }
    }
}
