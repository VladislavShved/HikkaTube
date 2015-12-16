using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
    public class ThreadRepository : BaseRepository<Thread>
    {
        public ThreadRepository(HikkaTubeEntities hikkaTubeEntities) : base(hikkaTubeEntities)
        {
        }
    }
}
