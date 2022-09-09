using AskMe.Core.Core.Inputs;
using AskMe.Core.Core.Utilities;
using AskMe.Services.Services.Models.Interfaces;
using AskMe.Views.ViewModels;
using AskMe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AskMe.Web.Controllers
{
    public class AskMeController : Controller
    {
        private readonly IApplicationLogger _logger;
        private readonly IAskMeServiceAdapter _askMeServiceAdapter;

        public AskMeController(IApplicationLogger logger, IAskMeServiceAdapter askMeServiceAdapter)
        {
            _logger = logger;
            _askMeServiceAdapter = askMeServiceAdapter;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SearchResult(AskMeSearchViewModel searchViewModel)
        {
            try
            {
                var request = new OpenAiSearchRequest { MaxTokens = OpenAiUtilities.LONGTOKEN, Query = searchViewModel.Query };
                var result = await _askMeServiceAdapter.SearchAsync(request);
                var vm = new SearchResultViewModel
                {
                    SearchResults = result
                };
                return View(vm);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occured during the process of getting the result {ex}");
                return RedirectToAction("Error");
            }
        } 
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}