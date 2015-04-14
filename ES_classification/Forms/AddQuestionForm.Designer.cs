namespace ES_classification
{
    partial class AddQuestionForm
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
            this.tbQuestionField = new System.Windows.Forms.TextBox();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текст вопроса:";
            // 
            // tbQuestionField
            // 
            this.tbQuestionField.Location = new System.Drawing.Point(103, 6);
            this.tbQuestionField.Name = "tbQuestionField";
            this.tbQuestionField.Size = new System.Drawing.Size(335, 20);
            this.tbQuestionField.TabIndex = 1;
            this.tbQuestionField.Text = "есть искра?";
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(103, 32);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(335, 23);
            this.btnAddQuestion.TabIndex = 2;
            this.btnAddQuestion.Text = "Добавить вопрос";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
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
            // AddQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 91);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.tbQuestionField);
            this.Controls.Add(this.label1);
            this.Name = "AddQuestionForm";
            this.Text = "AddQuestionForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddQuestionForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbQuestionField;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnBack;
    }
}