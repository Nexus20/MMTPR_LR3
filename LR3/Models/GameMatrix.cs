namespace LR3.Models;

/// <summary>
/// Представляє матрицю виграшів у антагоністичній грі
/// </summary>
public class GameMatrix
{
    /// <summary>
    /// Матриця виграшів (рядки - стратегії атакуючого, колонки - стратегії захисника)
    /// </summary>
    public int[,] PayoffMatrix { get; private set; }

    /// <summary>
    /// Кількість стратегій атакуючого (рядків)
    /// </summary>
    public int RowCount => PayoffMatrix.GetLength(0);

    /// <summary>
    /// Кількість стратегій захисника (колонок)
    /// </summary>
    public int ColumnCount => PayoffMatrix.GetLength(1);

    public GameMatrix(int rows, int columns)
    {
        if (rows <= 0) throw new ArgumentOutOfRangeException(nameof(rows), "Кількість рядків має бути більшою за нуль.");
        if (columns <= 0) throw new ArgumentOutOfRangeException(nameof(columns), "Кількість стовпців має бути більшою за нуль.");

        PayoffMatrix = new int[rows, columns];
    }


    /// <summary>
    /// Встановлює значення виграшу для пари стратегій
    /// </summary>
    public void SetValue(int row, int column, int value)
    {
        if (row < 0 || row >= RowCount)
            throw new ArgumentOutOfRangeException(nameof(row), $"Індекс рядка {row} виходить за межі матриці (0-{RowCount - 1}).");
        
        if (column < 0 || column >= ColumnCount)
            throw new ArgumentOutOfRangeException(nameof(column), $"Індекс стовпця {column} виходить за межі матриці (0-{ColumnCount - 1}).");
        
        PayoffMatrix[row, column] = value;
    }

    /// <summary>
    /// Отримує значення виграшу для пари стратегій
    /// </summary>
    public int GetValue(int row, int column)
    {
        if (row < 0 || row >= RowCount)
            throw new ArgumentOutOfRangeException(nameof(row), $"Індекс рядка {row} виходить за межі матриці (0-{RowCount - 1}).");
        
        if (column < 0 || column >= ColumnCount)
            throw new ArgumentOutOfRangeException(nameof(column), $"Індекс стовпця {column} виходить за межі матриці (0-{ColumnCount - 1}).");
        
        return PayoffMatrix[row, column];
    }
    
    public int this[int row, int column]
    {
        get => GetValue(row, column);
        set => SetValue(row, column, value);
    }

    /// <summary>
    /// Ініціалізує матрицю початковими значеннями для гри "Кібербезпека"
    /// Матриця 3x4:
    ///     B1  B2  B3  B4
    /// A1   5   2   3   6
    /// A2   6   4   7   8
    /// A3   1   1   2   3
    /// </summary>
    public void InitializeDefault()
    {
        if (RowCount != 3 || ColumnCount != 4)
        {
            throw new InvalidOperationException("Матриця повинна бути розміром 3x4");
        }

        // Рядок A1 (Фішинг)
        SetValue(0, 0, 5); // vs B1 (Паролі)
        SetValue(0, 1, 2); // vs B2 (2FA)
        SetValue(0, 2, 3); // vs B3 (Фільтрація пошти)
        SetValue(0, 3, 6); // vs B4 (WAF)

        // Рядок A2 (Brute-force)
        SetValue(1, 0, 6); // vs B1 (Паролі)
        SetValue(1, 1, 4); // vs B2 (2FA)
        SetValue(1, 2, 7); // vs B3 (Фільтрація пошти)
        SetValue(1, 3, 8); // vs B4 (WAF)

        // Рядок A3 (SQL-injection)
        SetValue(2, 0, 1); // vs B1 (Паролі)
        SetValue(2, 1, 1); // vs B2 (2FA)
        SetValue(2, 2, 2); // vs B3 (Фільтрація пошти)
        SetValue(2, 3, 3); // vs B4 (WAF)
    }

    /// <summary>
    /// Копіює значення з іншої матриці
    /// </summary>
    public void CopyFrom(int[,] sourceMatrix)
    {
        ArgumentNullException.ThrowIfNull(sourceMatrix);
        
        if (sourceMatrix.GetLength(0) != RowCount || sourceMatrix.GetLength(1) != ColumnCount)
        {
            throw new ArgumentException(
                $"Розміри матриць не співпадають. Очікується {RowCount}x{ColumnCount}, отримано {sourceMatrix.GetLength(0)}x{sourceMatrix.GetLength(1)}.",
                nameof(sourceMatrix));
        }

        for (var i = 0; i < RowCount; i++)
        {
            for (var j = 0; j < ColumnCount; j++)
            {
                PayoffMatrix[i, j] = sourceMatrix[i, j];
            }
        }
    }
}