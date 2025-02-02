using microservproreitoria;
using microservproreitoria.src.CourseCreation.Services;
using microservproreitoria.src.labsCreation.Services.Implemetation;
using microservproreitoria.src.labsCreation.Services;
using microservproreitoria.src.TeacherApplication.Services.Implemetation;
using microservproreitoria.src.TeacherApplication.Services;
using microservproreitoria;
using microservproreitoria.src.SubjectCreation.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryDbContext>();
builder.Services.AddScoped<ILabService, LabService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
