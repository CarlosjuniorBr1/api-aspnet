namespace ApiLojaManoel.Service;

using ApiLojaManoel.models;
using ApiLojaManoel.DTOs;
using ApiLojaManoel.DTOs.Request;

using ApiLojaManoel.Interfaces.services;

public class EmbalagemService : IEmbalagemService
{
    private readonly List<Caixa> _caixasDisponiveis;

    public EmbalagemService()
    {
        _caixasDisponiveis = new List<Caixa>
        {
            new Caixa("Caixa 1", 30, 40, 80),  // Espaço adicionado
            new Caixa("Caixa 2", 80, 50, 40),  // Espaço adicionado
            new Caixa("Caixa 3", 50, 80, 60)   // Espaço adicionado
        };
    }

    public List<Caixa> ObterCaixasDisponiveis()
    {
        return _caixasDisponiveis;
    }

    public List<CaixaUsadaDto> ProcessarPedido(List<Produto> produtos)
    {
        var resultado = new List<CaixaUsadaDto>();
        var produtosRestantes = new List<Produto>(produtos);

        while (produtosRestantes.Any())
        {
            var melhorCombinacao = EncontrarMelhorCombinacao(produtosRestantes);
            
            if (melhorCombinacao.Produtos.Any())
            {
                resultado.Add(new CaixaUsadaDto
                {
                    CaixaId = melhorCombinacao.Caixa.Id,
                    ProdutosId = melhorCombinacao.Produtos.Select(p => p.ProdutoId).ToList()
                });

                // Remove produtos que já foram embalados
                foreach (var produto in melhorCombinacao.Produtos)
                {
                    produtosRestantes.Remove(produto);
                }
            }
            else
            {
                // Se não conseguiu embalar nenhum produto
                var primeiroProduto = produtosRestantes.First();
                
                resultado.Add(new CaixaUsadaDto
                {
                    CaixaId = null,
                    ProdutosId = new List<string> { primeiroProduto.ProdutoId },
                    
                });

                produtosRestantes.Remove(primeiroProduto);
            }
        }

        return resultado;
    }

    // Método para validar embalagem existente
    public List<CaixaUsadaDto> ValidarEmbalagem(List<CaixaValidacaoDto> caixasExistentes)
    {
        var resultado = new List<CaixaUsadaDto>();

        foreach (var caixa in caixasExistentes)
        {
            resultado.Add(new CaixaUsadaDto
            {
                CaixaId = caixa.CaixaId,
                ProdutosId = caixa.Produtos,
               
            });
        }

        return resultado;
    }

    public object ValidarEmbalagem(object caixas)
    {
        throw new NotImplementedException();
    }

    // ... resto dos métodos permanecem iguais
    private (Caixa Caixa, List<Produto> Produtos) EncontrarMelhorCombinacao(List<Produto> produtos)
    {
        var melhorCombinacao = (Caixa: (Caixa)null, Produtos: new List<Produto>());
        var melhorEficiencia = 0.0;

        foreach (var caixa in _caixasDisponiveis)
        {
            var combinacao = EncontrarMelhorCombinacaoParaCaixa(caixa, produtos);
            
            if (combinacao.Produtos.Any())
            {
                var volumeUtilizado = combinacao.Produtos.Sum(p => p.Volume);
                var eficiencia = volumeUtilizado / caixa.Volume;

                if (eficiencia > melhorEficiencia)
                {
                    melhorEficiencia = eficiencia;
                    melhorCombinacao = (caixa, combinacao.Produtos);
                }
            }
        }

        return melhorCombinacao;
    }

    private (List<Produto> Produtos, double volumeRestante) EncontrarMelhorCombinacaoParaCaixa(Caixa caixa, List<Produto> produtos)
    {
        var produtosCabem = new List<Produto>();
        var volumeRestante = caixa.Volume;

        var produtosOrdenados = produtos.OrderByDescending(p => p.Volume).ToList();

        foreach (var produto in produtosOrdenados)
        {
            if (ProdutoCabeNaCaixa(produto, caixa) && produto.Volume <= volumeRestante)
            {
                produtosCabem.Add(produto);
                volumeRestante -= produto.Volume;
            }
        }

        return (produtosCabem, volumeRestante);
    }

    private bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
    {
        var dimensoesProduto = new[] { produto.Altura, produto.Largura, produto.Comprimento };
        var dimensoesCaixa = new[] { caixa.Altura, caixa.Largura, caixa.Comprimento };

        return TentarOrientacoes(dimensoesProduto, dimensoesCaixa);
    }

    private bool TentarOrientacoes(double[] produto, double[] caixa)
    {
        var permutacoes = new[]
        {
            new[] { produto[0], produto[1], produto[2] },
            new[] { produto[0], produto[2], produto[1] },
            new[] { produto[1], produto[0], produto[2] },
            new[] { produto[1], produto[2], produto[0] },
            new[] { produto[2], produto[0], produto[1] },
            new[] { produto[2], produto[1], produto[0] }
        };

        return permutacoes.Any(p => 
            p[0] <= caixa[0] && p[1] <= caixa[1] && p[2] <= caixa[2]);
    }
}