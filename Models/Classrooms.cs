// using subject.DTO;
using School.DTO;

namespace School.Models;

public record Classroom
{
    public long ClassId { get;set; }

    public string ClassName { get;set; }
    public string ClassTeacher { get;set; }
    public long NoTest { get;set;}

    public ClassDto asDto{
     get{
         return new ClassDto{
             ClassId = ClassId,
             ClassName = ClassName,
             ClassTeacher = ClassTeacher,
             NoTest = NoTest,

         };
     }   
    }
}
