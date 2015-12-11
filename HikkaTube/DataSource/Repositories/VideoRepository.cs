﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
  public class VideoRepository : BaseRepository<Video>
  {
    public VideoRepository(HikkaTubeEntities hikkaTubeEntities) : base(hikkaTubeEntities)
    {
    }
  }
}
