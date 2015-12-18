using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataSource;
using WebAPI.Models;

namespace WebAPI.Controllers.Api
{
    public class CommentController : ApiController
    {
      private readonly IRepository<Comment> _commentRepository;

      public CommentController(IRepository<Comment> commentRepository)
      {
        _commentRepository = commentRepository;
      }

      [HttpPost]
      public void AddComment([FromBody]CommentModel model)
      {
        var comment = new Comment
        {
          Id = Guid.NewGuid(),
          Text = model.Text,
          ThreadId = model.ThreadId
        };

        _commentRepository.Add(comment);
        _commentRepository.Commit();
      }
    }
}
