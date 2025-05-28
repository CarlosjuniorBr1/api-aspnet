using ApiLojaManoel.DTOs;
using ApiLojaManoel.models;

namespace ApiLojaManoel.Interfaces.services;

public interface IEmbalagemService
{
    List<CaixaUsadaDto> ProcessarPedido(List<Produto> produtos);
    List<Caixa> ObterCaixasDisponiveis();
    object ValidarEmbalagem(object caixas);
} 