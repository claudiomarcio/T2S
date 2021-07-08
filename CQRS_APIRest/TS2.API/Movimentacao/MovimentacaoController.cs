using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Net;
using T2S.Domain.Core;
using T2S.Application.Movimentacao.Query.ObterMovimentacao;
using T2S.Application.Movimentacao.Command.RegistrarMovimentacao;
using T2S.Application.Movimentacao.Query.ObterMovimentacaoAgrupada;
using System.IO;

namespace T2S.API.Movimentacao
{
    [Route("api/")]
    public class MovimentacaoController : Controller
    {
        private readonly IMediator _mediator;

        public MovimentacaoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Obtem uma movimentacao por Id.
        /// </summary>
        /// <param name="id">idenificador da movimentação</param>       
        [HttpGet("[controller]/movimentacao/{id}")]
        public async Task<object> Obter(Guid id)
        {
            var query = new ObterMovimentacaoQuery() { Id = id };
            var movimentacaoViewModel = await _mediator.Send(query);
            return Ok(movimentacaoViewModel);
        }

        /// <summary>
        /// Obtem movimentacoes agrupadas por cliente e tipo de movimentacao.
        /// </summary>        
        [HttpGet("[controller]/agrupadas")]
        public async Task<object> ObterMovimentacoesAgrupadas()
        {
            var query = new ObterMovimentacaoAgrupadaQuery();
            var movimentacaoViewModel = await _mediator.Send(query);
            return StatusCode(200,movimentacaoViewModel);
        }

        /// <summary>
        ///Cadastro de uma movimentação.
        /// </summary>
        /// <param name="registrarconteinerCommand">modelo registro de movimentação</param>
        /// <response code="201">Requisição criada com sucesso</response>
        /// <response code="400">sintaxe invalida values</response>
        /// <response code="404">não encontrado</response>
        /// <response code="500">Erro encontrdo</response>        
        [HttpPost("[controller]/movimentacao/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CadastrarConteiner([FromBody] RegistrarMovimentacaoCommand registrarconteinerCommand)
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

