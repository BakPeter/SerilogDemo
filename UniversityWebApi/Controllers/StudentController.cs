using Microsoft.AspNetCore.Mvc;
using StudentService.Model;
using StudentService.Services.Interfaces;

namespace UniversityWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService) => _studentService = studentService;

    [HttpGet("{id}")]
    public Task<GetStudentResultModel> Get([FromRoute] string id) =>
        _studentService.GetStudent(new GetStudentRequestModel(id));

    [HttpGet]
    public Task<GetStudentsResultModel> Get() => _studentService.GetStudents();


    [HttpPost]
    public Task<CreateStudentResultModel> Post([FromForm] CreateStudentRequestModel dto) =>
        _studentService.CreateStudent(dto);

    [HttpDelete]
    public Task<DeleteStudentResultModel> Delete([FromQuery] DeleteStudentRequestModel dto) =>
        _studentService.DeleteStudentAsync(dto);

    [HttpPut("{id}")]
    public Task<UpdtateStudentResultModel> Put([FromRoute] string id, [FromBody] DataToUpdtae dto) =>
        _studentService.UpdateStudentAsync(
            new UpdateStudentRequestModel(StudentId: id, LastName: dto.LastName, FirstName: dto.FirstName));
}

public record DataToUpdtae(string LastName, string FirstName);