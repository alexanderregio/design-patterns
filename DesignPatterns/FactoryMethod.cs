using DesignPatterns.Auxiliares;

namespace DesignPatterns;

public static class FactoryMethod
{
    public static void CallExample()
    {
        var impostos = new List<ImpostoCreator>
        {
            new IptuEdificadoResidencialCreator(),
            new IptuEdificadoNaoResidencialCreator(),
            new IptuTerrenoCreator()
        };

        impostos.ForEach
        (i => Console.WriteLine($"O valor do {i} sobre {153_302.00m:C} é de {i.Calcular(153_302.00m):C}"));
    }
}

// FACTORY METHOD

/// <summary>
/// Classe abstrata para criar as instâncias concretas
/// </summary>
public abstract class ImpostoCreator : IImposto
{
    public abstract IImposto Create();

    public decimal Calcular(decimal valor)
    {
        return Create().Calcular(valor);
    }
}

/// <summary>
/// Classe concreta para cálculo do IPTU de imovéis edificados residenciais
/// </summary>
public sealed class IptuEdificadoResidencialCreator : ImpostoCreator
{
    public override IImposto Create()
    {
        return new IptuEdificadoResidencial();
    }

    public override string ToString()
    {
        return "IPTU para imovéis edificados residenciais";
    }
}

/// <summary>
/// Classe concreta para cálculo do IPTU de imovéis edificados NÃO residenciais
/// </summary>
public sealed class IptuEdificadoNaoResidencialCreator : ImpostoCreator
{
    public override IImposto Create()
    {
        return new IptuEdificadoNaoResidencial();
    }

    public override string ToString()
    {
        return "IPTU para imovéis edificados não residenciais";
    }
}

/// <summary>
/// Classe concreta para cálculo do IPTU de terrenos e lotes NÃO edificados
/// </summary>
public sealed class IptuTerrenoCreator : ImpostoCreator
{
    public override IImposto Create()
    {
        return new IptuTerreno();
    }

    public override string ToString()
    {
        return "IPTU para terrenos e lotes não edificados";
    }
}