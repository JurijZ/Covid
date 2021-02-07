using API.DTOs;
using API.Interfaces;
using API.POCOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        private IDataService dataService;

        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet()]
        public DataResponse GetData(int id, int pageSize)
        {
            return dataService.GetData(id, pageSize);
        }

        [HttpPost()]
        public NewCaseResponse NewCase(TypedCase newCase)
        {
            var resp = dataService.NewData(newCase);

            return resp;
        }

    }
}
