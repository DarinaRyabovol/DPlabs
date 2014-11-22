namespace DPMatrForm
{
    partial class MatrixForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.genButton = new System.Windows.Forms.Button();
            this.coloredRadioButton = new System.Windows.Forms.RadioButton();
            this.coloredWithSahdowRadioButton = new System.Windows.Forms.RadioButton();
            this.blackRadioButton = new System.Windows.Forms.RadioButton();
            this.blackWithShadowRadioButton = new System.Windows.Forms.RadioButton();
            this.themGroup = new System.Windows.Forms.GroupBox();
            this.renumberRowsButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.transpButton = new System.Windows.Forms.Button();
            this.renumberColsButton = new System.Windows.Forms.Button();
            this.themGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // genButton
            // 
            this.genButton.Location = new System.Drawing.Point(12, 12);
            this.genButton.Name = "genButton";
            this.genButton.Size = new System.Drawing.Size(145, 28);
            this.genButton.TabIndex = 0;
            this.genButton.Text = "Генерация";
            this.genButton.UseVisualStyleBackColor = true;
            this.genButton.Click += new System.EventHandler(this.genButton_Click);
            // 
            // coloredRadioButton
            // 
            this.coloredRadioButton.AccessibleName = "ColoredPainter";
            this.coloredRadioButton.AutoSize = true;
            this.coloredRadioButton.Checked = true;
            this.coloredRadioButton.Location = new System.Drawing.Point(6, 44);
            this.coloredRadioButton.Name = "coloredRadioButton";
            this.coloredRadioButton.Size = new System.Drawing.Size(68, 17);
            this.coloredRadioButton.TabIndex = 1;
            this.coloredRadioButton.TabStop = true;
            this.coloredRadioButton.Text = "Цветная";
            this.coloredRadioButton.UseVisualStyleBackColor = true;
            this.coloredRadioButton.CheckedChanged += new System.EventHandler(this.coloredRadioButton_CheckedChanged);
            // 
            // coloredWithSahdowRadioButton
            // 
            this.coloredWithSahdowRadioButton.AccessibleName = "";
            this.coloredWithSahdowRadioButton.AutoSize = true;
            this.coloredWithSahdowRadioButton.Location = new System.Drawing.Point(6, 67);
            this.coloredWithSahdowRadioButton.Name = "coloredWithSahdowRadioButton";
            this.coloredWithSahdowRadioButton.Size = new System.Drawing.Size(111, 17);
            this.coloredWithSahdowRadioButton.TabIndex = 2;
            this.coloredWithSahdowRadioButton.TabStop = true;
            this.coloredWithSahdowRadioButton.Text = "Цветная с тенью";
            this.coloredWithSahdowRadioButton.UseVisualStyleBackColor = true;
            this.coloredWithSahdowRadioButton.CheckedChanged += new System.EventHandler(this.coloredWithSahdowRadioButton_CheckedChanged);
            // 
            // blackRadioButton
            // 
            this.blackRadioButton.AccessibleName = "BlackPainter";
            this.blackRadioButton.AutoSize = true;
            this.blackRadioButton.Location = new System.Drawing.Point(6, 90);
            this.blackRadioButton.Name = "blackRadioButton";
            this.blackRadioButton.Size = new System.Drawing.Size(90, 17);
            this.blackRadioButton.TabIndex = 3;
            this.blackRadioButton.TabStop = true;
            this.blackRadioButton.Text = "Черно-белая";
            this.blackRadioButton.UseVisualStyleBackColor = true;
            this.blackRadioButton.CheckedChanged += new System.EventHandler(this.blackRadioButton_CheckedChanged);
            // 
            // blackWithShadowRadioButton
            // 
            this.blackWithShadowRadioButton.AccessibleName = "";
            this.blackWithShadowRadioButton.AutoSize = true;
            this.blackWithShadowRadioButton.Location = new System.Drawing.Point(6, 113);
            this.blackWithShadowRadioButton.Name = "blackWithShadowRadioButton";
            this.blackWithShadowRadioButton.Size = new System.Drawing.Size(133, 17);
            this.blackWithShadowRadioButton.TabIndex = 4;
            this.blackWithShadowRadioButton.TabStop = true;
            this.blackWithShadowRadioButton.Text = "Черно-белая с тенью";
            this.blackWithShadowRadioButton.UseVisualStyleBackColor = true;
            this.blackWithShadowRadioButton.CheckedChanged += new System.EventHandler(this.blackWithShadowRadioButton_CheckedChanged);
            // 
            // themGroup
            // 
            this.themGroup.Controls.Add(this.coloredRadioButton);
            this.themGroup.Controls.Add(this.blackWithShadowRadioButton);
            this.themGroup.Controls.Add(this.coloredWithSahdowRadioButton);
            this.themGroup.Controls.Add(this.blackRadioButton);
            this.themGroup.Location = new System.Drawing.Point(12, 59);
            this.themGroup.Name = "themGroup";
            this.themGroup.Size = new System.Drawing.Size(145, 156);
            this.themGroup.TabIndex = 5;
            this.themGroup.TabStop = false;
            this.themGroup.Text = "Выбор схемы визуализации";
            // 
            // renumberRowsButton
            // 
            this.renumberRowsButton.Enabled = false;
            this.renumberRowsButton.Location = new System.Drawing.Point(12, 222);
            this.renumberRowsButton.Name = "renumberRowsButton";
            this.renumberRowsButton.Size = new System.Drawing.Size(145, 36);
            this.renumberRowsButton.TabIndex = 6;
            this.renumberRowsButton.Text = "Перенумеровать столбцы";
            this.renumberRowsButton.UseVisualStyleBackColor = true;
            this.renumberRowsButton.Click += new System.EventHandler(this.renumberRowsButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Enabled = false;
            this.clearButton.Location = new System.Drawing.Point(648, 366);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(110, 30);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(532, 366);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 30);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // transpButton
            // 
            this.transpButton.Enabled = false;
            this.transpButton.Location = new System.Drawing.Point(12, 306);
            this.transpButton.Name = "transpButton";
            this.transpButton.Size = new System.Drawing.Size(145, 36);
            this.transpButton.TabIndex = 9;
            this.transpButton.Text = "Транспонировать";
            this.transpButton.UseVisualStyleBackColor = true;
            this.transpButton.Click += new System.EventHandler(this.transpButton_Click);
            // 
            // renumberColsButton
            // 
            this.renumberColsButton.Enabled = false;
            this.renumberColsButton.Location = new System.Drawing.Point(12, 264);
            this.renumberColsButton.Name = "renumberColsButton";
            this.renumberColsButton.Size = new System.Drawing.Size(145, 36);
            this.renumberColsButton.TabIndex = 10;
            this.renumberColsButton.Text = "Перенумеровать строки";
            this.renumberColsButton.UseVisualStyleBackColor = true;
            this.renumberColsButton.Click += new System.EventHandler(this.renumberColsButton_Click);
            // 
            // MatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 408);
            this.Controls.Add(this.renumberColsButton);
            this.Controls.Add(this.transpButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.renumberRowsButton);
            this.Controls.Add(this.themGroup);
            this.Controls.Add(this.genButton);
            this.Name = "MatrixForm";
            this.Text = "Matrix";
            this.Load += new System.EventHandler(this.MatrixForm_Load);
            this.themGroup.ResumeLayout(false);
            this.themGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button genButton;
        private System.Windows.Forms.RadioButton coloredRadioButton;
        private System.Windows.Forms.RadioButton coloredWithSahdowRadioButton;
        private System.Windows.Forms.RadioButton blackRadioButton;
        private System.Windows.Forms.RadioButton blackWithShadowRadioButton;
        private System.Windows.Forms.GroupBox themGroup;
        private System.Windows.Forms.Button renumberRowsButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button transpButton;
        private System.Windows.Forms.Button renumberColsButton;


    }
}

