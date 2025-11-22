namespace LR3.Models;

/// <summary>
/// Представляє гравця в матричній грі
/// </summary>
public class Player
{
    /// <summary>
    /// Ім'я гравця
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Список доступних стратегій для гравця
    /// </summary>
    public List<GameStrategy> Strategies { get; set; }

    /// <summary>
    /// Індекс обраної стратегії
    /// </summary>
    public int SelectedStrategyIndex { get; set; }

    public Player(string name)
    {
        Name = name;
        Strategies = [];
        SelectedStrategyIndex = -1;
    }

    /// <summary>
    /// Додає стратегію до списку доступних
    /// </summary>
    public void AddStrategy(GameStrategy strategy)
    {
        Strategies.Add(strategy);
    }

    /// <summary>
    /// Отримує обрану стратегію
    /// </summary>
    public GameStrategy? GetSelectedStrategy()
    {
        if (SelectedStrategyIndex >= 0 && SelectedStrategyIndex < Strategies.Count)
        {
            return Strategies[SelectedStrategyIndex];
        }
        return null;
    }
}