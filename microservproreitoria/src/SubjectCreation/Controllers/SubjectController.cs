using microservproreitoria.src.SubjectCreation.Entities;
using microservproreitoria.src.SubjectCreation.Services;
using Microsoft.AspNetCore.Mvc;

namespace microservproreitoria.src.SubjectCreation.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class SubjectController : ControllerBase
    {
        private ISubjectService _service;
        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            var subjectList = await this._service.GetAllAsync();
            return Results.Ok(subjectList);
        }

        [HttpPost]
        public async Task<IResult> Post(Subject subject)
        {
            if (subject == null)
            {
                return Results.BadRequest();
            }

            var newSubject = await _service.SaveAsync(subject);

            return Results.Ok(newSubject);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put([FromRoute] string id, [FromBody] Subject subject)
        {
            if (subject == null || id.Equals(String.Empty))
            {
                return Results.BadRequest();
            }
            subject = await _service.UpdateAsync(id, subject);
            if (subject == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(subject);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete([FromRoute] String id)
        {
            if (id.Equals(String.Empty))
            {
                return Results.BadRequest();
            }
            await _service.DeleteAsync(id);
            
            return Results.Ok();
            
        }
    }
}