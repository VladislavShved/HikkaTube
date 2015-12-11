using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using DataSource.Repositories;
using Ninject.Modules;

namespace DependencyResolver
{
  public class NinjectRegistrations : NinjectModule
  {
    public override void Load()
    {
      Bind<HikkaTubeEntities>().ToSelf();
      Bind<IRepository<User>>().To<UserRepository>();
      Bind<IRepository<Board>>().To<BoardRepository>();
      Bind<IRepository<Comment>>().To<CommentRepository>();
      Bind<IRepository<Video>>().To<VideoRepository>();
    }
  }
}
