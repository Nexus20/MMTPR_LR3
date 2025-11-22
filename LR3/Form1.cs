using LR3.Logic;
using LR3.Models;

namespace LR3;

public partial class Form1 : Form
{
    private readonly GameEngine _gameEngine;

    public Form1()
    {
        InitializeComponent();
        _gameEngine = new GameEngine();
        InitializeMatrixGrid();
    }

    /// <summary>
    /// Ініціалізує DataGridView матриці початковими значеннями
    /// </summary>
    private void InitializeMatrixGrid()
    {
        // Встановлюємо заголовки рядків
        dataGridViewMatrix.Rows.Clear();
        dataGridViewMatrix.Rows.Add("A1 (Фішинг)");
        dataGridViewMatrix.Rows.Add("A2 (Brute-force)");
        dataGridViewMatrix.Rows.Add("A3 (SQL-injection)");

        // Заповнюємо значеннями з матриці
        UpdateMatrixGrid();
    }

    /// <summary>
    /// Оновлює DataGridView матриці значеннями з GameEngine
    /// </summary>
    private void UpdateMatrixGrid()
    {
        for (var i = 0; i < _gameEngine.Matrix.RowCount; i++)
        {
            for (var j = 0; j < _gameEngine.Matrix.ColumnCount; j++)
            {
                dataGridViewMatrix.Rows[i].Cells[j].Value = _gameEngine.Matrix[i, j];
            }
        }
    }

    /// <summary>
    /// Обробник натискання кнопки "Виконати атаку"
    /// </summary>
    private void BtnExecuteAttack_Click(object? sender, EventArgs e)
    {
        // Визначаємо обрану стратегію
        var selectedStrategyIndex = -1;
        if (radioButtonA1.Checked) selectedStrategyIndex = 0;
        else if (radioButtonA2.Checked) selectedStrategyIndex = 1;
        else if (radioButtonA3.Checked) selectedStrategyIndex = 2;

        if (selectedStrategyIndex == -1)
        {
            MessageBox.Show("Будь ласка, оберіть стратегію атаки!", "Помилка", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Виконуємо раунд
            var result = _gameEngine.PlayRound(selectedStrategyIndex);

            // Відображаємо результати
            var attackerStrategy = _gameEngine.Attacker.Strategies[result.AttackerStrategyIndex];
            var defenderStrategy = _gameEngine.Defender.Strategies[result.DefenderStrategyIndex];

            labelAttackerChoice.Text = $"Хакер обрав: {attackerStrategy.Name} ({attackerStrategy.Description})";
            labelDefenderChoice.Text = $"Захисник обрав: {defenderStrategy.Name} ({defenderStrategy.Description})";
            labelPayoff.Text = $"Результат: {result.Payoff} балів (0 = захист, 10 = атака)";
            labelPayoff.ForeColor = result.Payoff >= 5 ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69);

            // Оновлюємо прогрес-бар
            progressBarPayoff.Value = Math.Min(result.Payoff, 10);

            // Додаємо в історію
            UpdateHistoryGrid();
            UpdateStatistics();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка під час виконання атаки: {ex.Message}", "Помилка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Оновлює DataGridView історії
    /// </summary>
    private void UpdateHistoryGrid()
    {
        dataGridViewHistory.Rows.Clear();
        
        foreach (var result in _gameEngine.History)
        {
            var attackerStrategy = _gameEngine.Attacker.Strategies[result.AttackerStrategyIndex];
            var defenderStrategy = _gameEngine.Defender.Strategies[result.DefenderStrategyIndex];
            
            dataGridViewHistory.Rows.Add(
                result.RoundNumber,
                $"{result.AttackerStrategyName} - {attackerStrategy.Description}",
                $"{result.DefenderStrategyName} - {defenderStrategy.Description}",
                $"{result.Payoff} балів"
            );
        }

        // Прокручуємо до останнього елемента
        if (dataGridViewHistory.Rows.Count > 0)
        {
            dataGridViewHistory.FirstDisplayedScrollingRowIndex = dataGridViewHistory.Rows.Count - 1;
        }
    }

    /// <summary>
    /// Оновлює статистику
    /// </summary>
    private void UpdateStatistics()
    {
        var (avgPayoff, mostSuccessful, usage) = _gameEngine.GetStatistics();
        labelStatistics.Text = $"Статистика: Раундів: {_gameEngine.History.Count} | " +
                               $"Середній виграш: {avgPayoff:F2} | " +
                               $"Найуспішніша: {mostSuccessful}";
    }

    /// <summary>
    /// Обробник натискання кнопки "Показати оптимальну стратегію"
    /// </summary>
    private void BtnShowOptimal_Click(object? sender, EventArgs e)
    {
        try
        {
            var analysis = _gameEngine.GetMaximinAnalysis();
            textBoxAnalysis.Text = analysis;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка при аналізі: {ex.Message}", "Помилка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Обробник натискання кнопки "Скинути до початкових"
    /// </summary>
    private void BtnResetMatrix_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("Скинути матрицю до початкових значень?", "Підтвердження",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _gameEngine.ResetMatrixToDefault();
            UpdateMatrixGrid();
            MessageBox.Show("Матрицю скинуто до початкових значень.", "Успіх",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    /// <summary>
    /// Обробник натискання кнопки "Очистити історію"
    /// </summary>
    private void BtnClearHistory_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("Очистити всю історію раундів?", "Підтвердження",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _gameEngine.ClearHistory();
            dataGridViewHistory.Rows.Clear();
            labelStatistics.Text = "Статистика: Раундів: 0 | Середній виграш: 0.00";
            
            // Очищаємо результати раунду
            labelAttackerChoice.Text = "Хакер обрав: -";
            labelDefenderChoice.Text = "Захисник обрав: -";
            labelPayoff.Text = "Результат: - (0 = захист, 10 = атака)";
            progressBarPayoff.Value = 0;
        }
    }

    /// <summary>
    /// Обробник зміни значень в матриці
    /// </summary>
    private void DataGridViewMatrix_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        try
        {
            var cellValue = dataGridViewMatrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cellValue != null && int.TryParse(cellValue.ToString(), out var value))
            {
                _gameEngine.Matrix[e.RowIndex, e.ColumnIndex] = value;
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректне ціле число.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UpdateMatrixGrid(); // Відновлюємо попереднє значення
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка при оновленні матриці: {ex.Message}", "Помилка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            UpdateMatrixGrid(); // Відновлюємо попереднє значення
        }
    }
}