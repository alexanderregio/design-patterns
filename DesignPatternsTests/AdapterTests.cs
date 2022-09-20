using DesignPatterns;
using DesignPatterns.Auxiliares;

namespace DesignPatternsTests;

public class AdapterTests
{

    [Theory]
    [ClassData(typeof(IImpostoAdapter_AdapterImpostoResult))]
    [Trait(nameof(IImpostoAdapter.AdapterImpostoResult), "AdapterImpostoResult")]
    public void AdapterImpostoResult(IImposto imposto, decimal valor, ImpostoResult impostoResultExpected)
    {
        var impostoAdapter = new ImpostoAdapter();

        var impostoResultActual = impostoAdapter.AdapterImpostoResult(imposto, valor);

        Assert.Equal(impostoResultExpected.Nome, impostoResultActual.Nome);
        Assert.Equal(impostoResultExpected.Valor, impostoResultActual.Valor);
    }

    private class IImpostoAdapter_AdapterImpostoResult : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new IptuEdificadoResidencialCreator(), 76_651.00m, new ImpostoResult { Nome = "IptuEdificadoResidencial", Valor = 459.90600m } };
            yield return new object[] { new IptuEdificadoNaoResidencialCreator(), 28_741.50m, new ImpostoResult { Nome = "IptuEdificadoNaoResidencial", Valor = 344.89800m } };
            yield return new object[] { new IptuTerrenoCreator(), 38_323.00m, new ImpostoResult { Nome = "IptuTerreno", Valor = 383.23m } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}