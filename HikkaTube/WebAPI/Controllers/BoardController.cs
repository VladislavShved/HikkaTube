using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSource;

namespace WebAPI.Controllers
{
    public class BoardController : Controller
    {
        private readonly IRepository<Board> _boardRepository;
        private readonly IRepository<Thread> _threadRepository; 

        public BoardController(
            IRepository<Board> boardRepository, 
            IRepository<Thread> threadRepository)
        {
            _boardRepository = boardRepository;
            _threadRepository = threadRepository;
        }

        //
        // GET: /Board/
        public ActionResult Index(string id)
        {
            var boards = _boardRepository.GetAll().ToList();
            var board = boards.FirstOrDefault(b => b.ShortName == "/" + id + "/");
            if (board == null)
            {
                return View("ErrorPage");
            }
            var threads = _threadRepository.GetAll(t => t.BoardId == board.Id);

            ViewBag.Threads = threads;

            return View(board);
        }
	}
}