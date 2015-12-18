using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
  public class CommentModel
  {
    public string Text { get; set; }

    public Guid UserId { get; set; }

    public Guid VideoId { get; set; }

    public Guid ThreadId { get; set; }
  }
}