namespace LR3.Models;

/// <summary>
/// Представляє результат одного раунду гри
/// </summary>
public class GameResult
{
    /// <summary>
    /// Індекс стратегії атакуючого
    /// </summary>
    public int AttackerStrategyIndex { get; set; }

    /// <summary>
    /// Назва стратегії атакуючого
    /// </summary>
    public string AttackerStrategyName { get; set; }

    /// <summary>
    /// Індекс стратегії захисника
    /// </summary>
    public int DefenderStrategyIndex { get; set; }

    /// <summary>
    /// Назва стратегії захисника
    /// </summary>
    public string DefenderStrategyName { get; set; }

    /// <summary>
    /// Виграш атакуючого (успіх атаки)
    /// </summary>
    public int Payoff { get; set; }

    /// <summary>
    /// Час раунду
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Номер раунду
    /// </summary>
    public int RoundNumber { get; set; }

    public GameResult(int attackerStrategyIndex, string attackerStrategyName,
        int defenderStrategyIndex, string defenderStrategyName,
        int payoff, int roundNumber)
    {
        AttackerStrategyIndex = attackerStrategyIndex;
        AttackerStrategyName = attackerStrategyName;
        DefenderStrategyIndex = defenderStrategyIndex;
        DefenderStrategyName = defenderStrategyName;
        Payoff = payoff;
        Timestamp = DateTime.Now;
        RoundNumber = roundNumber;
    }

    public override string ToString()
    {
        return $"Раунд {RoundNumber}: {AttackerStrategyName} vs {DefenderStrategyName} = {Payoff} балів";
    }
}