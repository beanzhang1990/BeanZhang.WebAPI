using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeanZhang.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentModelController : ControllerBase
    {
        public static readonly List<StudentModel> StudentModels = new List<StudentModel>()
        {
            new StudentModel(){Id=1, Name="张三",Sex="男",Age=25 },
            new StudentModel(){Id=2, Name="李四",Sex="男",Age=24 },
            new StudentModel(){Id=3, Name="王五",Sex="男",Age=23 }
        };

        [HttpGet("{id}")]
        public ResponseModel<List<StudentModel>> GetStudentModel([FromRoute] int id)
        {
            var response = new ResponseModel<List<StudentModel>>();

            response.data = StudentModels.Where(t => t.Id == id).ToList();

            return response;
        }

        [HttpGet]
        public ResponseModel<List<StudentModel>> GetStudentModelList()
        {
            var response = new ResponseModel<List<StudentModel>>();

            response.data = StudentModels;

            return response;
        }

        [HttpPost]
        public ResponseModel<string> InsertStudentModel([FromBody] StudentModel StudentModel)
        {
            StudentModels.Add(StudentModel);

            return new ResponseModel<string>();
        }

        [HttpPut("{id}")]
        public ResponseModel<string> UpdateStudentModel([FromRoute] int id, [FromBody] StudentModel StudentModel)
        {
            for (int i = 0; i < StudentModels.Count; i++)
            {
                if (StudentModels[i].Id == id)
                {
                    StudentModels[i].Name = StudentModel.Name;
                    StudentModels[i].Sex = StudentModel.Sex;
                    StudentModels[i].Age = StudentModel.Age;
                }
            }

            return new ResponseModel<string>();
        }

        [HttpDelete("{id}")]
        public ResponseModel<string> DeleteStudentModel([FromRoute] int id)
        {
            for (int i = 0; i < StudentModels.Count; i++)
            {
                if (StudentModels[i].Id == id)
                {
                    StudentModels.RemoveAt(i);
                }
            }

            return new ResponseModel<string>();
        }
    }

}
