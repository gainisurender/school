// using subject.DTOS;

using School.DTOS;

namespace School.Modelss;



public record Teacher
{
    public long TeacherId { get; set; }
    public string TeacherName { get; set; }

   
    public long Mobile { get; set; }

    public long SubjectId { get; set; }

    public TeacherDto asDto
    {
        get
        {
            return new TeacherDto
            {
                TeacherId = TeacherId,
                TeacherName = TeacherName,
                Mobile = Mobile,
                SubjectId = SubjectId,
                
            };
        }
    }

}

