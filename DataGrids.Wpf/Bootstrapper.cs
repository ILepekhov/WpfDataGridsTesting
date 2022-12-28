using System;
using System.Reflection;
using DataGrids.Shared;
using DryIoc;
using Splat.DryIoc;

namespace DataGrids.Wpf;

public sealed class Bootstrapper : IDisposable
{
    private readonly Container _container;
    private bool _disposed;

    public Bootstrapper()
    {
        _container = new Container();
        _container.UseDryIocDependencyResolver();

        _container.RegisterSharedServices();
        _container.RegisterViews(Assembly.GetExecutingAssembly());
    }

    public TService Resolve<TService>()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(Bootstrapper));
        }

        return _container.Resolve<TService>();
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _container.Dispose();

        _disposed = true;
    }
}
