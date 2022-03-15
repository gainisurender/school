using Microsoft.AspNetCore.Mvc;
using School.Repositories;
using School.DTOS;
using School.Models;
using School.Modelss;
using static School.DTOS.TeacherCreateDto;

namespace School.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacher;
    private readonly ILogger<TeacherController> _logger;

    private readonly IStudentRepository _student;

    public TeacherController(ILogger<TeacherController> logger, ITeacherRepository teacher, IStudentRepository student)
    {
        _logger = logger;

        _teacher = teacher;

        _student = student;


    }
    [HttpGet]

    public async Task<ActionResult<List<TeacherDto>>> GetAllusers()
    {
        var teachersList = await _teacher.GetList();

        var dtoList = teachersList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{teacher_id}")]

    public async Task<ActionResult<TeacherDto>> GetUserById([FromRoute] long teacher_id)
    {
        var teacher = await _teacher.GetById(teacher_id);

        if (teacher is null)
            return NotFound("No user found with given teacher_id");


        var dto = teacher.asDto;

        dto.Students = await _student.GetList(teacher.TeacherId);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<TeacherDto>> CreateTeacher([FromBody] TeacherCreateDto Data)
    {


        var toCreateTeacher = new Teacher
        {

            TeacherName = Data.TeacherName,
            Mobile = Data.Mobile,
            SubjectId = Data.SubjectId


        };

        var createdTeacher = await _teacher.Create(toCreateTeacher);

        return StatusCode(StatusCodes.Status201Created, createdTeacher.asDto);
    }




    [HttpPut("{teacher_id}")]

    public async Task<ActionResult> UpdateUser([FromRoute] long teacher_id,
    [FromBody] UsersUpdateDto Data)
    {
        var existing = await _teacher.GetById(teacher_id);
        if (existing is null)
            return NotFound("No user found with given teacher id");

        var toUpdateUser = existing with
        {
            Mobile = Data.Mobile,
            TeacherName = Data.TeacherName?.Trim() ?? existing.TeacherName,

        };

        var didUpdate = await _teacher.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }


    [HttpDelete("{teacher_id}")]

    public async Task<ActionResult> DeleteUser([FromRoute] long teacher_id)
    {
        var existing = await _teacher.GetById(teacher_id);

        if (existing is null)
            return NotFound("No user found with given teacher id");

        var didDelete = await _teacher.Delete(teacher_id);

        return NoContent();

    }


}
