using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSource;

namespace WebAPI.Controllers
{
  public class ThreadController : Controller
  {
    private readonly IRepository<Thread> _threadRepository;

    public ThreadController(IRepository<Thread> threadRepository)
    {
      _threadRepository = threadRepository;
    }

    public ActionResult Index(Guid? id)
    {
      if (id == null)
      {
        return View("ErrorPage", "Board");
      }

      var thread = _threadRepository.GetById(id.Value);

      return View(thread);
    }
  }
}