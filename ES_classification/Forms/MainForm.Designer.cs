namespace ES_classification
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lbl_currentQuestion = new System.Windows.Forms.Label();
            this.btn_yes = new System.Windows.Forms.Button();
            this.btn_no = new System.Windows.Forms.Button();
            this.btn_dontKnow = new System.Windows.Forms.Button();
            this.btn_noMatter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.dgvProbList = new System.Windows.Forms.DataGridView();
            this.btnGoToQuestionEditForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProbList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список вопросов";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(284, 25);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(217, 23);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Старт";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(284, 54);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(217, 23);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Стоп";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // lbl_currentQuestion
            // 
            this.lbl_currentQuestion.AutoSize = true;
            this.lbl_currentQuestion.Location = new System.Drawing.Point(281, 80);
            this.lbl_currentQuestion.Name = "lbl_currentQuestion";
            this.lbl_currentQuestion.Size = new System.Drawing.Size(10, 13);
            this.lbl_currentQuestion.TabIndex = 4;
            this.lbl_currentQuestion.Text = ".";
            // 
            // btn_yes
            // 
            this.btn_yes.Enabled = false;
            this.btn_yes.Location = new System.Drawing.Point(284, 164);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Size = new System.Drawing.Size(217, 23);
            this.btn_yes.TabIndex = 5;
            this.btn_yes.Text = "Да";
            this.btn_yes.UseVisualStyleBackColor = true;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            // 
            // btn_no
            // 
            this.btn_no.Enabled = false;
            this.btn_no.Location = new System.Drawing.Point(284, 193);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(217, 23);
            this.btn_no.TabIndex = 6;
            this.btn_no.Text = "Нет";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_dontKnow
            // 
            this.btn_dontKnow.Enabled = false;
            this.btn_dontKnow.Location = new System.Drawing.Point(284, 222);
            this.btn_dontKnow.Name = "btn_dontKnow";
            this.btn_dontKnow.Size = new System.Drawing.Size(217, 23);
            this.btn_dontKnow.TabIndex = 7;
            this.btn_dontKnow.Text = "Не известно";
            this.btn_dontKnow.UseVisualStyleBackColor = true;
            this.btn_dontKnow.Click += new System.EventHandler(this.btn_dontKnow_Click);
            // 
            // btn_noMatter
            // 
            this.btn_noMatter.Enabled = false;
            this.btn_noMatter.Location = new System.Drawing.Point(284, 251);
            this.btn_noMatter.Name = "btn_noMatter";
            this.btn_noMatter.Size = new System.Drawing.Size(217, 23);
            this.btn_noMatter.TabIndex = 8;
            this.btn_noMatter.Text = "Не имеет значения";
            this.btn_noMatter.UseVisualStyleBackColor = true;
            this.btn_noMatter.Click += new System.EventHandler(this.btn_noMatter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Выводы";
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToAddRows = false;
            this.dgvQuestion.AllowUserToDeleteRows = false;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Location = new System.Drawing.Point(15, 25);
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.ReadOnly = true;
            this.dgvQuestion.Size = new System.Drawing.Size(240, 482);
            this.dgvQuestion.TabIndex = 10;
            // 
            // dgvProbList
            // 
            this.dgvProbList.AllowUserToAddRows = false;
            this.dgvProbList.AllowUserToDeleteRows = false;
            this.dgvProbList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProbList.Location = new System.Drawing.Point(510, 25);
            this.dgvProbList.Name = "dgvProbList";
            this.dgvProbList.ReadOnly = true;
            this.dgvProbList.Size = new System.Drawing.Size(240, 482);
            this.dgvProbList.TabIndex = 11;
            // 
            // btnGoToQuestionEditForm
            // 
            this.btnGoToQuestionEditForm.Location = new System.Drawing.Point(284, 369);
            this.btnGoToQuestionEditForm.Name = "btnGoToQuestionEditForm";
            this.btnGoToQuestionEditForm.Size = new System.Drawing.Size(217, 48);
            this.btnGoToQuestionEditForm.TabIndex = 12;
            this.btnGoToQuestionEditForm.Text = "Перейти к редактированию \r\nБазы знаний";
            this.btnGoToQuestionEditForm.UseVisualStyleBackColor = true;
            this.btnGoToQuestionEditForm.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 519);
            this.Controls.Add(this.btnGoToQuestionEditForm);
            this.Controls.Add(this.dgvProbList);
            this.Controls.Add(this.dgvQuestion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_noMatter);
            this.Controls.Add(this.btn_dontKnow);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_yes);
            this.Controls.Add(this.lbl_currentQuestion);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.EnabledChanged += new System.EventHandler(this.MainForm_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProbList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label lbl_currentQuestion;
        private System.Windows.Forms.Button btn_yes;
        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.Button btn_dontKnow;
        private System.Windows.Forms.Button btn_noMatter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.DataGridView dgvProbList;
        private System.Windows.Forms.Button btnGoToQuestionEditForm;
    }
}

