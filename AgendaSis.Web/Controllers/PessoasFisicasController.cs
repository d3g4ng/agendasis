using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Application.Services.Pessoas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasFisicasController : ControllerBase
    {
        private readonly IPessoaFisicaService svc;

        public PessoasFisicasController(IPessoaFisicaService service)
        {
            svc = service;
        }

        // GET: api/PessoasFisicas
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PessoasFisicas/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PessoasFisicas
        [HttpPost]
        public async Task<PessoaFisicaResponseDto> Post([FromBody] PessoaFisicaRequestDto model)
        {
            var pessoa = await svc.CreateAsync(model);

            return pessoa;
        }

        // PUT: api/PessoasFisicas/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PessoaFisicaRequestDto model)
        {
            await svc.UpdateAsync(id, model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
