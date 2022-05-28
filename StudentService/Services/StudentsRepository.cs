using Microsoft.Extensions.Logging;
using StudentService.Model;
using StudentService.Services.Interfaces;

namespace StudentService.Services;

public class StudentsRepository : IStudentsRepository
{
    private readonly List<Student> _studentsDb = new();
    private readonly ILogger<StudentsRepository> _logger;

    public StudentsRepository(ILogger<StudentsRepository> logger)
    {
        _logger = logger;
    }

    public async Task<CreateStudentResultModel> CreateStudentAsync(CreateStudentRequestModel dto)
    {
        try
        {
            _logger.LogInformation("Create student, {dto}", dto);
            var getStudentResult = await GetStudentAsync(new GetStudentRequestModel(StudentId: dto.StudentId));

            if (getStudentResult.Success)
            {
                return new CreateStudentResultModel(Success: false, ErrorMessage: "Student already exists.");
            }
            else
            {
                var id = Guid.NewGuid().ToString(); ;
                _studentsDb.Add(new Student { _id = id, Id = dto.StudentId, LastName = dto.LastName, FirstName = dto.FirstName });
                //await Task.Delay(100);

                return new CreateStudentResultModel(Success: true, StudentId: id);
            }
        }
        catch (Exception e)
        {
            _logger.LogError("Create student, {error}", e);
            return new CreateStudentResultModel(Success: false, ErrorMessage: e.Message);
        }
    }

    public async Task<DeleteStudentResultModel> DeleteStudentAsync(DeleteStudentRequestModel dto)
    {
        try
        {
            //throw new Exception("Error logging POC");

            _logger.LogInformation("Delete student, {id}", dto.StudentId);

            var getStudentResult = await GetStudentAsync(new GetStudentRequestModel(StudentId: dto.StudentId));

            if (getStudentResult.Success)
            {
                _ = _studentsDb.Remove(getStudentResult.Student!);
                //await Task.Delay(100);
                return new DeleteStudentResultModel(Success: true);
            }
            else
            {
                return new DeleteStudentResultModel(Success: false, ErrorMessage: "Student don't exists.");
            }
        }
        catch (Exception e)
        {
            _logger.LogError("Delete student, {error}", e);
            return new DeleteStudentResultModel(Success: false, ErrorMessage: e.Message);
        }
    }

    public async Task<GetStudentResultModel> GetStudentAsync(GetStudentRequestModel dto)
    {
        try
        {
            _logger.LogInformation("Get studentd by {id}", dto.StudentId);

            var student = _studentsDb.Find(s => s.Id != null && s.Id.Equals(dto.StudentId));
            await Task.Delay(100);

            if (student == null)
                return new GetStudentResultModel(Success: false, ErrorMessage: "Student not found");
            else
                return new GetStudentResultModel(Success: true, Student: student);
        }
        catch (Exception e)
        {
            _logger.LogError("Get student by {id} error, {error}", dto.StudentId, e);
            return new GetStudentResultModel(Success: false, ErrorMessage: e.Message);
        }
    }

    public async Task<GetStudentsResultModel> GetStudentsAsync()
    {
        try
        {
            _logger.LogInformation("Get all students");
            await Task.Delay(100);

            return new GetStudentsResultModel(Success: true, Students: _studentsDb);
        }
        catch (Exception e)
        {
            _logger.LogError("Get all students error, {error}", e);
            return new GetStudentsResultModel(Success: false, ErrorMessage: e.Message);
        }
    }

    public async Task<UpdtateStudentResultModel> UpdateStudentAsync(UpdateStudentRequestModel dto)
    {
        try
        {
            _logger.LogInformation("Update studetn by {id}, {dataToUpdate}", dto.StudentId, dto);

            var getStudentResult = await GetStudentAsync(new GetStudentRequestModel(StudentId: dto.StudentId));

            if (getStudentResult.Success)
            {
                var student = getStudentResult.Student;
                student!.LastName = dto.LastName;
                student.FirstName = dto.FirstName;
                //await Task.Delay(100);
                return new UpdtateStudentResultModel(Success: true, Student: student);
            }
            else
            {
                return new UpdtateStudentResultModel(Success: false, ErrorMessage: "Student don't exists.");
            }
        }
        catch (Exception e)
        {
            _logger.LogInformation("Update student by {id} {error}", dto.StudentId, e);
            return new UpdtateStudentResultModel(Success: false, ErrorMessage: e.Message);
        }
    }
}
