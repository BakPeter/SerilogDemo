namespace StudentService.Model;

//public record ResultModel(bool Success, string? ErrorMessage="");
public record struct ResultModel(bool Success, string? ErrorMessage = "");
public record struct CreateStudentResultModel(bool Success, string? StudentId = null, string? ErrorMessage = "");
public record CreateStudentRequestModel(string StudentId, string LastName, string FirstName);
public record struct GetStudentsResultModel(bool Success, List<Student>? Students = null, string? ErrorMessage = "");
public record GetStudentRequestModel(string StudentId);
public record struct GetStudentResultModel(bool Success, Student? Student = null, string? ErrorMessage = "");
public record DeleteStudentRequestModel(string StudentId);
public record struct DeleteStudentResultModel(bool Success, string? ErrorMessage = "");
public record struct UpdtateStudentResultModel(bool Success, Student? Student = null, string? ErrorMessage = "");
public record UpdateStudentRequestModel(string StudentId, string LastName, string FirstName);

