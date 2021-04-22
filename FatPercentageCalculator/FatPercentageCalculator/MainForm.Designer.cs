
namespace FatPercentageCalculator
{
    partial class MainForm
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
            this.totalCaloriesLabel = new System.Windows.Forms.Label();
            this.fatGramsLabel = new System.Windows.Forms.Label();
            this.inputTotalCaloriesTextBox = new System.Windows.Forms.TextBox();
            this.inputFatGramsTextBox = new System.Windows.Forms.TextBox();
            this.displayCaloriesFatLabel = new System.Windows.Forms.Label();
            this.displayPercentageCaloriesLabel = new System.Windows.Forms.Label();
            this.lowFatLabel = new System.Windows.Forms.Label();
            this.lowFatCheckBox = new System.Windows.Forms.CheckBox();
            this.checkLowFatLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // totalCaloriesLabel
            // 
            this.totalCaloriesLabel.AutoSize = true;
            this.totalCaloriesLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCaloriesLabel.Location = new System.Drawing.Point(57, 60);
            this.totalCaloriesLabel.Name = "totalCaloriesLabel";
            this.totalCaloriesLabel.Size = new System.Drawing.Size(100, 16);
            this.totalCaloriesLabel.TabIndex = 0;
            this.totalCaloriesLabel.Text = "Total Calories:";
            // 
            // fatGramsLabel
            // 
            this.fatGramsLabel.AutoSize = true;
            this.fatGramsLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fatGramsLabel.Location = new System.Drawing.Point(60, 109);
            this.fatGramsLabel.Name = "fatGramsLabel";
            this.fatGramsLabel.Size = new System.Drawing.Size(113, 16);
            this.fatGramsLabel.TabIndex = 0;
            this.fatGramsLabel.Text = "Total Fat Grams:";
            // 
            // inputTotalCaloriesTextBox
            // 
            this.inputTotalCaloriesTextBox.Location = new System.Drawing.Point(186, 60);
            this.inputTotalCaloriesTextBox.Name = "inputTotalCaloriesTextBox";
            this.inputTotalCaloriesTextBox.Size = new System.Drawing.Size(100, 20);
            this.inputTotalCaloriesTextBox.TabIndex = 1;
            // 
            // inputFatGramsTextBox
            // 
            this.inputFatGramsTextBox.Location = new System.Drawing.Point(186, 109);
            this.inputFatGramsTextBox.Name = "inputFatGramsTextBox";
            this.inputFatGramsTextBox.Size = new System.Drawing.Size(100, 20);
            this.inputFatGramsTextBox.TabIndex = 2;
            // 
            // displayCaloriesFatLabel
            // 
            this.displayCaloriesFatLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayCaloriesFatLabel.Location = new System.Drawing.Point(60, 214);
            this.displayCaloriesFatLabel.Name = "displayCaloriesFatLabel";
            this.displayCaloriesFatLabel.Size = new System.Drawing.Size(429, 23);
            this.displayCaloriesFatLabel.TabIndex = 0;
            // 
            // displayPercentageCaloriesLabel
            // 
            this.displayPercentageCaloriesLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayPercentageCaloriesLabel.Location = new System.Drawing.Point(60, 269);
            this.displayPercentageCaloriesLabel.Name = "displayPercentageCaloriesLabel";
            this.displayPercentageCaloriesLabel.Size = new System.Drawing.Size(429, 23);
            this.displayPercentageCaloriesLabel.TabIndex = 0;
            // 
            // lowFatLabel
            // 
            this.lowFatLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowFatLabel.Location = new System.Drawing.Point(60, 324);
            this.lowFatLabel.Name = "lowFatLabel";
            this.lowFatLabel.Size = new System.Drawing.Size(429, 23);
            this.lowFatLabel.TabIndex = 0;
            // 
            // lowFatCheckBox
            // 
            this.lowFatCheckBox.AutoSize = true;
            this.lowFatCheckBox.Location = new System.Drawing.Point(271, 159);
            this.lowFatCheckBox.Name = "lowFatCheckBox";
            this.lowFatCheckBox.Size = new System.Drawing.Size(15, 14);
            this.lowFatCheckBox.TabIndex = 3;
            this.lowFatCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkLowFatLabel
            // 
            this.checkLowFatLabel.AutoSize = true;
            this.checkLowFatLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLowFatLabel.Location = new System.Drawing.Point(63, 159);
            this.checkLowFatLabel.Name = "checkLowFatLabel";
            this.checkLowFatLabel.Size = new System.Drawing.Size(145, 32);
            this.checkLowFatLabel.TabIndex = 0;
            this.checkLowFatLabel.Text = "Check Box to Display \r\nif Food is Low Fat";
            // 
            // calculateButton
            // 
            this.calculateButton.BackColor = System.Drawing.Color.DarkGray;
            this.calculateButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateButton.Location = new System.Drawing.Point(395, 60);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(94, 35);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.DarkGray;
            this.clearButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(395, 137);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(94, 35);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.calculateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(560, 450);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.checkLowFatLabel);
            this.Controls.Add(this.lowFatCheckBox);
            this.Controls.Add(this.lowFatLabel);
            this.Controls.Add(this.displayPercentageCaloriesLabel);
            this.Controls.Add(this.displayCaloriesFatLabel);
            this.Controls.Add(this.inputFatGramsTextBox);
            this.Controls.Add(this.inputTotalCaloriesTextBox);
            this.Controls.Add(this.fatGramsLabel);
            this.Controls.Add(this.totalCaloriesLabel);
            this.Name = "MainForm";
            this.Text = "Fat Percentage Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalCaloriesLabel;
        private System.Windows.Forms.Label fatGramsLabel;
        private System.Windows.Forms.TextBox inputTotalCaloriesTextBox;
        private System.Windows.Forms.TextBox inputFatGramsTextBox;
        private System.Windows.Forms.Label displayCaloriesFatLabel;
        private System.Windows.Forms.Label displayPercentageCaloriesLabel;
        private System.Windows.Forms.Label lowFatLabel;
        private System.Windows.Forms.CheckBox lowFatCheckBox;
        private System.Windows.Forms.Label checkLowFatLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button clearButton;
    }
}

