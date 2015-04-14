namespace ES_classification
{
    partial class KBEditForm
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
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnEndOfWork = new System.Windows.Forms.Button();
            this.btnFindQuestion = new System.Windows.Forms.Button();
            this.dgvOutcome = new System.Windows.Forms.DataGridView();
            this.btnAddOutcome = new System.Windows.Forms.Button();
            this.btnDeleteOutcome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutcome)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToAddRows = false;
            this.dgvQuestion.AllowUserToDeleteRows = false;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Location = new System.Drawing.Point(12, 12);
            this.dgvQuestion.MultiSelect = false;
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.ReadOnly = true;
            this.dgvQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestion.Size = new System.Drawing.Size(459, 150);
            this.dgvQuestion.TabIndex = 0;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(477, 12);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(196, 23);
            this.btnAddQuestion.TabIndex = 1;
            this.btnAddQuestion.Text = "Добавить вопрос";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.EnabledChanged += new System.EventHandler(this.btnAddQuestion_EnabledChanged);
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(477, 85);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(196, 23);
            this.btnDeleteQuestion.TabIndex = 2;
            this.btnDeleteQuestion.Text = "Удалить вопрос";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnEndOfWork
            // 
            this.btnEndOfWork.Location = new System.Drawing.Point(477, 415);
            this.btnEndOfWork.Name = "btnEndOfWork";
            this.btnEndOfWork.Size = new System.Drawing.Size(196, 23);
            this.btnEndOfWork.TabIndex = 3;
            this.btnEndOfWork.Text = "Закончить редакирование";
            this.btnEndOfWork.UseVisualStyleBackColor = true;
            this.btnEndOfWork.Click += new System.EventHandler(this.btnEndOfWork_Click);
            // 
            // btnFindQuestion
            // 
            this.btnFindQuestion.Location = new System.Drawing.Point(477, 41);
            this.btnFindQuestion.Name = "btnFindQuestion";
            this.btnFindQuestion.Size = new System.Drawing.Size(196, 38);
            this.btnFindQuestion.TabIndex = 4;
            this.btnFindQuestion.Text = "Найти вопросы, содержащие определенный текст\r\n";
            this.btnFindQuestion.UseVisualStyleBackColor = true;
            // 
            // dgvOutcome
            // 
            this.dgvOutcome.AllowUserToAddRows = false;
            this.dgvOutcome.AllowUserToDeleteRows = false;
            this.dgvOutcome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutcome.Location = new System.Drawing.Point(12, 245);
            this.dgvOutcome.Name = "dgvOutcome";
            this.dgvOutcome.ReadOnly = true;
            this.dgvOutcome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutcome.Size = new System.Drawing.Size(459, 150);
            this.dgvOutcome.TabIndex = 5;
            // 
            // btnAddOutcome
            // 
            this.btnAddOutcome.Location = new System.Drawing.Point(477, 245);
            this.btnAddOutcome.Name = "btnAddOutcome";
            this.btnAddOutcome.Size = new System.Drawing.Size(196, 23);
            this.btnAddOutcome.TabIndex = 6;
            this.btnAddOutcome.Text = "Добавить результат";
            this.btnAddOutcome.UseVisualStyleBackColor = true;
            this.btnAddOutcome.Click += new System.EventHandler(this.btnAddOutcome_Click);
            // 
            // btnDeleteOutcome
            // 
            this.btnDeleteOutcome.Location = new System.Drawing.Point(477, 274);
            this.btnDeleteOutcome.Name = "btnDeleteOutcome";
            this.btnDeleteOutcome.Size = new System.Drawing.Size(196, 23);
            this.btnDeleteOutcome.TabIndex = 7;
            this.btnDeleteOutcome.Text = "Удалить результат";
            this.btnDeleteOutcome.UseVisualStyleBackColor = true;
            this.btnDeleteOutcome.Click += new System.EventHandler(this.btnDeleteOutcome_Click);
            // 
            // QuestionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.btnDeleteOutcome);
            this.Controls.Add(this.btnAddOutcome);
            this.Controls.Add(this.dgvOutcome);
            this.Controls.Add(this.btnFindQuestion);
            this.Controls.Add(this.btnEndOfWork);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.dgvQuestion);
            this.Name = "QuestionEditForm";
            this.Text = "WorkWithQuestionDTForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuestionEditForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutcome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnEndOfWork;
        private System.Windows.Forms.Button btnFindQuestion;
        private System.Windows.Forms.DataGridView dgvOutcome;
        private System.Windows.Forms.Button btnAddOutcome;
        private System.Windows.Forms.Button btnDeleteOutcome;
    }
}