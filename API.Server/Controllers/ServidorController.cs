using API.Server.Dto;
using API.Server.Entity;
using API.Server.Infra;
using Microsoft.AspNetCore.Mvc;

namespace API.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        private readonly Context _context;

        public ServidorController(Context context)
        {
            _context = context;
        }

        [HttpPost]

        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(404), ProducesResponseType(429), ProducesResponseType(500)]
        public async Task<IActionResult> InsertServidor([FromBody] DtoServidor request)
        {
            try
            {
                _context.Servidor.Add(request);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }
     
        [HttpPost("{servidorid}/video")]
        //[Route("id")]

        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(404), ProducesResponseType(429), ProducesResponseType(500)]
        public async Task<IActionResult> InserirVideoServidorId(DtoVideo request,int servidorid)//[FromQuery] 
        {//listar por servidor id
            try
            {
                request.ServidorId = servidorid;
                _context.Video.Add(request);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]

        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(404), ProducesResponseType(429), ProducesResponseType(500)]
        public async Task<IActionResult> GetServidores()
        {//listar todos

            var response = _context.Servidor.ToList();
            return Ok(response);

        }
        [HttpGet("{servidorid}/video")]
        //[Route("id")]

        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(404), ProducesResponseType(429), ProducesResponseType(500)]
        public async Task<IActionResult> GetServidorId(int servidorid)//[FromQuery] 
        {//listar por servidor id

            IEnumerable<Video> result = _context.Video.Where(x => x.ServidorId == servidorid).ToList();
            List<DtoVideoListResponse> listavideo = new List<DtoVideoListResponse>();
            foreach (var item in result)
            {
                DtoVideoListResponse response = new DtoVideoListResponse();
                response.Id = item.Id;
                response.Url = item.Url;
                response.Register = item.Register;
                listavideo.Add(response);
              
            }
            return Ok(listavideo);

        }
    }
}
