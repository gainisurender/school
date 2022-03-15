using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repositories;
using School.DTO;



namespace School.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _student;
    private readonly ILogger<StudentController> _logger;

    private readonly ITeacherRepository _teacher;

    
    private readonly ISubjectRepository _subject;


    public StudentController(ILogger<StudentController> logger, IStudentRepository student , ITeacherRepository teacher,ISubjectRepository subject)
    {
        _logger = logger;

        _student = student;

        _teacher = teacher;

        _subject = subject;




    }
    [HttpGet]

    public async Task<ActionResult<List<StudentDto>>> GetAllusers()
    {
        var usersList = await _student.GetList();

        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{student_id}")]

    public async Task<ActionResult<StudentDto>> GetstudentById([FromRoute] long student_id)
    {
        var student = await _student.GetById(student_id);

        if (student is null)
            return NotFound("No user found with given student_id");

         var dto = student.asDto;

        dto.Teacher = (await _teacher.GetList(student.StudentId));
        dto.Subject = (await _subject.GetListSubject(student.StudentId));

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateStudent([FromBody] StudentCreateDto Data)
    {


        var toCreateStudent = new Student
        {
            FirstName = Data.FirstName,
            LastName = Data.LastName,
            ClassId = Data.ClassId,



        };

        var createdStudent = await _student.Create(toCreateStudent);

        return StatusCode(StatusCodes.Status201Created, createdStudent.asDto);
    }

    [HttpPut("{student_id}")]

    public async Task<ActionResult> UpdateUser([FromRoute] long student_id,
    [FromBody] StudentUpdateDto Data)
    {
        var existing = await _student.GetById(student_id);
        if (existing is null)
            return NotFound("No user found with given student id");

        var toUpdateUser = existing with
        {

            LastName = Data.LastName?.Trim() ?? existing.LastName,

        };

        var didUpdate = await _student.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }


    [HttpDelete("{student_id}")]

    public async Task<ActionResult> DeleteUser([FromRoute] long student_id)
    {
        var existing = await _student.GetById(student_id);

        if (existing is null)
            return NotFound("No user found with given student id");

        var didDelete = await _student.Delete(student_id);

        return NoContent();

    }


}
