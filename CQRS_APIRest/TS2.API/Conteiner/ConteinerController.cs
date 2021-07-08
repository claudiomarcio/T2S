using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using T2S.Application.Conteiner.Command.RegistrarConteiner;
using T2S.Application.Conteiner.Query.ObterConteiner;
using T2S.Domain.Core;

namespace T2S.API.Conteiner
{
    public class ConteinerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConteinerController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Obtem um conteiner por Id.
        /// </summary>
        /// <param name="id">idenificador do conteiner</param>
        [HttpGet, Route("conteiner/{id}")]
        public IActionResult Obter(Guid id)
        {
            var query = new ObterConteinerQuery() { Id = id };
            var conteinerViewModel = _mediator.Send(query);
            return Ok(conteinerViewModel);
        }


        /// <summary>
        ///Cadastro de um conteiner.
        /// </summary>
        /// <param name="registrarconteinerCommand">modelo registro de conteiner</param>
        /// <response code="201">Requisição criada com sucesso</response>
        /// <response code="400">sintaxe invalida values</response>
        /// <response code="404">não encontrado</response>
        /// <response code="500">Erro encontrdo</response>
        [HttpPost, Route("conteiner/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CadastrarConteiner([FromBody] RegistrarConteinerCommand registrarconteinerCommand)
        {
            try
            {
                await _mediator.Send(registrarconteinerCommand);
                return StatusCode(201);
            }
            catch (WebException webException)
            {
                var httpResponse = (HttpWebResponse)webException.Response;
                return StatusCode((int)httpResponse.StatusCode);
            }
            catch (BusinessRuleException ex)
            {
                return Ok(ex.Message);
            }           

        }       
    }
}

