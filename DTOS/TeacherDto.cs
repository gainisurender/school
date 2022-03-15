using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.DTO;


namespace School.DTOS;

public record TeacherDto
{
    [JsonPropertyName("teacher_id")]
    public long TeacherId { get; set; }


    [JsonPropertyName("teacher_name")]
    public string TeacherName { get; set; }


    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }




    [JsonPropertyName("subject_id")]

    public long SubjectId { get; set; }

    [JsonPropertyName("student")]

    public List<StudentDto> Students { get; set; }


}
public record TeacherCreateDto
{


    [JsonPropertyName("teacher_name")]
    [Required]
    [MaxLength(50)]
    public string TeacherName { get; set; }

    [JsonPropertyName("mobile")]
    [Required]
    public long Mobile { get; set; }

    [JsonPropertyName("subject_id")]
    [MaxLength(255)]
    public long SubjectId { get; set; }
    [JsonPropertyName("students")]
    public List<StudentDto> Students { get; set; }

    [JsonPropertyName("subject")]
    public List<StudentDto> Subject { get; set; }








    public record UsersUpdateDto
    {

        [JsonPropertyName("teacher_name")]
        [MaxLength(50)]
        public string TeacherName { get; set; }



        [JsonPropertyName("mobile")]
        public long Mobile { get; set; }


    }
}



