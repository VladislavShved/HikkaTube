using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSource;

namespace WebApi.Controllers
{
  public class HomeController : Controller
  {
    private readonly IRepository<Board> _boardRepository;

    public HomeController(IRepository<Board> boardRepository)
    {
      _boardRepository = boardRepository;
    }

    public ActionResult Index()
    {
      var boards = _boardRepository.GetAll();
      ViewBag.Boards = boards;

      return View();
    }
  }
}