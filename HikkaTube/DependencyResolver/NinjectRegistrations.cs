using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using DataSource.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace DependencyResolver
{
  public class NinjectRegistrations : NinjectModule
  {
    public override void Load()
    {
      Bind<HikkaTubeEntities>().ToSelf().InRequestScope(); ;
      Bind<IRepository<User>>().To<UserRepository>().InRequestScope(); ;
      Bind<IRepository<Board>>().To<BoardRepository>().InRequestScope(); ;
      Bind<IRepository<Comment>>().To<CommentRepository>().InRequestScope(); ;
      Bind<IRepository<Video>>().To<VideoRepository>().InRequestScope();
      Bind<IRepository<Thread>>().To<ThreadRepository>().InRequestScope();
    }
  }
}
