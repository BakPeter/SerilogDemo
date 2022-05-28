using StudentService.Model;

namespace StudentService.Services.Interfaces;

public interface IStudentsRepository
{
    Task<CreateStudentResultModel> CreateStudentAsync(CreateStudentRequestModel dto);
    Task<GetStudentsResultModel> GetStudentsAsync();
    Task<GetStudentResultModel> GetStudentAsync(GetStudentRequestModel dto);
    Task<DeleteStudentResultModel> DeleteStudentAsync(DeleteStudentRequestModel dto);

    Task<UpdtateStudentResultModel> UpdateStudentAsync(UpdateStudentRequestModel dto);
}
