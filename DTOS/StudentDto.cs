using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.DTOS;

namespace School.DTO;

public record StudentDto
{
    [JsonPropertyName("student_id")]
    public long StudentId { get; set; }



    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }


    [JsonPropertyName("last_name")]

    public string LastName { get; set; }

    [JsonPropertyName("mobile")]

    public long Mobile { get; set; }

    [JsonPropertyName("class_id")]

    public long ClassId { get; set; }

    [JsonPropertyName("teachers_assigned")]

    public List<TeacherDto> Teacher { get; set; }

    //[JsonPropertyName("subjects_assigned")]
    [JsonPropertyName("subject")]
    public List<SubjectDto> Subject { get; set; }

    

        

}

public record StudentCreateDto
{


    [JsonPropertyName("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [MaxLength(255)]
    public string LastName { get; set; }

    [JsonPropertyName("class_id")]
    [Required]


    public long ClassId { get; set; }
}

public record StudentUpdateDto
{

    [JsonPropertyName("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }





}