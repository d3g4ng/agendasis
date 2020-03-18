using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSis.Application.Models.Agendas;
using AgendaSis.Application.Services.Agendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaService svc;

        public AgendasController(IAgendaService service)
        {
            svc = service;
        }

        // GET: api/PessoasFisicas
        [HttpGet]
        public async Task<IEnumerable<AgendaResponseDto>> Get()
        {
            return await svc.GetAllAsync();
        }

        // GET: api/PessoasFisicas/5
        [HttpGet("{id}", Name = "GetAgendaById")]
        public async Task<AgendaResponseDto> Get(int id)
        {
            return await svc.GetByIdAsync(id);
        }

        // POST: api/PessoasFisicas
        [HttpPost]
        public async Task<AgendaResponseDto> Post([FromBody] AgendaRequestDto model)
        {
            var agenda = await svc.CreateAsync(model);

            return agenda;
        }

        // PUT: api/PessoasFisicas/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AgendaRequestDto model)
        {
            await svc.UpdateAsync(id, model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await svc.DeleteAsync(id);
        }
    }
}
