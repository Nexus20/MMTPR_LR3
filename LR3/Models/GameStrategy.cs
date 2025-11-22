namespace LR3.Models;

/// <summary>
/// Представляє стратегію гравця в грі
/// </summary>
public class GameStrategy
{
    /// <summary>
    /// Назва стратегії (наприклад, "A1", "B2")
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Детальний опис стратегії
    /// </summary>
    public string Description { get; set; }

    public GameStrategy(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Name}: {Description}";
    }
}