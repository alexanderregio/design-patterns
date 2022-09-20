namespace DesignPatterns.Auxiliares;

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
