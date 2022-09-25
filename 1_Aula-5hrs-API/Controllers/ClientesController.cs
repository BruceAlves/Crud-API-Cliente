using _1_Aula_5hrs_API.Request;
using AutoMapper;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace _1_Aula_5hrs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get")]
        public IEnumerable<Cliente> GetProdutos()
        {
            var lista = _clienteRepository.BuscarCliente();

            return lista; 
        }

        [HttpPost]
        [Route("inserir")] 
        public ActionResult CadastrarCliente([FromBody] JsonElement requestJson)
        {
            var request = JsonConvert.DeserializeObject<ClienteRequest>(requestJson.ToString());

            var cliente = _mapper.Map<Cliente>(request);

            var clienteCriado = _clienteRepository.CadastrarCliente(cliente);

            return Ok(clienteCriado);

        }

        [HttpPost]
        [Route("update")]
        public ActionResult EditarCliente([FromBody] JsonElement requestJson)
        {
            var request = JsonConvert.DeserializeObject<ClienteRequest>(requestJson.ToString());

            var cliente = _mapper.Map<Cliente>(request);

            var clienteEditado = _clienteRepository.EditarCliente(cliente);

            return Ok(clienteEditado);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeletarCliente(int id)
        {
             _clienteRepository.DeletarCliente(id);
        }

    }
}
