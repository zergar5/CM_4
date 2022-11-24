namespace CM_4_Graphics
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FunctionsBox = new System.Windows.Forms.ComboBox();
            this.MethodsBox = new System.Windows.Forms.ComboBox();
            this.SinusoidBox = new System.Windows.Forms.GroupBox();
            this.NegativeShiftBox = new System.Windows.Forms.TextBox();
            this.FrequencyBox = new System.Windows.Forms.TextBox();
            this.AmplitudeBox = new System.Windows.Forms.TextBox();
            this.ShiftBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ShiftLabel = new System.Windows.Forms.Label();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.AmplitudeLabel = new System.Windows.Forms.Label();
            this.LineBox = new System.Windows.Forms.GroupBox();
            this.CTextBox = new System.Windows.Forms.TextBox();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.ATextBox = new System.Windows.Forms.TextBox();
            this.ALabel = new System.Windows.Forms.Label();
            this.CLabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.CircleBox = new System.Windows.Forms.GroupBox();
            this.RadiusBox = new System.Windows.Forms.TextBox();
            this.CenterYBox = new System.Windows.Forms.TextBox();
            this.CenterXBox = new System.Windows.Forms.TextBox();
            this.CenterX = new System.Windows.Forms.Label();
            this.Radius = new System.Windows.Forms.Label();
            this.CenterY = new System.Windows.Forms.Label();
            this.GraphicBox = new System.Windows.Forms.PictureBox();
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.MethodLabel = new System.Windows.Forms.Label();
            this.SolveButton = new System.Windows.Forms.Button();
            this.SystemTextBox = new System.Windows.Forms.TextBox();
            this.SystemLabel = new System.Windows.Forms.Label();
            this.AddFunctionButton = new System.Windows.Forms.Button();
            this.DeleteFunctionButton = new System.Windows.Forms.Button();
            this.SinusoidBox.SuspendLayout();
            this.LineBox.SuspendLayout();
            this.CircleBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FunctionsBox
            // 
            this.FunctionsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FunctionsBox.FormattingEnabled = true;
            this.FunctionsBox.Items.AddRange(new object[] {
            "Line",
            "Circle",
            "Sinusoid"});
            this.FunctionsBox.Location = new System.Drawing.Point(140, 14);
            this.FunctionsBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FunctionsBox.Name = "FunctionsBox";
            this.FunctionsBox.Size = new System.Drawing.Size(140, 23);
            this.FunctionsBox.TabIndex = 1;
            this.FunctionsBox.SelectedIndexChanged += new System.EventHandler(this.FunctionsBox_SelectedIndexChanged);
            // 
            // MethodsBox
            // 
            this.MethodsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodsBox.FormattingEnabled = true;
            this.MethodsBox.Items.AddRange(new object[] {
            "EliminateAnalytically",
            "TransposeAnalytically",
            "TransposeNumerically"});
            this.MethodsBox.Location = new System.Drawing.Point(140, 57);
            this.MethodsBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MethodsBox.Name = "MethodsBox";
            this.MethodsBox.Size = new System.Drawing.Size(140, 23);
            this.MethodsBox.TabIndex = 2;
            this.MethodsBox.SelectedIndexChanged += new System.EventHandler(this.MethodsBox_SelectedIndexChanged);
            // 
            // SinusoidBox
            // 
            this.SinusoidBox.Controls.Add(this.NegativeShiftBox);
            this.SinusoidBox.Controls.Add(this.FrequencyBox);
            this.SinusoidBox.Controls.Add(this.AmplitudeBox);
            this.SinusoidBox.Controls.Add(this.ShiftBox);
            this.SinusoidBox.Controls.Add(this.label7);
            this.SinusoidBox.Controls.Add(this.ShiftLabel);
            this.SinusoidBox.Controls.Add(this.FrequencyLabel);
            this.SinusoidBox.Controls.Add(this.AmplitudeLabel);
            this.SinusoidBox.Location = new System.Drawing.Point(289, 14);
            this.SinusoidBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SinusoidBox.Name = "SinusoidBox";
            this.SinusoidBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SinusoidBox.Size = new System.Drawing.Size(207, 142);
            this.SinusoidBox.TabIndex = 3;
            this.SinusoidBox.TabStop = false;
            this.SinusoidBox.Text = "Sinusoid";
            this.SinusoidBox.Visible = false;
            // 
            // NegativeShiftBox
            // 
            this.NegativeShiftBox.Location = new System.Drawing.Point(93, 112);
            this.NegativeShiftBox.Name = "NegativeShiftBox";
            this.NegativeShiftBox.Size = new System.Drawing.Size(100, 23);
            this.NegativeShiftBox.TabIndex = 8;
            this.NegativeShiftBox.TextChanged += new System.EventHandler(this.NegativeShift_TextChanged);
            // 
            // FrequencyBox
            // 
            this.FrequencyBox.Location = new System.Drawing.Point(93, 80);
            this.FrequencyBox.Name = "FrequencyBox";
            this.FrequencyBox.Size = new System.Drawing.Size(100, 23);
            this.FrequencyBox.TabIndex = 7;
            this.FrequencyBox.TextChanged += new System.EventHandler(this.Frequency_TextChanged);
            // 
            // AmplitudeBox
            // 
            this.AmplitudeBox.Location = new System.Drawing.Point(93, 48);
            this.AmplitudeBox.Name = "AmplitudeBox";
            this.AmplitudeBox.Size = new System.Drawing.Size(100, 23);
            this.AmplitudeBox.TabIndex = 6;
            this.AmplitudeBox.TextChanged += new System.EventHandler(this.Amplitude_TextChanged);
            // 
            // ShiftBox
            // 
            this.ShiftBox.Location = new System.Drawing.Point(93, 16);
            this.ShiftBox.Name = "ShiftBox";
            this.ShiftBox.Size = new System.Drawing.Size(100, 23);
            this.ShiftBox.TabIndex = 5;
            this.ShiftBox.TextChanged += new System.EventHandler(this.Shift_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 115);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "NegativeShift";
            // 
            // ShiftLabel
            // 
            this.ShiftLabel.AutoSize = true;
            this.ShiftLabel.Location = new System.Drawing.Point(8, 19);
            this.ShiftLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShiftLabel.Name = "ShiftLabel";
            this.ShiftLabel.Size = new System.Drawing.Size(31, 15);
            this.ShiftLabel.TabIndex = 3;
            this.ShiftLabel.Text = "Shift";
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(8, 83);
            this.FrequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(62, 15);
            this.FrequencyLabel.TabIndex = 2;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // AmplitudeLabel
            // 
            this.AmplitudeLabel.AutoSize = true;
            this.AmplitudeLabel.Location = new System.Drawing.Point(7, 51);
            this.AmplitudeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AmplitudeLabel.Name = "AmplitudeLabel";
            this.AmplitudeLabel.Size = new System.Drawing.Size(63, 15);
            this.AmplitudeLabel.TabIndex = 1;
            this.AmplitudeLabel.Text = "Amplitude";
            // 
            // LineBox
            // 
            this.LineBox.Controls.Add(this.CTextBox);
            this.LineBox.Controls.Add(this.BTextBox);
            this.LineBox.Controls.Add(this.ATextBox);
            this.LineBox.Controls.Add(this.ALabel);
            this.LineBox.Controls.Add(this.CLabel);
            this.LineBox.Controls.Add(this.BLabel);
            this.LineBox.Location = new System.Drawing.Point(289, 14);
            this.LineBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LineBox.Name = "LineBox";
            this.LineBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LineBox.Size = new System.Drawing.Size(199, 112);
            this.LineBox.TabIndex = 7;
            this.LineBox.TabStop = false;
            this.LineBox.Text = "Line";
            this.LineBox.Visible = false;
            // 
            // CTextBox
            // 
            this.CTextBox.Location = new System.Drawing.Point(93, 80);
            this.CTextBox.Name = "CTextBox";
            this.CTextBox.Size = new System.Drawing.Size(100, 23);
            this.CTextBox.TabIndex = 15;
            this.CTextBox.TextChanged += new System.EventHandler(this.CTextBox_TextChanged);
            // 
            // BTextBox
            // 
            this.BTextBox.Location = new System.Drawing.Point(93, 48);
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.Size = new System.Drawing.Size(100, 23);
            this.BTextBox.TabIndex = 14;
            this.BTextBox.TextChanged += new System.EventHandler(this.BTextBox_TextChanged);
            // 
            // ATextBox
            // 
            this.ATextBox.Location = new System.Drawing.Point(93, 16);
            this.ATextBox.Name = "ATextBox";
            this.ATextBox.Size = new System.Drawing.Size(100, 23);
            this.ATextBox.TabIndex = 8;
            this.ATextBox.TextChanged += new System.EventHandler(this.ATextBox_TextChanged);
            // 
            // ALabel
            // 
            this.ALabel.AutoSize = true;
            this.ALabel.Location = new System.Drawing.Point(8, 19);
            this.ALabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(15, 15);
            this.ALabel.TabIndex = 3;
            this.ALabel.Text = "A";
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Location = new System.Drawing.Point(7, 83);
            this.CLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(15, 15);
            this.CLabel.TabIndex = 2;
            this.CLabel.Text = "C";
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Location = new System.Drawing.Point(8, 51);
            this.BLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(14, 15);
            this.BLabel.TabIndex = 1;
            this.BLabel.Text = "B";
            // 
            // CircleBox
            // 
            this.CircleBox.Controls.Add(this.RadiusBox);
            this.CircleBox.Controls.Add(this.CenterYBox);
            this.CircleBox.Controls.Add(this.CenterXBox);
            this.CircleBox.Controls.Add(this.CenterX);
            this.CircleBox.Controls.Add(this.Radius);
            this.CircleBox.Controls.Add(this.CenterY);
            this.CircleBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CircleBox.Location = new System.Drawing.Point(289, 14);
            this.CircleBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CircleBox.Name = "CircleBox";
            this.CircleBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CircleBox.Size = new System.Drawing.Size(207, 112);
            this.CircleBox.TabIndex = 8;
            this.CircleBox.TabStop = false;
            this.CircleBox.Text = "Circle";
            this.CircleBox.Visible = false;
            // 
            // RadiusBox
            // 
            this.RadiusBox.Location = new System.Drawing.Point(93, 80);
            this.RadiusBox.Name = "RadiusBox";
            this.RadiusBox.Size = new System.Drawing.Size(100, 23);
            this.RadiusBox.TabIndex = 8;
            this.RadiusBox.TextChanged += new System.EventHandler(this.RadiusBox_TextChanged);
            // 
            // CenterYBox
            // 
            this.CenterYBox.Location = new System.Drawing.Point(93, 48);
            this.CenterYBox.Name = "CenterYBox";
            this.CenterYBox.Size = new System.Drawing.Size(100, 23);
            this.CenterYBox.TabIndex = 7;
            this.CenterYBox.TextChanged += new System.EventHandler(this.CenterYBox_TextChanged);
            // 
            // CenterXBox
            // 
            this.CenterXBox.Location = new System.Drawing.Point(93, 16);
            this.CenterXBox.Name = "CenterXBox";
            this.CenterXBox.Size = new System.Drawing.Size(100, 23);
            this.CenterXBox.TabIndex = 6;
            this.CenterXBox.TextChanged += new System.EventHandler(this.CenterXBox_TextChanged);
            // 
            // CenterX
            // 
            this.CenterX.AutoSize = true;
            this.CenterX.Location = new System.Drawing.Point(8, 19);
            this.CenterX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CenterX.Name = "CenterX";
            this.CenterX.Size = new System.Drawing.Size(49, 15);
            this.CenterX.TabIndex = 3;
            this.CenterX.Text = "CenterX";
            // 
            // Radius
            // 
            this.Radius.AutoSize = true;
            this.Radius.Location = new System.Drawing.Point(8, 83);
            this.Radius.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(42, 15);
            this.Radius.TabIndex = 2;
            this.Radius.Text = "Radius";
            // 
            // CenterY
            // 
            this.CenterY.AutoSize = true;
            this.CenterY.Location = new System.Drawing.Point(8, 51);
            this.CenterY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CenterY.Name = "CenterY";
            this.CenterY.Size = new System.Drawing.Size(49, 15);
            this.CenterY.TabIndex = 1;
            this.CenterY.Text = "CenterY";
            // 
            // GraphicBox
            // 
            this.GraphicBox.Location = new System.Drawing.Point(167, 174);
            this.GraphicBox.Name = "GraphicBox";
            this.GraphicBox.Size = new System.Drawing.Size(1310, 435);
            this.GraphicBox.TabIndex = 11;
            this.GraphicBox.TabStop = false;
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.Location = new System.Drawing.Point(14, 17);
            this.FunctionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(116, 15);
            this.FunctionLabel.TabIndex = 4;
            this.FunctionLabel.Text = "Выберите функцию";
            // 
            // MethodLabel
            // 
            this.MethodLabel.AutoSize = true;
            this.MethodLabel.Location = new System.Drawing.Point(14, 59);
            this.MethodLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MethodLabel.Name = "MethodLabel";
            this.MethodLabel.Size = new System.Drawing.Size(97, 15);
            this.MethodLabel.TabIndex = 5;
            this.MethodLabel.Text = "Выберите метод";
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(13, 174);
            this.SolveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(147, 45);
            this.SolveButton.TabIndex = 6;
            this.SolveButton.Text = "Решить задачу";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // SystemTextBox
            // 
            this.SystemTextBox.Location = new System.Drawing.Point(611, 30);
            this.SystemTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SystemTextBox.Multiline = true;
            this.SystemTextBox.Name = "SystemTextBox";
            this.SystemTextBox.ReadOnly = true;
            this.SystemTextBox.Size = new System.Drawing.Size(866, 126);
            this.SystemTextBox.TabIndex = 9;
            // 
            // SystemLabel
            // 
            this.SystemLabel.AutoSize = true;
            this.SystemLabel.Location = new System.Drawing.Point(611, 9);
            this.SystemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SystemLabel.Name = "SystemLabel";
            this.SystemLabel.Size = new System.Drawing.Size(45, 15);
            this.SystemLabel.TabIndex = 10;
            this.SystemLabel.Text = "System";
            // 
            // AddFunctionButton
            // 
            this.AddFunctionButton.Location = new System.Drawing.Point(503, 14);
            this.AddFunctionButton.Name = "AddFunctionButton";
            this.AddFunctionButton.Size = new System.Drawing.Size(101, 62);
            this.AddFunctionButton.TabIndex = 12;
            this.AddFunctionButton.Text = "AddFunction";
            this.AddFunctionButton.UseVisualStyleBackColor = true;
            this.AddFunctionButton.Click += new System.EventHandler(this.AddFunctionButton_Click);
            // 
            // DeleteFunctionButton
            // 
            this.DeleteFunctionButton.Location = new System.Drawing.Point(503, 94);
            this.DeleteFunctionButton.Name = "DeleteFunctionButton";
            this.DeleteFunctionButton.Size = new System.Drawing.Size(101, 62);
            this.DeleteFunctionButton.TabIndex = 13;
            this.DeleteFunctionButton.Text = "DeleteFunction";
            this.DeleteFunctionButton.UseVisualStyleBackColor = true;
            this.DeleteFunctionButton.Click += new System.EventHandler(this.DeleteFunctionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 621);
            this.Controls.Add(this.CircleBox);
            this.Controls.Add(this.DeleteFunctionButton);
            this.Controls.Add(this.AddFunctionButton);
            this.Controls.Add(this.GraphicBox);
            this.Controls.Add(this.SystemLabel);
            this.Controls.Add(this.SystemTextBox);
            this.Controls.Add(this.LineBox);
            this.Controls.Add(this.SinusoidBox);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.MethodLabel);
            this.Controls.Add(this.FunctionLabel);
            this.Controls.Add(this.MethodsBox);
            this.Controls.Add(this.FunctionsBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SinusoidBox.ResumeLayout(false);
            this.SinusoidBox.PerformLayout();
            this.LineBox.ResumeLayout(false);
            this.LineBox.PerformLayout();
            this.CircleBox.ResumeLayout(false);
            this.CircleBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FunctionsBox;
        private System.Windows.Forms.ComboBox MethodsBox;
        private System.Windows.Forms.GroupBox SinusoidBox;
        private System.Windows.Forms.Label FunctionLabel;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.Label AmplitudeLabel;
        private System.Windows.Forms.Label MethodLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ShiftLabel;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.GroupBox LineBox;
        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.GroupBox CircleBox;
        private System.Windows.Forms.Label CenterX;
        private System.Windows.Forms.Label Radius;
        private System.Windows.Forms.Label CenterY;
        private System.Windows.Forms.TextBox SystemTextBox;
        private System.Windows.Forms.Label SystemLabel;
        private PictureBox GraphicBox;
        private TextBox ATextBox;
        private Button AddFunctionButton;
        private Button DeleteFunctionButton;
        private TextBox CTextBox;
        private TextBox BTextBox;
        private TextBox NegativeShiftBox;
        private TextBox FrequencyBox;
        private TextBox AmplitudeBox;
        private TextBox ShiftBox;
        private TextBox RadiusBox;
        private TextBox CenterYBox;
        private TextBox CenterXBox;
    }
}

