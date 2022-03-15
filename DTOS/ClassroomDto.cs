using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.DTOS;

namespace School.DTO;

public record ClassDto
{
       [JsonPropertyName("class_id")]
       public long ClassId{get;set;}


        [JsonPropertyName("class_name")]
        public string ClassName{get;set;}

        [JsonPropertyName("class_teacher")]
        public string ClassTeacher{get;set;}

        [JsonPropertyName("no_test")]
        public long NoTest {get;set;}

       

}