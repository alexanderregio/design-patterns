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

/// <summary>
/// Interface que possui o contrato ValorAplicado com responsabilidade de retornar o valor do imposto aplicado
/// </summary>
public interface IImposto { public decimal Calcular(decimal valor); }

/// <summary>
/// Classe concreta que herda da interface Imposto
/// Responsável por calcular o IPTU conforme o valor do venal do imóvel
/// Obs.: esta classe se apoia somente no cálculo do IPTU de imovéis edificados residenciais
/// </summary>
public class IptuEdificadoResidencial : IImposto
{
    public decimal Calcular(decimal valor)
    {
        return valor switch
        {
            <= decimal.Zero => decimal.Zero,
            > 0.01m and <= 153_302 => valor * 0.006m,
            > 153_302 and <= 383_258 => valor * 0.007m,
            > 383_258 and <= 670_705 => valor * 0.0075m,
            > 670_705 and <= 1_149_786 => valor * 0.0080m,
            > 1_149_786 and <= 1_533_050 => valor * 0.0085m,
            > 1_533_050 and <= 1_916_313 => valor * 0.0090m,
            _ => valor * 0.010m
        };
    }
}

/// <summary>
/// Classe concreta que herda da interface Imposto
/// Responsável por calcular o IPTU conforme o valor do venal do imóvel
/// Obs.: esta classe se apoia somente no cálculo do IPTU de imovéis edificados NÃO residenciais
/// </summary>
public class IptuEdificadoNaoResidencial : IImposto
{
    public decimal Calcular(decimal valor)
    {
        return valor switch
        {
            <= decimal.Zero => decimal.Zero,
            > 0.01m and <= 57_483 => valor * 0.012m,
            > 57_483 and <= 191_626 => valor * 0.013m,
            > 191_626 and <= 958_152 => valor * 0.014m,
            > 958_152 and <= 1_916_313 => valor * 0.015m,
            _ => valor * 0.016m
        };
    }
}

/// <summary>
/// Classe concreta que herda da interface Imposto
/// Responsável por calcular o IPTU conforme o valor do venal do imóvel
/// Obs.: esta classe se apoia somente no cálculo do IPTU de terrenos e lotes NÃO edificados
/// </summary>
public class IptuTerreno : IImposto
{
    public decimal Calcular(decimal valor)
    {
        return valor switch
        {
            <= decimal.Zero => decimal.Zero,
            > 0.01m and <= 76_646 => valor * 0.01m,
            > 76_646 and <= 574_890 => valor * 0.016m,
            > 574_890 and <= 1_149_786 => valor * 0.02m,
            > 1_149_786 and <= 1_916_313 => valor * 0.025m,
            _ => valor * 0.03m
        };
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