using LR3.Models;

namespace LR3.Logic;

/// <summary>
/// Клас, що реалізує логіку матричної гри
/// </summary>
public class GameEngine
{
    private readonly Random _random = new();
    
    /// <summary>
    /// Гравець-атакуючий (Хакер)
    /// </summary>
    public Player Attacker { get; private set; }

    /// <summary>
    /// Гравець-захисник (Служба ІБ)
    /// </summary>
    public Player Defender { get; private set; }

    /// <summary>
    /// Матриця виграшів гри
    /// </summary>
    public GameMatrix Matrix { get; private set; }

    /// <summary>
    /// Історія результатів раундів
    /// </summary>
    public List<GameResult> History { get; private set; }

    /// <summary>
    /// Лічильник раундів
    /// </summary>
    private int _roundCounter;

    public GameEngine()
    {
        // Ініціалізація матриці 3x4
        Matrix = new GameMatrix(3, 4);
        Matrix.InitializeDefault();

        // Ініціалізація атакуючого (Хакер)
        Attacker = new Player("Хакер");
        Attacker.AddStrategy(new GameStrategy("A1", "Фішингова атака"));
        Attacker.AddStrategy(new GameStrategy("A2", "Brute-force атака"));
        Attacker.AddStrategy(new GameStrategy("A3", "SQL-injection атака"));

        // Ініціалізація захисника (Служба ІБ)
        Defender = new Player("Захисник");
        Defender.AddStrategy(new GameStrategy("B1", "Посилення паролів"));
        Defender.AddStrategy(new GameStrategy("B2", "Двофакторна автентифікація (2FA)"));
        Defender.AddStrategy(new GameStrategy("B3", "Фільтрація пошти + тренінг"));
        Defender.AddStrategy(new GameStrategy("B4", "Web Application Firewall (WAF)"));

        History = [];
        _roundCounter = 0;
    }

    /// <summary>
    /// Виконує раунд гри: атакуючий обирає стратегію, захисник відповідає рандомною
    /// </summary>
    /// <param name="attackerStrategyIndex">Індекс стратегії атакуючого (0-2)</param>
    /// <returns>Результат раунду</returns>
    public GameResult PlayRound(int attackerStrategyIndex)
    {
        if (attackerStrategyIndex < 0 || attackerStrategyIndex >= Attacker.Strategies.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(attackerStrategyIndex), 
                $"Індекс стратегії атакуючого має бути в діапазоні 0-{Attacker.Strategies.Count - 1}.");
        }

        // Атакуючий обирає стратегію
        Attacker.SelectedStrategyIndex = attackerStrategyIndex;
        var attackerStrategy = Attacker.GetSelectedStrategy()!;

        // Захисник обирає випадкову стратегію
        var defenderStrategyIndex = GetRandomDefenderStrategy();
        Defender.SelectedStrategyIndex = defenderStrategyIndex;
        var defenderStrategy = Defender.GetSelectedStrategy()!;

        // Отримуємо виграш з матриці
        var payoff = Matrix[attackerStrategyIndex, defenderStrategyIndex];

        // Створюємо результат раунду
        _roundCounter++;
        var result = new GameResult(
            attackerStrategyIndex,
            attackerStrategy.Name,
            defenderStrategyIndex,
            defenderStrategy.Name,
            payoff,
            _roundCounter
        );

        // Додаємо в історію
        History.Add(result);

        return result;
    }

    /// <summary>
    /// Генерує випадковий вибір стратегії для захисника
    /// </summary>
    /// <returns>Індекс стратегії захисника (0-3)</returns>
    public int GetRandomDefenderStrategy()
    {
        return _random.Next(0, Defender.Strategies.Count);
    }

    /// <summary>
    /// Обчислює оптимальну стратегію для атакуючого за принципом максиміну
    /// Максимін: для кожної стратегії знаходимо мінімальний виграш,
    /// потім обираємо стратегію з максимальним мінімальним виграшем
    /// </summary>
    /// <returns>Кортеж (індекс оптимальної стратегії, гарантований виграш, аналіз всіх стратегій)</returns>
    public (int OptimalStrategyIndex, int GuaranteedPayoff, Dictionary<int, int> MinPayoffs) CalculateMaximin()
    {
        var minPayoffs = new Dictionary<int, int>();

        // Для кожної стратегії атакуючого знаходимо мінімальний виграш
        for (var i = 0; i < Matrix.RowCount; i++)
        {
            var minPayoff = int.MaxValue;
            
            for (var j = 0; j < Matrix.ColumnCount; j++)
            {
                var payoff = Matrix[i, j];
                if (payoff < minPayoff)
                {
                    minPayoff = payoff;
                }
            }
            
            minPayoffs[i] = minPayoff;
        }

        // Знаходимо стратегію з максимальним мінімальним виграшем
        var optimalStrategyIndex = 0;
        var maxMinPayoff = int.MinValue;

        foreach (var kvp in minPayoffs)
        {
            if (kvp.Value > maxMinPayoff)
            {
                maxMinPayoff = kvp.Value;
                optimalStrategyIndex = kvp.Key;
            }
        }

        return (optimalStrategyIndex, maxMinPayoff, minPayoffs);
    }

    /// <summary>
    /// Отримує оптимальну стратегію атакуючого
    /// </summary>
    /// <returns>Оптимальна стратегія</returns>
    public GameStrategy GetOptimalStrategy()
    {
        var (optimalIndex, _, _) = CalculateMaximin();
        return Attacker.Strategies[optimalIndex];
    }

    /// <summary>
    /// Отримує детальний аналіз максиміну у текстовому форматі
    /// </summary>
    /// <returns>Текстовий опис аналізу</returns>
    public string GetMaximinAnalysis()
    {
        var (optimalIndex, guaranteedPayoff, minPayoffs) = CalculateMaximin();
        var optimalStrategy = Attacker.Strategies[optimalIndex];

        var sb = new System.Text.StringBuilder();
        
        sb.AppendLine("АНАЛІЗ СТРАТЕГІЙ ЗА ПРИНЦИПОМ МАКСИМІНУ");
        sb.AppendLine();

        // Аналіз кожної стратегії
        foreach (var kvp in minPayoffs.OrderBy(x => x.Key))
        {
            var strategy = Attacker.Strategies[kvp.Key];
            var minPayoff = kvp.Value;
            var isOptimal = kvp.Key == optimalIndex;

            sb.Append($"{strategy.Name} ({strategy.Description}) - можливі виграші: ");
            
            var payoffs = new List<string>();
            for (var j = 0; j < Matrix.ColumnCount; j++)
            {
                var payoff = Matrix[kvp.Key, j];
                var marker = payoff == minPayoff ? $"{payoff}*" : $"{payoff}";
                payoffs.Add(marker);
            }
            sb.Append(string.Join(", ", payoffs));
            sb.Append($" балів. Мінімум: {minPayoff} балів.");
            
            if (isOptimal)
            {
                sb.Append(" [ОПТИМАЛЬНА]");
            }
            sb.AppendLine();
        }

        sb.AppendLine();
        sb.AppendLine($"РЕКОМЕНДАЦІЯ: Обрати стратегію {optimalStrategy.Name} ({optimalStrategy.Description}), яка гарантує мінімум {guaranteedPayoff} балів навіть у найгіршому випадку.");
        sb.AppendLine();
        sb.AppendLine("ПОЯСНЕННЯ: Принцип максиміну полягає в тому, щоб для кожної стратегії знайти найгірший можливий результат (мінімальний виграш), а потім обрати ту стратегію, у якої цей \"найгірший результат\" є найкращим (максимум з мінімумів). Це забезпечує гарантований мінімальний виграш незалежно від дій противника.");
        sb.AppendLine();
        sb.AppendLine("Примітка: зірочкою (*) позначено мінімальний виграш для кожної стратегії.");

        return sb.ToString();
    }

    /// <summary>
    /// Очищає історію раундів
    /// </summary>
    public void ClearHistory()
    {
        History.Clear();
        _roundCounter = 0;
    }

    /// <summary>
    /// Отримує статистику по історії ігор
    /// </summary>
    /// <returns>Кортеж (середній виграш, найуспішніша стратегія, кількість використань кожної стратегії)</returns>
    public (double AveragePayoff, string MostSuccessfulStrategy, Dictionary<string, int> StrategyUsage) GetStatistics()
    {
        if (History.Count == 0)
        {
            return (0, "Немає даних", new Dictionary<string, int>());
        }

        // Середній виграш
        var averagePayoff = History.Average(r => r.Payoff);

        // Підрахунок використання стратегій
        var strategyUsage = new Dictionary<string, int>();
        var strategyTotalPayoff = new Dictionary<string, int>();

        foreach (var result in History)
        {
            var strategyName = result.AttackerStrategyName;
            
            if (!strategyUsage.ContainsKey(strategyName))
            {
                strategyUsage[strategyName] = 0;
                strategyTotalPayoff[strategyName] = 0;
            }

            strategyUsage[strategyName]++;
            strategyTotalPayoff[strategyName] += result.Payoff;
        }

        // Найуспішніша стратегія (по середньому виграшу)
        var mostSuccessful = "";
        var maxAverage = double.MinValue;

        foreach (var strategyName in strategyUsage.Keys)
        {
            var average = (double)strategyTotalPayoff[strategyName] / strategyUsage[strategyName];
            if (average > maxAverage)
            {
                maxAverage = average;
                mostSuccessful = strategyName;
            }
        }

        return (averagePayoff, mostSuccessful, strategyUsage);
    }

    /// <summary>
    /// Скидає матрицю до початкових значень
    /// </summary>
    public void ResetMatrixToDefault()
    {
        Matrix.InitializeDefault();
    }
}
