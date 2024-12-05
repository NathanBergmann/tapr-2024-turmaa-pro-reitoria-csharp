using microservproreitoria.src.LabsCreation.Entities;
using microservproreitoria.src.labsCreation.Services;
using Microsoft.AspNetCore.Mvc;

namespace microservproreitoria.src.labsCreation.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class LabController : ControllerBase
    {
        private readonly ILabService _service;

        public LabController(ILabService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var labs = await _service.GetAllAsync();
            return Results.Ok(labs);
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id)
        {
            var lab = await _service.GetByIdAsync(id);
            if (lab == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(lab);
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] Lab lab)
        {
            if (lab == null)
                return Results.BadRequest("Laboratorio não pode ser nullo.");

            var createdLab = await _service.SaveAsync(lab);
            return Results.Ok(createdLab);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(Guid id, [FromBody] Lab lab)
        {
            if (lab == null || id == Guid.Empty)
                return Results.BadRequest("Informação faltando.");

            var updatedLab = await _service.UpdateAsync(id, lab);
            if (updatedLab == null)
                return Results.NotFound();

            return Results.Ok(updatedLab);
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
