using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
  public class UserRepository : BaseRepository<User>
  {
    public UserRepository(HikkaTubeEntities hikkaTubeEntities) : base(hikkaTubeEntities)
    {  }
  }
}
