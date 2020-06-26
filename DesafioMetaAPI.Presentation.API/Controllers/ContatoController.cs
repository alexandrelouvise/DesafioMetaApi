using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMetaAPI.Application.Interfaces;
using DesafioMetaAPI.Application.ViewModel;
using DesafioMetaAPI.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioMetaAPI.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoApplication _contatoApplication;
        public ContatoController(IContatoApplication contatoApplication)
        {
            _contatoApplication = contatoApplication;
        }

        /// <summary>
        /// Retorna uma lista de registros de acordo com o informado nos parâmetros
        ///page e size.Se estes parâmetros não forem passados na consulta, os seguintes
        ///valores padrão serão utilizados: page = 0 e size = 10'
        /// </summary>
        /// <returns></returns>
        // GET: api/<Contato>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ContatoViewModel> Get(int page = 0, int size = 10)
        {
            return  _contatoApplication.GetAll(page, size);
        }

        /// <summary>
        /// Retorna um único objeto do tipo Contato
        /// </summary>
        /// <param name="idContato"></param>
        /// <returns></returns>
        // GET api/<Contato>/5
        [HttpGet("{idContato}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public ContatoViewModel Get(int idContato)
        {
            return _contatoApplication.GetById(idContato);
        }

        /// <summary>
        /// Cria um novo objeto do tipo Contato
        /// </summary>
        /// <param name="contato"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        [HttpPost]
        public void Post([FromBody] ContatoViewModel contato)
        {
            _contatoApplication.Add(contato);
        }

        /// <summary>
        /// Altera um objeto do tipo Contato
        /// </summary>
        /// <param name="contato"></param>
        // PUT api/<Contato>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Put([FromBody] ContatoViewModel contato)
        {
            _contatoApplication.Update(contato);
        }

        /// <summary>
        /// Apaga um objeto do tipo Contato
        /// </summary>
        /// <param name="contato"></param>
        // DELETE api/<Contato>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete([FromBody]ContatoViewModel contato)
        {
            _contatoApplication.Remove(contato);
        }
    }
}
