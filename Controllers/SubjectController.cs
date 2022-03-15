using Microsoft.AspNetCore.Mvc;
using School.Repositories;

using School.DTO;


namespace School.Controllers;

[ApiController]
[Route("[controller]")]
public class SubjectController : ControllerBase
{

    private readonly ISubjectRepository _subject;
    private readonly ILogger<SubjectController> _logger;

    private readonly  ITeacherRepository _teacher;

    public SubjectController(ILogger<SubjectController> logger, ISubjectRepository subject,ITeacherRepository teacher)
    {
        _logger = logger;

        _subject = subject;

        _teacher = teacher;
    }

    [HttpGet]

    public async Task<ActionResult<List<SubjectDto>>> GetAllusers()
    {
        var usersList = await _subject.GetList();

        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{subject_id}")]

    public async Task<ActionResult<SubjectDto>> GetUserById([FromRoute] long subject_id)
    {
        var subject = await _subject.GetById(subject_id);

        var dto = subject.asDto;

        dto.Teachers = await _teacher.GetList(subject_id);
        return Ok(dto);
    

    }



}