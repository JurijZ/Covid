using System.Threading.Tasks;
using API.Interfaces;
using Chatty.Api.Hubs;
using Chatty.Api.Hubs.Clients;
using Chatty.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chatty.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpPost()]
        public ActionResult Reload(string fileName)
        {
            fileService.Load(fileName);
            return Ok();
        }
    }
}
