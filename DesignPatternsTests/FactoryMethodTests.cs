using DesignPatterns;
using DesignPatterns.Auxiliares;

namespace DesignPatternsTests;

public class FactoryMethodTests
{
    [Theory]
    [ClassData(typeof(Imposto_Calcular))]
    [Trait(nameof(IImposto.Calcular), "IPTU")]
    public void Imposto_Iptu(ImpostoCreator imposto, decimal valor, decimal impostoExpected)
    {
        var impostoActual = imposto.Calcular(valor);

        Assert.Equal(impostoExpected, impostoActual, 2);
    }

    private class Imposto_Calcular : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Imóveis edificados residenciais

            // retorno zerado
            yield return new object[] { new IptuEdificadoResidencialCreator(), decimal.Zero, decimal.Zero };
            yield return new object[] { new IptuEdificadoResidencialCreator(), -13.13m, decimal.Zero };

            // faixa 0,60%
            yield return new object[] { new IptuEdificadoResidencialCreator(), 76_651.00m, 459.91m };
            yield return new object[] { new IptuEdificadoResidencialCreator(), 153_302.00m, 919.81m };

            // faixa 0,70%
            yield return new object[] { new IptuEdificadoResidencialCreator(), 153_302.01m, 1_073.11m };
            yield return new object[] { new IptuEdificadoResidencialCreator(), 268_280.00m, 1_877.96m };
            yield return new object[] { new IptuEdificadoResidencialCreator(), 383_258.00, 2_682.81m };

            // faixa máxima 1,00%
            yield return new object[] { new IptuEdificadoResidencialCreator(), 1_916_313.01m, 19_163.13m };

            // Imóveis edificados não residenciais

            // retorno zerado
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), decimal.Zero, decimal.Zero };
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), -13.13m, decimal.Zero };

            // faixa 1,20%
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), 28_741.50m, 344.90m };
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), 57_483.00m, 689.80m };

            // faixa 1,30%
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), 57_483.01m, 747.28m };
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), 124_554.50m, 1_619.21m };
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), 191_626.00m, 2_491.14m };

            // faixa máxima 1,60%
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), 1_916_313.01m, 30_661.01m };

            // Imóveis terrenos e lotes não edificados

            // retorno zerado
            yield return new object[] { new IptuTerrenoCreator(), decimal.Zero, decimal.Zero };
            yield return new object[] { new IptuTerrenoCreator(), -13.13m, decimal.Zero };

            // faixa 1,00%
            yield return new object[] { new IptuTerrenoCreator(), 38_323.00m, 383.23m };
            yield return new object[] { new IptuTerrenoCreator(), 76_646.00m, 766.46m };

            // faixa 1,60%
            yield return new object[] { new IptuTerrenoCreator(), 76_646.01m, 1_226.34m };
            yield return new object[] { new IptuTerrenoCreator(), 325_768.00m, 5_212.29m };
            yield return new object[] { new IptuTerrenoCreator(), 574_890.00m, 9_198.24m };

            // faixa máxima 3,00%
            yield return new object[] { new IptuTerrenoCreator(), 1_916_313.01m, 57_489.39m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}