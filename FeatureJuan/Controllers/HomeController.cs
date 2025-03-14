using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FeatureJuan.Models;
using FeatureJuan.Repository;


namespace FeatureJuan.Controllers
{
    public class HomeController : Controller
    {
        private readonly TimeRepository _timeRepository;
        private readonly DivisaoRepository _divisaoRepository;
        public HomeController(TimeRepository timeRepository, DivisaoRepository divisaoRepository)
        {

            _timeRepository = timeRepository;
            _divisaoRepository = divisaoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _timeRepository.GetTimes();
            var divisoes = await _divisaoRepository.GetDivisoes();
            ViewBag.Divisoes = divisoes;

            return View(model);
        }

       [HttpGet("cadastrar")]
        public async Task<IActionResult> CadastrarTimeAsync()
        {
            ViewBag.Divisoes = await _divisaoRepository.GetDivisoes();
            return View("Form", new Equipe());
        }


        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarTime(Equipe equipe)
        {
       
            await _timeRepository.CreateTime(equipe);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeletarTime(int EquipeId)
        {
            await _timeRepository.DeleteTime(EquipeId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{EquipeId}")]
        public async Task<IActionResult> EditarTime(int EquipeId)
        {
            var model = await _timeRepository.GetTimeById(EquipeId);
            ViewBag.Divisoes = await _divisaoRepository.GetDivisoes();
            return View("Form", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTime(Equipe equipe)
        {
            
            await _timeRepository.EditarTime(equipe);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}