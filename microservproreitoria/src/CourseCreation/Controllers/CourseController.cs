namespace microservproreitoria.CourseCreation.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CourseController : ControllerBase
    {
        private ICourseService _service;

        public CourseController(ICourseService service)
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
        public async Task<IResult> Post(Course Course)
        {
            if (Course == null)
            {
                return Results.BadRequest();
            }

            var CourseSalvo = await _service.SaveAsync(Course);

            return Results.Ok(CourseSalvo);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(String id, [FromBody] Course Course)
        {
            if (Course == null || id.Equals(String.Empty))
            {
                return Results.BadRequest();
            }
            Course = await _service.UpdateAsync(id, Course);
            if (Course == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(Course);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(String id)
        {
            if (id.Equals(String.Empty))
            {
                return Results.BadRequest();
            }
            var Course = await _service.DeleteAsync(id);
            if (Course != null)
            {
                return Results.Ok(Course);
            }
            return Results.NotFound();
        }
    }
}