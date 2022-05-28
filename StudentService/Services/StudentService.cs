using StudentService.Model;
using StudentService.Services.Interfaces;

namespace StudentService.Services;

public class StudentService : IStudentService
{
    private readonly IStudentsRepository _studentsRepository;

    public StudentService(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public Task<CreateStudentResultModel> CreateStudent(CreateStudentRequestModel dto) => _studentsRepository.CreateStudentAsync(dto);

    public Task<DeleteStudentResultModel> DeleteStudentAsync(DeleteStudentRequestModel dto) =>
        _studentsRepository.DeleteStudentAsync(dto);

    public Task<GetStudentResultModel> GetStudent(GetStudentRequestModel dto) =>
        _studentsRepository.GetStudentAsync(dto);

    public Task<GetStudentsResultModel> GetStudents() => _studentsRepository.GetStudentsAsync();

    public Task<UpdtateStudentResultModel> UpdateStudentAsync(UpdateStudentRequestModel dto) =>
        _studentsRepository.UpdateStudentAsync(dto);
}
