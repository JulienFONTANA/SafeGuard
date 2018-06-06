using Ninject.Modules;
using SafeGuard.Interfaces;

public class NinjectDI : NinjectModule
{
    public override void Load()
    {
        Bind<IEncryptModel>().To<IEncryptModel>();
        Bind<IEncryptViewModel>().To<IEncryptViewModel>();
    }
}