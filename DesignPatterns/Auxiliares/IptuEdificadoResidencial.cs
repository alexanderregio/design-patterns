namespace DesignPatterns.Auxiliares;

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
