namespace ES_classification
{
    partial class FindQuestionForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnFindQuestion = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDropFilter = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите часть слова:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnFindQuestion
            // 
            this.btnFindQuestion.Location = new System.Drawing.Point(431, 4);
            this.btnFindQuestion.Name = "btnFindQuestion";
            this.btnFindQuestion.Size = new System.Drawing.Size(163, 23);
            this.btnFindQuestion.TabIndex = 2;
            this.btnFindQuestion.Text = "Найти";
            this.btnFindQuestion.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(410, 254);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnDropFilter
            // 
            this.btnDropFilter.Location = new System.Drawing.Point(600, 4);
            this.btnDropFilter.Name = "btnDropFilter";
            this.btnDropFilter.Size = new System.Drawing.Size(151, 23);
            this.btnDropFilter.TabIndex = 4;
            this.btnDropFilter.Text = "Сбросить фильтр";
            this.btnDropFilter.UseVisualStyleBackColor = true;
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(431, 264);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(163, 23);
            this.btnDeleteQuestion.TabIndex = 5;
            this.btnDeleteQuestion.Text = "Удалить вопрос";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(670, 264);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Назад";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // FindQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 299);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.btnDropFilter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnFindQuestion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FindQuestionForm";
            this.Text = "FindQuestionForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFindQuestion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDropFilter;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnExit;
    }
}