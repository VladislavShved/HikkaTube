using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
  public class BoardRepository : BaseRepository<Board>
  {
    public BoardRepository(HikkaTubeEntities hikkaTubeEntities) : base(hikkaTubeEntities)
    {
    }
  }
}
