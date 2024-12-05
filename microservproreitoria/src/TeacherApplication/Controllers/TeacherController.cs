using microservproreitoria.src.TeacherApplication.Entities;
using microservproreitoria.src.TeacherApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace microservproreitoria.src.TeacherApplication.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var teachers = await _service.GetAllAsync();
            return Results.Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id)
        {
            var teacher = await _service.GetByIdAsync(id);
            if (teacher == null)
                return Results.NotFound();

            return Results.Ok(teacher);
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] Teacher teacher)
        {
            if (teacher == null)
                return Results.BadRequest("Teacher não pode ser nullo.");

            var createdTeacher = await _service.SaveAsync(teacher);
            return Results.Ok(createdTeacher);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(Guid id, [FromBody] Teacher teacher)
        {
            if (teacher == null || id == Guid.Empty)
                return Results.BadRequest("Informação inválida.");

            var updatedTeacher = await _service.UpdateAsync(id, teacher);
            if (updatedTeacher == null)
                return Results.NotFound();

            return Results.Ok(updatedTeacher);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return Results.NotFound();

            var success = await _service.DeleteAsync(id);
            if (!success)
                return Results.BadRequest();

            return Results.NoContent();
        }
    }
}
