namespace microservproreitoria.CourseCreation.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CurseController : ControllerBase
    {
        private ICurseService _service;

        public CurseController(ICurseService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            var listaCursos = await this._service.GetAllAsync();
            return Results.Ok(listaCursos);
        }

        [HttpPost]
        public async Task<IResult> Post(Curse curse)
        {
            if (curse == null)
            {
                return Results.BadRequest();
            }

            var curseSalvo = await _service.SaveAsync(curse);

            return Results.Ok(curseSalvo);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(String id, [FromBody] Curse curse)
        {
            if (curse == null || id.Equals(String.Empty))
            {
                return Results.BadRequest();
            }
            curse = await _service.UpdateAsync(id, curse);
            if (curse == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(curse);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(String id)
        {
            if (id.Equals(String.Empty))
            {
                return Results.BadRequest();
            }
            var curse = await _service.DeleteAsync(id);
            if (curse != null)
            {
                return Results.Ok(curse);
            }
            return Results.NotFound();
        }
    }
}