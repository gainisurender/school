// using subject.DTO;
using School.DTO;

namespace School.Models;


public record Student
{

    public long StudentId { get; set; }
   

    public string FirstName { get; set; }

    public string LastName { get; set; }

    
    public long Mobile { get; set; }

    public long ClassId { get; set; }

    
    public StudentDto asDto
    {
        get
        {
            return new StudentDto
            {
                StudentId = StudentId,
                FirstName = FirstName,
                LastName = LastName,
                Mobile = Mobile,
                ClassId = ClassId,
                
            };
        }
    }
}


