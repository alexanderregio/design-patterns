namespace DesignPatterns.Auxiliares;

/// <summary>
/// Interface que possui o contrato ValorAplicado com responsabilidade de retornar o valor do imposto aplicado
/// </summary>
public interface IImposto { public decimal Calcular(decimal valor); }
