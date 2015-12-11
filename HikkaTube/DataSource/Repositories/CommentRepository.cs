using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
  public class CommentRepository : BaseRepository<Comment>
  {
    public CommentRepository(HikkaTubeEntities hikkaTubeEntities) : base(hikkaTubeEntities)
    {
    }
  }
}
