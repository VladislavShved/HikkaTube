using System.Web.Http.Dependencies;
using DependencyResolver.DependencyScopes;
using Ninject;

namespace DependencyResolver.DependencyResolvers
{
  public class NinjectResolver : NinjectScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
  {
    private readonly IKernel kernel;
    private bool disposed = false;

    public NinjectResolver(IKernel kernel)
      : base(kernel)
    {
      this.kernel = kernel;
    }

    public IDependencyScope BeginScope()
    {
      return new NinjectScope(kernel);
    }

    protected void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          if (kernel != null)
          {
            kernel.Dispose();
          }
        }

        disposed = true;
      }

      base.Dispose();
    }
  }
}
