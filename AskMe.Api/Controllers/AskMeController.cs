using AskMe.Core.Core.Inputs;
using AskMe.Core.Core.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;

namespace AskMe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AskMeController : ControllerBase
    {
        private readonly ISearchEngine _searchEngine;

        public AskMeController(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }
        [Route("SearchAsync")]
        [HttpPost]
        public async Task<IActionResult> SearchAsync([FromBody] OpenAiSearchRequest searchRequest)
        {
            var result = await _searchEngine.CreateCompletion(searchRequest);
            return Ok(result);
        }
        [Route("SearchAndFormatAsync")]
        [HttpPost]
        public async Task<IActionResult> SearchAndFormatAsync([FromBody] CompletionRequest completionRequest)
        {
            var result = await _searchEngine.CreateAndFormatCompletion(completionRequest);
            return Ok(result);
        }
    }
}
