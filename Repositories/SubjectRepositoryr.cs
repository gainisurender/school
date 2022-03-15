
using Dapper;
using System.Data;
using School.Utilities;
using School.DTO;
using School.Models;

namespace School.Repositories;


public interface ISubjectRepository
{

    // Task<Subject> GetById(long StudentId);

     Task<List<Subject>> GetList();

    Task<List<SubjectDto>> GetListSubject(long Id);
   // Task<List<Subject>> GetList();
    Task<Subject> GetById(long subject_id);
}


public class SubjectRepository : BaseRepository, ISubjectRepository
{

    public SubjectRepository(IConfiguration config) : base(config)

    {

    }


    public async Task<Subject> GetById(long SubjectId)
    {
        var query = $@"SELECT * FROM ""{TableNames.subject}""
        WHERE subject_id = @SubjectId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Subject>(query,
            new
            {
                SubjectId = SubjectId
            });
    }

    public async Task<List<Subject>> GetList()
    {
       var query = $@"SELECT * FROM ""{TableNames.subject}""";
        
        using (var con = NewConnection)
            return (await con.QueryAsync<Subject>(query)).AsList();
    }

    public async Task<List<SubjectDto>> GetListSubject(long Id)
    {
       var query = $@"SELECT s.* FROM {TableNames.student_subject} ss
         LEFT JOIN {TableNames.subject} s ON s.subject_id = ss.subject_id
         WHERE ss.student_id = @Id";

         using (var con = NewConnection)

        {
            return (await con.QueryAsync<SubjectDto>(query, new { Id })).AsList();
        }
     
    }

   
}

//     public Task<List<Subject>> GetListSubject(long Id)
//     {

//         var query = $@"SELECT s.* FROM {TableNames.student_subject} ss
//          LEFT JOIN {TableNames.subject} s ON s.subject_id = ss.subject_id
//         WHERE ss.student_id = @Id";

//         using (var con = NewConnection)

//         {
//             return (await con.QueryAsync<Subject>(query, new { Id })).AsList();
//         }
//     }
// }
