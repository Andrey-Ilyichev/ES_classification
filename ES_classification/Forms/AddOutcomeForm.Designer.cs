namespace ES_classification
{
    partial class AddOutcomeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbOutcomeField = new System.Windows.Forms.TextBox();
            this.btnAddOutcome = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вывод:";
            // 
            // tbOutcomeField
            // 
            this.tbOutcomeField.Location = new System.Drawing.Point(103, 6);
            this.tbOutcomeField.Name = "tbOutcomeField";
            this.tbOutcomeField.Size = new System.Drawing.Size(335, 20);
            this.tbOutcomeField.TabIndex = 1;
            this.tbOutcomeField.Text = "есть искра?";
            // 
            // btnAddOutcome
            // 
            this.btnAddOutcome.Location = new System.Drawing.Point(103, 32);
            this.btnAddOutcome.Name = "btnAddOutcome";
            this.btnAddOutcome.Size = new System.Drawing.Size(335, 23);
            this.btnAddOutcome.TabIndex = 2;
            this.btnAddOutcome.Text = "Добавить вывод";
            this.btnAddOutcome.UseVisualStyleBackColor = true;
            this.btnAddOutcome.Click += new System.EventHandler(this.btnAddOutcome_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(103, 61);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(335, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Вернуться назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AddOutcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 91);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddOutcome);
            this.Controls.Add(this.tbOutcomeField);
            this.Controls.Add(this.label1);
            this.Name = "AddOutcomeForm";
            this.Text = "AddOutcomeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddOutcomeForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOutcomeField;
        private System.Windows.Forms.Button btnAddOutcome;
        private System.Windows.Forms.Button btnBack;
    }
}