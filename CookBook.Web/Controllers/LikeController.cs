using CookBook.Web.DTOs.Like;
using CookBook.Web.Filters;
using CookBook.Web.Services.Like;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Web.Controllers
{
    [AuthToken]
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
            => this.likeService = likeService;

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add(LikeRequest request)
        {
            var result = await this.likeService
                .AddLikeAsync(request);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
