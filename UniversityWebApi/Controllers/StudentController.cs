using Microsoft.AspNetCore.Mvc;
using StudentService.Model;
using StudentService.Services.Interfaces;

namespace UniversityWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    private readonly ILogger<StudentController> _logger;

    public StudentController(
        IStudentService studentService,
        ILogger<StudentController> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public Task<GetStudentResultModel> Get([FromRoute] string id)
    {
        _logger.LogInformation("HTTP GET, Get student by {id}", id);
        return _studentService.GetStudent(new GetStudentRequestModel(id));
    }
    [HttpGet]
    public Task<GetStudentsResultModel> Get()
    {
        _logger.LogInformation("HTTP GET, Get students");
        return _studentService.GetStudents();
    }


    [HttpPost]
    public Task<CreateStudentResultModel> Post([FromForm] CreateStudentRequestModel dto)
    {
        _logger.LogInformation("HTTP POST, Create student with the parameters : {CreateStudentRequestModel}", dto);
        return _studentService.CreateStudent(dto);
    }
    [HttpDelete]
    public Task<DeleteStudentResultModel> Delete([FromQuery] DeleteStudentRequestModel dto)
    {
        _logger.LogInformation("HTTP DELETE, DELETE student by {id}", dto.StudentId);
        return _studentService.DeleteStudentAsync(dto);
    }

    [HttpPut("{id}")]
    public Task<UpdtateStudentResultModel> Put([FromRoute] string id, [FromBody] DataToUpdtae dto)
    {
        _logger.LogInformation("HTTP PUT, Update student by {id}, {dataToUpdate}", id, dto);
        return _studentService.UpdateStudentAsync(
            new UpdateStudentRequestModel(StudentId: id, LastName: dto.LastName, FirstName: dto.FirstName));
    }
}

public record DataToUpdtae(string LastName, string FirstName);