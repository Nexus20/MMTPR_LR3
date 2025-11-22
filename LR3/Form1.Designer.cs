namespace LR3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelMain = new TableLayoutPanel();
            groupBoxMatrix = new GroupBox();
            dataGridViewMatrix = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            btnResetMatrix = new Button();
            groupBoxStrategy = new GroupBox();
            btnExecuteAttack = new Button();
            radioButtonA3 = new RadioButton();
            radioButtonA2 = new RadioButton();
            radioButtonA1 = new RadioButton();
            groupBoxResult = new GroupBox();
            progressBarPayoff = new ProgressBar();
            labelPayoff = new Label();
            labelDefenderChoice = new Label();
            labelAttackerChoice = new Label();
            groupBoxAnalysis = new GroupBox();
            textBoxAnalysis = new TextBox();
            btnShowOptimal = new Button();
            groupBoxHistory = new GroupBox();
            labelStatistics = new Label();
            btnClearHistory = new Button();
            dataGridViewHistory = new DataGridView();
            ColumnRound = new DataGridViewTextBoxColumn();
            ColumnAttacker = new DataGridViewTextBoxColumn();
            ColumnDefender = new DataGridViewTextBoxColumn();
            ColumnPayoff = new DataGridViewTextBoxColumn();
            tableLayoutPanelMain.SuspendLayout();
            groupBoxMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).BeginInit();
            groupBoxStrategy.SuspendLayout();
            groupBoxResult.SuspendLayout();
            groupBoxAnalysis.SuspendLayout();
            groupBoxHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Controls.Add(groupBoxMatrix, 0, 0);
            tableLayoutPanelMain.Controls.Add(groupBoxStrategy, 1, 0);
            tableLayoutPanelMain.Controls.Add(groupBoxResult, 0, 1);
            tableLayoutPanelMain.Controls.Add(groupBoxAnalysis, 0, 2);
            tableLayoutPanelMain.Controls.Add(groupBoxHistory, 0, 3);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 4;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Size = new Size(1200, 800);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // groupBoxMatrix
            // 
            groupBoxMatrix.Controls.Add(dataGridViewMatrix);
            groupBoxMatrix.Controls.Add(btnResetMatrix);
            groupBoxMatrix.Dock = DockStyle.Fill;
            groupBoxMatrix.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxMatrix.Location = new Point(3, 3);
            groupBoxMatrix.Name = "groupBoxMatrix";
            groupBoxMatrix.Size = new Size(594, 194);
            groupBoxMatrix.TabIndex = 0;
            groupBoxMatrix.TabStop = false;
            groupBoxMatrix.Text = "Матриця виграшів (Хакер)";
            // 
            // dataGridViewMatrix
            // 
            dataGridViewMatrix.AllowUserToAddRows = false;
            dataGridViewMatrix.AllowUserToDeleteRows = false;
            dataGridViewMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMatrix.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewMatrix.Location = new Point(6, 26);
            dataGridViewMatrix.Name = "dataGridViewMatrix";
            dataGridViewMatrix.RowHeadersWidth = 100;
            dataGridViewMatrix.Size = new Size(582, 120);
            dataGridViewMatrix.TabIndex = 1;
            dataGridViewMatrix.CellValueChanged += DataGridViewMatrix_CellValueChanged;
            // 
            // Column1
            // 
            Column1.HeaderText = "B1 (Паролі)";
            Column1.Name = "Column1";
            Column1.Width = 110;
            // 
            // Column2
            // 
            Column2.HeaderText = "B2 (2FA)";
            Column2.Name = "Column2";
            Column2.Width = 110;
            // 
            // Column3
            // 
            Column3.HeaderText = "B3 (Фільтр)";
            Column3.Name = "Column3";
            Column3.Width = 110;
            // 
            // Column4
            // 
            Column4.HeaderText = "B4 (WAF)";
            Column4.Name = "Column4";
            Column4.Width = 110;
            // 
            // btnResetMatrix
            // 
            btnResetMatrix.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnResetMatrix.Font = new Font("Segoe UI", 9F);
            btnResetMatrix.Location = new Point(428, 152);
            btnResetMatrix.Name = "btnResetMatrix";
            btnResetMatrix.Size = new Size(160, 30);
            btnResetMatrix.TabIndex = 0;
            btnResetMatrix.Text = "Скинути до початкових";
            btnResetMatrix.UseVisualStyleBackColor = true;
            btnResetMatrix.Click += BtnResetMatrix_Click;
            // 
            // groupBoxStrategy
            // 
            groupBoxStrategy.Controls.Add(btnExecuteAttack);
            groupBoxStrategy.Controls.Add(radioButtonA3);
            groupBoxStrategy.Controls.Add(radioButtonA2);
            groupBoxStrategy.Controls.Add(radioButtonA1);
            groupBoxStrategy.Dock = DockStyle.Fill;
            groupBoxStrategy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxStrategy.Location = new Point(603, 3);
            groupBoxStrategy.Name = "groupBoxStrategy";
            groupBoxStrategy.Size = new Size(594, 194);
            groupBoxStrategy.TabIndex = 1;
            groupBoxStrategy.TabStop = false;
            groupBoxStrategy.Text = "Оберіть стратегію хакера";
            // 
            // btnExecuteAttack
            // 
            btnExecuteAttack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExecuteAttack.BackColor = Color.FromArgb(220, 53, 69);
            btnExecuteAttack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExecuteAttack.ForeColor = Color.White;
            btnExecuteAttack.Location = new Point(6, 140);
            btnExecuteAttack.Name = "btnExecuteAttack";
            btnExecuteAttack.Size = new Size(582, 42);
            btnExecuteAttack.TabIndex = 3;
            btnExecuteAttack.Text = "⚡ Виконати атаку!";
            btnExecuteAttack.UseVisualStyleBackColor = false;
            btnExecuteAttack.Click += BtnExecuteAttack_Click;
            // 
            // radioButtonA3
            // 
            radioButtonA3.AutoSize = true;
            radioButtonA3.Font = new Font("Segoe UI", 10F);
            radioButtonA3.Location = new Point(15, 96);
            radioButtonA3.Name = "radioButtonA3";
            radioButtonA3.Size = new Size(180, 23);
            radioButtonA3.TabIndex = 2;
            radioButtonA3.Text = "A3 - SQL-injection атака";
            radioButtonA3.UseVisualStyleBackColor = true;
            // 
            // radioButtonA2
            // 
            radioButtonA2.AutoSize = true;
            radioButtonA2.Font = new Font("Segoe UI", 10F);
            radioButtonA2.Location = new Point(15, 64);
            radioButtonA2.Name = "radioButtonA2";
            radioButtonA2.Size = new Size(172, 23);
            radioButtonA2.TabIndex = 1;
            radioButtonA2.Text = "A2 - Brute-force атака";
            radioButtonA2.UseVisualStyleBackColor = true;
            // 
            // radioButtonA1
            // 
            radioButtonA1.AutoSize = true;
            radioButtonA1.Checked = true;
            radioButtonA1.Font = new Font("Segoe UI", 10F);
            radioButtonA1.Location = new Point(15, 32);
            radioButtonA1.Name = "radioButtonA1";
            radioButtonA1.Size = new Size(169, 23);
            radioButtonA1.TabIndex = 0;
            radioButtonA1.TabStop = true;
            radioButtonA1.Text = "A1 - Фішингова атака";
            radioButtonA1.UseVisualStyleBackColor = true;
            // 
            // groupBoxResult
            // 
            tableLayoutPanelMain.SetColumnSpan(groupBoxResult, 2);
            groupBoxResult.Controls.Add(progressBarPayoff);
            groupBoxResult.Controls.Add(labelPayoff);
            groupBoxResult.Controls.Add(labelDefenderChoice);
            groupBoxResult.Controls.Add(labelAttackerChoice);
            groupBoxResult.Dock = DockStyle.Fill;
            groupBoxResult.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxResult.Location = new Point(3, 203);
            groupBoxResult.Name = "groupBoxResult";
            groupBoxResult.Size = new Size(1194, 114);
            groupBoxResult.TabIndex = 2;
            groupBoxResult.TabStop = false;
            groupBoxResult.Text = "Результат раунду";
            // 
            // progressBarPayoff
            // 
            progressBarPayoff.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarPayoff.Location = new Point(6, 80);
            progressBarPayoff.Maximum = 10;
            progressBarPayoff.Name = "progressBarPayoff";
            progressBarPayoff.Size = new Size(1182, 23);
            progressBarPayoff.TabIndex = 3;
            // 
            // labelPayoff
            // 
            labelPayoff.AutoSize = true;
            labelPayoff.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPayoff.ForeColor = Color.FromArgb(220, 53, 69);
            labelPayoff.Location = new Point(600, 35);
            labelPayoff.Name = "labelPayoff";
            labelPayoff.Size = new Size(265, 19);
            labelPayoff.TabIndex = 2;
            labelPayoff.Text = "Результат: - (0 = захист, 10 = атака)";
            // 
            // labelDefenderChoice
            // 
            labelDefenderChoice.AutoSize = true;
            labelDefenderChoice.Font = new Font("Segoe UI", 10F);
            labelDefenderChoice.ForeColor = Color.FromArgb(40, 167, 69);
            labelDefenderChoice.Location = new Point(6, 50);
            labelDefenderChoice.Name = "labelDefenderChoice";
            labelDefenderChoice.Size = new Size(136, 19);
            labelDefenderChoice.TabIndex = 1;
            labelDefenderChoice.Text = "Захисник обрав: -";
            // 
            // labelAttackerChoice
            // 
            labelAttackerChoice.AutoSize = true;
            labelAttackerChoice.Font = new Font("Segoe UI", 10F);
            labelAttackerChoice.ForeColor = Color.FromArgb(220, 53, 69);
            labelAttackerChoice.Location = new Point(6, 26);
            labelAttackerChoice.Name = "labelAttackerChoice";
            labelAttackerChoice.Size = new Size(117, 19);
            labelAttackerChoice.TabIndex = 0;
            labelAttackerChoice.Text = "Хакер обрав: -";
            // 
            // groupBoxAnalysis
            // 
            tableLayoutPanelMain.SetColumnSpan(groupBoxAnalysis, 2);
            groupBoxAnalysis.Controls.Add(textBoxAnalysis);
            groupBoxAnalysis.Controls.Add(btnShowOptimal);
            groupBoxAnalysis.Dock = DockStyle.Fill;
            groupBoxAnalysis.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAnalysis.Location = new Point(3, 323);
            groupBoxAnalysis.Name = "groupBoxAnalysis";
            groupBoxAnalysis.Size = new Size(1194, 194);
            groupBoxAnalysis.TabIndex = 3;
            groupBoxAnalysis.TabStop = false;
            groupBoxAnalysis.Text = "Аналіз стратегій (Максимін)";
            // 
            // textBoxAnalysis
            // 
            textBoxAnalysis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAnalysis.BackColor = Color.WhiteSmoke;
            textBoxAnalysis.Font = new Font("Consolas", 9F);
            textBoxAnalysis.Location = new Point(6, 56);
            textBoxAnalysis.Multiline = true;
            textBoxAnalysis.Name = "textBoxAnalysis";
            textBoxAnalysis.ReadOnly = true;
            textBoxAnalysis.ScrollBars = ScrollBars.Vertical;
            textBoxAnalysis.Size = new Size(1182, 132);
            textBoxAnalysis.TabIndex = 1;
            textBoxAnalysis.Text = "Натисніть кнопку для аналізу оптимальної стратегії...";
            // 
            // btnShowOptimal
            // 
            btnShowOptimal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnShowOptimal.BackColor = Color.FromArgb(0, 123, 255);
            btnShowOptimal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnShowOptimal.ForeColor = Color.White;
            btnShowOptimal.Location = new Point(6, 22);
            btnShowOptimal.Name = "btnShowOptimal";
            btnShowOptimal.Size = new Size(1182, 32);
            btnShowOptimal.TabIndex = 0;
            btnShowOptimal.Text = "📊 Показати оптимальну стратегію (Максимін)";
            btnShowOptimal.UseVisualStyleBackColor = false;
            btnShowOptimal.Click += BtnShowOptimal_Click;
            // 
            // groupBoxHistory
            // 
            tableLayoutPanelMain.SetColumnSpan(groupBoxHistory, 2);
            groupBoxHistory.Controls.Add(labelStatistics);
            groupBoxHistory.Controls.Add(btnClearHistory);
            groupBoxHistory.Controls.Add(dataGridViewHistory);
            groupBoxHistory.Dock = DockStyle.Fill;
            groupBoxHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxHistory.Location = new Point(3, 523);
            groupBoxHistory.Name = "groupBoxHistory";
            groupBoxHistory.Size = new Size(1194, 274);
            groupBoxHistory.TabIndex = 4;
            groupBoxHistory.TabStop = false;
            groupBoxHistory.Text = "Історія раундів";
            // 
            // labelStatistics
            // 
            labelStatistics.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelStatistics.AutoSize = true;
            labelStatistics.Font = new Font("Segoe UI", 9F);
            labelStatistics.Location = new Point(6, 246);
            labelStatistics.Name = "labelStatistics";
            labelStatistics.Size = new Size(275, 15);
            labelStatistics.TabIndex = 2;
            labelStatistics.Text = "Статистика: Раундів: 0 | Середній виграш: 0.00";
            // 
            // btnClearHistory
            // 
            btnClearHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearHistory.Font = new Font("Segoe UI", 9F);
            btnClearHistory.Location = new Point(1050, 238);
            btnClearHistory.Name = "btnClearHistory";
            btnClearHistory.Size = new Size(138, 30);
            btnClearHistory.TabIndex = 1;
            btnClearHistory.Text = "Очистити історію";
            btnClearHistory.UseVisualStyleBackColor = true;
            btnClearHistory.Click += BtnClearHistory_Click;
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.AllowUserToAddRows = false;
            dataGridViewHistory.AllowUserToDeleteRows = false;
            dataGridViewHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Columns.AddRange(new DataGridViewColumn[] { ColumnRound, ColumnAttacker, ColumnDefender, ColumnPayoff });
            dataGridViewHistory.Location = new Point(6, 26);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.ReadOnly = true;
            dataGridViewHistory.Size = new Size(1182, 206);
            dataGridViewHistory.TabIndex = 0;
            // 
            // ColumnRound
            // 
            ColumnRound.HeaderText = "Раунд";
            ColumnRound.Name = "ColumnRound";
            ColumnRound.ReadOnly = true;
            ColumnRound.Width = 80;
            // 
            // ColumnAttacker
            // 
            ColumnAttacker.HeaderText = "Стратегія хакера";
            ColumnAttacker.Name = "ColumnAttacker";
            ColumnAttacker.ReadOnly = true;
            ColumnAttacker.Width = 350;
            // 
            // ColumnDefender
            // 
            ColumnDefender.HeaderText = "Стратегія захисника";
            ColumnDefender.Name = "ColumnDefender";
            ColumnDefender.ReadOnly = true;
            ColumnDefender.Width = 350;
            // 
            // ColumnPayoff
            // 
            ColumnPayoff.HeaderText = "Результат";
            ColumnPayoff.Name = "ColumnPayoff";
            ColumnPayoff.ReadOnly = true;
            ColumnPayoff.Width = 150;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(tableLayoutPanelMain);
            MinimumSize = new Size(1000, 700);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Матрична гра: Кібербезпека - ЛР3";
            tableLayoutPanelMain.ResumeLayout(false);
            groupBoxMatrix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).EndInit();
            groupBoxStrategy.ResumeLayout(false);
            groupBoxStrategy.PerformLayout();
            groupBoxResult.ResumeLayout(false);
            groupBoxResult.PerformLayout();
            groupBoxAnalysis.ResumeLayout(false);
            groupBoxAnalysis.PerformLayout();
            groupBoxHistory.ResumeLayout(false);
            groupBoxHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private GroupBox groupBoxMatrix;
        private DataGridView dataGridViewMatrix;
        private Button btnResetMatrix;
        private GroupBox groupBoxStrategy;
        private Button btnExecuteAttack;
        private RadioButton radioButtonA3;
        private RadioButton radioButtonA2;
        private RadioButton radioButtonA1;
        private GroupBox groupBoxResult;
        private Label labelPayoff;
        private Label labelDefenderChoice;
        private Label labelAttackerChoice;
        private GroupBox groupBoxAnalysis;
        private TextBox textBoxAnalysis;
        private Button btnShowOptimal;
        private GroupBox groupBoxHistory;
        private DataGridView dataGridViewHistory;
        private Button btnClearHistory;
        private ProgressBar progressBarPayoff;
        private Label labelStatistics;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn ColumnRound;
        private DataGridViewTextBoxColumn ColumnAttacker;
        private DataGridViewTextBoxColumn ColumnDefender;
        private DataGridViewTextBoxColumn ColumnPayoff;
    }
}
