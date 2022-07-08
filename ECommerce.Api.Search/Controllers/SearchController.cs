using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService; 

        public SearchController(ISearchService searchService)   
        {
            this.searchService = searchService;
        }
        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if (result.isSuccess)
            {
                return Ok(result.SearchResults);
            }

            return NotFound();
        }
    }
}
