using Microsoft.AspNetCore.Mvc;
using School.Repositories;

using School.DTO;


namespace School.Controllers;

[ApiController]
[Route("api/Classroom")]
public class ClassroomController : ControllerBase
{

    private readonly IclassroomRepository _classroom;
    private readonly ILogger<ClassroomController> _logger;



    public ClassroomController(ILogger<ClassroomController> logger, IclassroomRepository classroom)
    {
        _logger = logger;

        _classroom = classroom;
        {

        }
    }

    [HttpGet]

    public async Task<ActionResult<List<ClassDto>>> GetAllclasses()
    {
        var classesList = await _classroom.GetList();

        var dtoList = classesList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{classroom_id}")]

    public async Task<ActionResult<ClassDto>> GetUserById([FromRoute] long classroom_id)
    {
        var classroom = await _classroom.GetById(classroom_id);


        return Ok(classroom.asDto);


    }



}