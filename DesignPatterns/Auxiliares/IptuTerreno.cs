namespace DesignPatterns.Auxiliares;

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
