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
            this.dgvOutcome = new System.Windows.Forms.DataGridView();
            this.btnAddOutcome = new System.Windows.Forms.Button();
            this.btnDeleteOutcome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbAllQuestions = new System.Windows.Forms.CheckBox();
            this.cmbFunctionalArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInsertStatistic = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbYesAnswerProcent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOutcome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutcome)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToAddRows = false;
            this.dgvQuestion.AllowUserToDeleteRows = false;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Location = new System.Drawing.Point(6, 19);
            this.dgvQuestion.MultiSelect = false;
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.ReadOnly = true;
            this.dgvQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestion.Size = new System.Drawing.Size(286, 377);
            this.dgvQuestion.TabIndex = 0;
            this.dgvQuestion.SelectionChanged += new System.EventHandler(this.dgvQuestion_SelectionChanged);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(298, 19);
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
            this.btnDeleteQuestion.Location = new System.Drawing.Point(298, 48);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(196, 23);
            this.btnDeleteQuestion.TabIndex = 2;
            this.btnDeleteQuestion.Text = "Изменить вопрос";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnEndOfWork
            // 
            this.btnEndOfWork.Location = new System.Drawing.Point(831, 504);
            this.btnEndOfWork.Name = "btnEndOfWork";
            this.btnEndOfWork.Size = new System.Drawing.Size(196, 23);
            this.btnEndOfWork.TabIndex = 3;
            this.btnEndOfWork.Text = "Закончить редакирование";
            this.btnEndOfWork.UseVisualStyleBackColor = true;
            this.btnEndOfWork.Click += new System.EventHandler(this.btnEndOfWork_Click);
            // 
            // dgvOutcome
            // 
            this.dgvOutcome.AllowUserToAddRows = false;
            this.dgvOutcome.AllowUserToDeleteRows = false;
            this.dgvOutcome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutcome.Location = new System.Drawing.Point(6, 15);
            this.dgvOutcome.Name = "dgvOutcome";
            this.dgvOutcome.ReadOnly = true;
            this.dgvOutcome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutcome.Size = new System.Drawing.Size(286, 426);
            this.dgvOutcome.TabIndex = 5;
            this.dgvOutcome.SelectionChanged += new System.EventHandler(this.dgvOutcome_SelectionChanged);
            // 
            // btnAddOutcome
            // 
            this.btnAddOutcome.Location = new System.Drawing.Point(298, 15);
            this.btnAddOutcome.Name = "btnAddOutcome";
            this.btnAddOutcome.Size = new System.Drawing.Size(196, 23);
            this.btnAddOutcome.TabIndex = 6;
            this.btnAddOutcome.Text = "Добавить результат";
            this.btnAddOutcome.UseVisualStyleBackColor = true;
            this.btnAddOutcome.Click += new System.EventHandler(this.btnAddOutcome_Click);
            // 
            // btnDeleteOutcome
            // 
            this.btnDeleteOutcome.Location = new System.Drawing.Point(298, 42);
            this.btnDeleteOutcome.Name = "btnDeleteOutcome";
            this.btnDeleteOutcome.Size = new System.Drawing.Size(196, 23);
            this.btnDeleteOutcome.TabIndex = 7;
            this.btnDeleteOutcome.Text = "Изменить результат";
            this.btnDeleteOutcome.UseVisualStyleBackColor = true;
            this.btnDeleteOutcome.Click += new System.EventHandler(this.btnDeleteOutcome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbAllQuestions);
            this.groupBox1.Controls.Add(this.cmbFunctionalArea);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnDeleteQuestion);
            this.groupBox1.Controls.Add(this.btnAddQuestion);
            this.groupBox1.Controls.Add(this.dgvQuestion);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 446);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с вопросами";
            // 
            // chbAllQuestions
            // 
            this.chbAllQuestions.AutoSize = true;
            this.chbAllQuestions.Checked = true;
            this.chbAllQuestions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAllQuestions.Location = new System.Drawing.Point(194, 421);
            this.chbAllQuestions.Name = "chbAllQuestions";
            this.chbAllQuestions.Size = new System.Drawing.Size(92, 17);
            this.chbAllQuestions.TabIndex = 15;
            this.chbAllQuestions.Text = "Все вопросы";
            this.chbAllQuestions.UseVisualStyleBackColor = true;
            this.chbAllQuestions.CheckedChanged += new System.EventHandler(this.chbAllQuestions_CheckedChanged);
            // 
            // cmbFunctionalArea
            // 
            this.cmbFunctionalArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunctionalArea.Enabled = false;
            this.cmbFunctionalArea.FormattingEnabled = true;
            this.cmbFunctionalArea.Location = new System.Drawing.Point(6, 419);
            this.cmbFunctionalArea.Name = "cmbFunctionalArea";
            this.cmbFunctionalArea.Size = new System.Drawing.Size(182, 21);
            this.cmbFunctionalArea.TabIndex = 14;
            this.cmbFunctionalArea.SelectedIndexChanged += new System.EventHandler(this.cmbFunctionalArea_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Функциональная область:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteOutcome);
            this.groupBox2.Controls.Add(this.btnAddOutcome);
            this.groupBox2.Controls.Add(this.dgvOutcome);
            this.groupBox2.Location = new System.Drawing.Point(522, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 446);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с выводами";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInsertStatistic);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbYesAnswerProcent);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbQuestion);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbOutcome);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1021, 42);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Статистика";
            // 
            // btnInsertStatistic
            // 
            this.btnInsertStatistic.Location = new System.Drawing.Point(755, 11);
            this.btnInsertStatistic.Name = "btnInsertStatistic";
            this.btnInsertStatistic.Size = new System.Drawing.Size(255, 23);
            this.btnInsertStatistic.TabIndex = 7;
            this.btnInsertStatistic.Text = "Учесть статистику";
            this.btnInsertStatistic.UseVisualStyleBackColor = true;
            this.btnInsertStatistic.Click += new System.EventHandler(this.btnInsertStatistic_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "% \"да\"";
            // 
            // tbYesAnswerProcent
            // 
            this.tbYesAnswerProcent.Location = new System.Drawing.Point(678, 13);
            this.tbYesAnswerProcent.Name = "tbYesAnswerProcent";
            this.tbYesAnswerProcent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbYesAnswerProcent.Size = new System.Drawing.Size(25, 20);
            this.tbYesAnswerProcent.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(604, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "составляет:";
            // 
            // tbQuestion
            // 
            this.tbQuestion.Enabled = false;
            this.tbQuestion.Location = new System.Drawing.Point(433, 13);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(165, 20);
            this.tbQuestion.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "распределение ответов на вопрос";
            // 
            // tbOutcome
            // 
            this.tbOutcome.Enabled = false;
            this.tbOutcome.Location = new System.Drawing.Point(74, 13);
            this.tbOutcome.Name = "tbOutcome";
            this.tbOutcome.Size = new System.Drawing.Size(165, 20);
            this.tbOutcome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "При выводе ";
            // 
            // KBEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 535);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEndOfWork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "KBEditForm";
            this.Text = "WorkWithQuestionDTForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuestionEditForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutcome)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnEndOfWork;
        private System.Windows.Forms.DataGridView dgvOutcome;
        private System.Windows.Forms.Button btnAddOutcome;
        private System.Windows.Forms.Button btnDeleteOutcome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbFunctionalArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbAllQuestions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbYesAnswerProcent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOutcome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsertStatistic;
    }
}