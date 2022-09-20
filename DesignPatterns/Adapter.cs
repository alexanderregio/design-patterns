using DesignPatterns.Auxiliares;

namespace DesignPatterns;

public static class Adapter
{
    public static void CallExample()
    {
        var impostoAdapter = new ImpostoAdapter();

        var impostos = new List<ImpostoCreator>
        {
            new IptuEdificadoResidencialCreator(),
            new IptuEdificadoNaoResidencialCreator(),
            new IptuTerrenoCreator()
        };

        var impostosResult = impostos
            .Select(i => impostoAdapter.AdapterImpostoResult(i, 153_302.00m))
            .ToList();

        impostosResult.ForEach
        (i => Console.WriteLine($"O valor do {i.Nome} sobre {153_302.00m:C} é de {i.Valor:C}"));
    }
}

// ADAPTER

/// <summary>
/// Classe que será adaptada do domínio do sistema
/// </summary>
public class ImpostoResult
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }
}

/// <summary>
/// Interface do adapter de imposto do domínio para imposto result
/// </summary>
public interface IImpostoAdapter
{
    ImpostoResult AdapterImpostoResult(IImposto imposto, decimal valor);
}

/// <summary>
/// Classe que implementa o método de adapatação entre domínio e resultado
/// </summary>
public class ImpostoAdapter : IImpostoAdapter
{
    public ImpostoResult AdapterImpostoResult(IImposto imposto, decimal valor)
    {
        return new ImpostoResult
        {
            Nome = imposto.GetType().Name.Replace("creator", "", StringComparison.InvariantCultureIgnoreCase),
            Valor = imposto.Calcular(valor)
        };
    }
}