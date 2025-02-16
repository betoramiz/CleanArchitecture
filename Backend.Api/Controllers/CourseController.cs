using Backend.Application.Features.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ApiController
    {
        private readonly ISender _mediator;

        public CourseController(ISender mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create.Command request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
                Ok,
                error => Problem(error.First().Description)
            );
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new GetCourseById.Query(id);
            var result = await _mediator.Send(request);
            return result.Match(Ok, Problem);
        }
    }
}
