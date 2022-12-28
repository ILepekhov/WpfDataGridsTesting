using System.Reflection;
using DataGrids.Shared.Infrastructure;
using DataGrids.Shared.ViewModel;
using DryIoc;
using ReactiveUI;

namespace DataGrids.Shared;

public static class ServicesRegistration
{
    public static void RegisterSharedServices(this Container container)
    {
        RegisterViewModels(container);
        RegisterServices(container);
    }

    public static void RegisterViews(this Container container, Assembly assembly)
    {
        /*
         * I don't know why but this stuff doesn't work with DryIoC: Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly()).
         * That's why I've made an adaptation of RegisterViewsForViewModels method for DryIoC.
         */

        TypeInfo[] viewTypeInfos = assembly.DefinedTypes
            .Where(typeInfo => typeInfo.ImplementedInterfaces.Contains(typeof(IViewFor)) &&
                               typeInfo.IsAbstract is false && typeInfo.IsInterface is false)
            .ToArray();

        foreach (TypeInfo viewTypeInfo in viewTypeInfos)
        {
            Type? serviceType = viewTypeInfo.ImplementedInterfaces.FirstOrDefault(type =>
                type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IViewFor)));

            if (serviceType is null)
            {
                continue;
            }

            Type viewType = viewTypeInfo.AsType();

            IReuse reuseMode = viewTypeInfo.GetCustomAttribute<SingleInstanceViewAttribute>() is null
                ? Reuse.Transient
                : Reuse.Singleton;

            ViewContractAttribute? customAttribute = viewTypeInfo.GetCustomAttribute<ViewContractAttribute>();

            container.Register(serviceType, viewType, reuse: reuseMode, serviceKey: customAttribute?.Contract);
        }
    }

    private static void RegisterViewModels(Container container)
    {
        container.Register<RootViewModel>(Reuse.Singleton);
    }

    private static void RegisterServices(Container container)
    {
        container.Register<ISlideTasksService, SlideTasksService>(Reuse.Transient);
    }
}
