// Controller corrigido
namespace ApiLojaManoel.Controllers;

using Microsoft.AspNetCore.Mvc;
using ApiLojaManoel.DTOs;
using ApiLojaManoel.Models;
using ApiLojaManoel.models;
using ApiLojaManoel.Interfaces;
using ApiLojaManoel.Interfaces.services;
using ApiLojaManoel.DTOs.Request;

[ApiController]
[Route("api/[controller]")]
public class EmbalagemController : ControllerBase
{
    private readonly IEmbalagemService _embalagemService;
    private readonly IPedidoRepository _pedidoRepository;

    public EmbalagemController(IEmbalagemService embalagemService, IPedidoRepository pedidoRepository)
    {
        _embalagemService = embalagemService;
        _pedidoRepository = pedidoRepository;
    }

    [HttpPost("processar-pedidos")]
    public async Task<ActionResult<ProcessarPedidosResponseDto>> ProcessarPedidos([FromBody] ProcessarPedidosRequestDto request)
    {
        try
        {
            var pedidos = new List<PedidoResponseDto>();

            for (int i = 0; i < request.Pedidos.Count; i++)
            {
                var pedidoRequest = request.Pedidos[i];
                
                // Converte DTOs para entidades
                var produtos = pedidoRequest.Produtos.Select(p =>
                    new Produto(
                        p.ProdutoId,
                        p.Dimensoes.Altura,
                        p.Dimensoes.Largura,
                        p.Dimensoes.Comprimento
                    )).ToList();

                // Cria o pedido
                var pedido = new Pedido { Produtos = produtos };

                // Salva no banco
                var pedidoSalvo = await _pedidoRepository.AdicionarAsync(pedido);

                // Processa a embalagem
                var caixasUsadas = _embalagemService.ProcessarPedido(produtos);

                pedidos.Add(new PedidoResponseDto
                {
                    PedidoId = (int)pedidoSalvo.Id,
                    Caixas = caixasUsadas
                });
            }

            return Ok(new ProcessarPedidosResponseDto { Pedidos = pedidos });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao processar pedidos: {ex.Message}");
        }
    }

    [HttpGet("caixas-disponiveis")]
    public ActionResult<List<Caixa>> ObterCaixasDisponiveis()
    {
        var caixas = _embalagemService.ObterCaixasDisponiveis();
        return Ok(caixas);
    }

    
    [HttpGet("pedidos/{id}")]
    public async Task<ActionResult<Pedido>> ObterPedido(long id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);
        if (pedido == null)
            return NotFound($"Pedido com ID {id} não encontrado.");

        return Ok(pedido);
    }
    [HttpGet("pedidos")]
    public async Task<ActionResult<List<Pedido>>> ObterTodosPedidos()
    {
        var pedidos = await _pedidoRepository.ObterTodosAsync();
        return Ok(pedidos);
    }
}