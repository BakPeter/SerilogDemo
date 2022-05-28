using StudentService.Model;

namespace StudentService.Services.Interfaces;

public interface IStudentService
{
    Task<CreateStudentResultModel> CreateStudent(CreateStudentRequestModel dto);
    Task<GetStudentsResultModel> GetStudents();
    Task<GetStudentResultModel> GetStudent(GetStudentRequestModel dto);
    Task<DeleteStudentResultModel> DeleteStudentAsync(DeleteStudentRequestModel dto);
    Task<UpdtateStudentResultModel> UpdateStudentAsync(UpdateStudentRequestModel dto);
}
