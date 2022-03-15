using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.DTOS;

namespace School.DTO;

public record SubjectDto
{
    [JsonPropertyName("subject_id")]
    public long SubjectId { get; set; }


    [JsonPropertyName("faculty_name")]
    public string FacultyName { get; set; }

    [JsonPropertyName("subject_code")]
    public long SubjectCode { get; set; }

    [JsonPropertyName("subject_name")]
    public string SubjectName { get; set; }

    [JsonPropertyName("teachers")]
    public List<TeacherDto> Teachers { get; set; }


    public record SubjectCreateDto
    {




        [JsonPropertyName("faculty_name")]
        [Required]
        [MaxLength(50)]
        public string TeacherName { get; set; }

        [JsonPropertyName("subject_name")]
        [Required]
        public string subject_name { get; set; }

        [JsonPropertyName("subject_code")]
        [MaxLength(255)]
        public long SubjectCode { get; set; }
        public List<TeacherDto> Teachers { get; set; }



    }
}

