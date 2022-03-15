// using subject.DTO;
using School.DTO;

namespace School.Models;


public record Subject
{

    public long SubjectId { get; set; }
    public string FacultyName { get; set; }
    public long SubjectCode { get; set; }
    public string SubjectName { get; set; }





    public SubjectDto asDto
    {
        get
        {
            return new SubjectDto
            {
                SubjectId = SubjectId,
                FacultyName = FacultyName,
                SubjectCode = SubjectCode,
                SubjectName = SubjectName,

            };
        }
    }



}