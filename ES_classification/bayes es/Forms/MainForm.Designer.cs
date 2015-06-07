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
            this.btnGoToKBEditForm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbManualMode = new System.Windows.Forms.GroupBox();
            this.dgvSession = new System.Windows.Forms.DataGridView();
            this.gbAnswerManualMode = new System.Windows.Forms.GroupBox();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.rbDontKnow = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbNoMatter = new System.Windows.Forms.RadioButton();
            this.btnClearSession = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnSelectQuestion = new System.Windows.Forms.Button();
            this.btnGetResult = new System.Windows.Forms.Button();
            this.gbAutoMode = new System.Windows.Forms.GroupBox();
            this.btnGoToProductionES = new System.Windows.Forms.Button();
            this.cbManualMode = new System.Windows.Forms.CheckBox();
            this.chkBoxTrainingMode = new System.Windows.Forms.CheckBox();
            this.gbAnswers = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProbList)).BeginInit();
            this.gbManualMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).BeginInit();
            this.gbAnswerManualMode.SuspendLayout();
            this.gbAutoMode.SuspendLayout();
            this.gbAnswers.SuspendLayout();
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
            this.btn_start.Location = new System.Drawing.Point(20, 40);
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
            this.btn_stop.Location = new System.Drawing.Point(20, 69);
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
            this.lbl_currentQuestion.Location = new System.Drawing.Point(20, 111);
            this.lbl_currentQuestion.Name = "lbl_currentQuestion";
            this.lbl_currentQuestion.Size = new System.Drawing.Size(10, 13);
            this.lbl_currentQuestion.TabIndex = 4;
            this.lbl_currentQuestion.Text = ".";
            // 
            // btn_yes
            // 
            this.btn_yes.Location = new System.Drawing.Point(20, 19);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Size = new System.Drawing.Size(217, 23);
            this.btn_yes.TabIndex = 5;
            this.btn_yes.Text = "Да";
            this.btn_yes.UseVisualStyleBackColor = true;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            // 
            // btn_no
            // 
            this.btn_no.Location = new System.Drawing.Point(20, 48);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(217, 23);
            this.btn_no.TabIndex = 6;
            this.btn_no.Text = "Нет";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_dontKnow
            // 
            this.btn_dontKnow.Location = new System.Drawing.Point(20, 77);
            this.btn_dontKnow.Name = "btn_dontKnow";
            this.btn_dontKnow.Size = new System.Drawing.Size(217, 23);
            this.btn_dontKnow.TabIndex = 7;
            this.btn_dontKnow.Text = "Не известно";
            this.btn_dontKnow.UseVisualStyleBackColor = true;
            this.btn_dontKnow.Click += new System.EventHandler(this.btn_dontKnow_Click);
            // 
            // btn_noMatter
            // 
            this.btn_noMatter.Location = new System.Drawing.Point(20, 106);
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
            this.label2.Location = new System.Drawing.Point(519, 9);
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
            this.dgvQuestion.MultiSelect = false;
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.ReadOnly = true;
            this.dgvQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestion.Size = new System.Drawing.Size(240, 482);
            this.dgvQuestion.TabIndex = 10;
            // 
            // dgvProbList
            // 
            this.dgvProbList.AllowUserToAddRows = false;
            this.dgvProbList.AllowUserToDeleteRows = false;
            this.dgvProbList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProbList.Location = new System.Drawing.Point(519, 25);
            this.dgvProbList.Name = "dgvProbList";
            this.dgvProbList.ReadOnly = true;
            this.dgvProbList.Size = new System.Drawing.Size(338, 482);
            this.dgvProbList.TabIndex = 11;
            // 
            // btnGoToKBEditForm
            // 
            this.btnGoToKBEditForm.Location = new System.Drawing.Point(281, 420);
            this.btnGoToKBEditForm.Name = "btnGoToKBEditForm";
            this.btnGoToKBEditForm.Size = new System.Drawing.Size(217, 48);
            this.btnGoToKBEditForm.TabIndex = 12;
            this.btnGoToKBEditForm.Text = "Перейти к редактированию \r\nБазы знаний";
            this.btnGoToKBEditForm.UseVisualStyleBackColor = true;
            this.btnGoToKBEditForm.Click += new System.EventHandler(this.btnGoToKBEditForm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(915, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "!!!btn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbManualMode
            // 
            this.gbManualMode.Controls.Add(this.dgvSession);
            this.gbManualMode.Location = new System.Drawing.Point(247, 532);
            this.gbManualMode.Name = "gbManualMode";
            this.gbManualMode.Size = new System.Drawing.Size(292, 208);
            this.gbManualMode.TabIndex = 14;
            this.gbManualMode.TabStop = false;
            this.gbManualMode.Text = "Текущая сессия сеанса";
            // 
            // dgvSession
            // 
            this.dgvSession.AllowUserToAddRows = false;
            this.dgvSession.AllowUserToDeleteRows = false;
            this.dgvSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSession.Location = new System.Drawing.Point(6, 19);
            this.dgvSession.MultiSelect = false;
            this.dgvSession.Name = "dgvSession";
            this.dgvSession.ReadOnly = true;
            this.dgvSession.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSession.Size = new System.Drawing.Size(274, 183);
            this.dgvSession.TabIndex = 7;
            // 
            // gbAnswerManualMode
            // 
            this.gbAnswerManualMode.Controls.Add(this.rbYes);
            this.gbAnswerManualMode.Controls.Add(this.rbDontKnow);
            this.gbAnswerManualMode.Controls.Add(this.rbNo);
            this.gbAnswerManualMode.Controls.Add(this.rbNoMatter);
            this.gbAnswerManualMode.Enabled = false;
            this.gbAnswerManualMode.Location = new System.Drawing.Point(991, 474);
            this.gbAnswerManualMode.Name = "gbAnswerManualMode";
            this.gbAnswerManualMode.Size = new System.Drawing.Size(200, 125);
            this.gbAnswerManualMode.TabIndex = 4;
            this.gbAnswerManualMode.TabStop = false;
            this.gbAnswerManualMode.Text = "Ответ";
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.Checked = true;
            this.rbYes.Location = new System.Drawing.Point(6, 19);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(37, 17);
            this.rbYes.TabIndex = 0;
            this.rbYes.TabStop = true;
            this.rbYes.Text = "да";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // rbDontKnow
            // 
            this.rbDontKnow.AutoSize = true;
            this.rbDontKnow.Location = new System.Drawing.Point(6, 65);
            this.rbDontKnow.Name = "rbDontKnow";
            this.rbDontKnow.Size = new System.Drawing.Size(89, 17);
            this.rbDontKnow.TabIndex = 3;
            this.rbDontKnow.Text = "Не известно";
            this.rbDontKnow.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(6, 42);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(42, 17);
            this.rbNo.TabIndex = 1;
            this.rbNo.Text = "нет";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbNoMatter
            // 
            this.rbNoMatter.AutoSize = true;
            this.rbNoMatter.Location = new System.Drawing.Point(5, 88);
            this.rbNoMatter.Name = "rbNoMatter";
            this.rbNoMatter.Size = new System.Drawing.Size(121, 17);
            this.rbNoMatter.TabIndex = 2;
            this.rbNoMatter.Text = "не имеет значения";
            this.rbNoMatter.UseVisualStyleBackColor = true;
            // 
            // btnClearSession
            // 
            this.btnClearSession.Location = new System.Drawing.Point(281, 347);
            this.btnClearSession.Name = "btnClearSession";
            this.btnClearSession.Size = new System.Drawing.Size(217, 23);
            this.btnClearSession.TabIndex = 9;
            this.btnClearSession.Text = "Очистить список";
            this.btnClearSession.UseVisualStyleBackColor = true;
            this.btnClearSession.Click += new System.EventHandler(this.btnClearSession_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(281, 385);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(217, 23);
            this.btnDeleteQuestion.TabIndex = 6;
            this.btnDeleteQuestion.Text = "Удалить вопрос";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnSelectQuestion
            // 
            this.btnSelectQuestion.Location = new System.Drawing.Point(991, 653);
            this.btnSelectQuestion.Name = "btnSelectQuestion";
            this.btnSelectQuestion.Size = new System.Drawing.Size(138, 23);
            this.btnSelectQuestion.TabIndex = 5;
            this.btnSelectQuestion.Text = "Ответить на вопрос";
            this.btnSelectQuestion.UseVisualStyleBackColor = true;
            this.btnSelectQuestion.Click += new System.EventHandler(this.btnSelectQuestion_Click);
            // 
            // btnGetResult
            // 
            this.btnGetResult.Location = new System.Drawing.Point(281, 318);
            this.btnGetResult.Name = "btnGetResult";
            this.btnGetResult.Size = new System.Drawing.Size(217, 23);
            this.btnGetResult.TabIndex = 8;
            this.btnGetResult.Text = "Получить результат";
            this.btnGetResult.UseVisualStyleBackColor = true;
            this.btnGetResult.Click += new System.EventHandler(this.btnGetResult_Click);
            // 
            // gbAutoMode
            // 
            this.gbAutoMode.Controls.Add(this.btn_start);
            this.gbAutoMode.Controls.Add(this.btn_stop);
            this.gbAutoMode.Controls.Add(this.lbl_currentQuestion);
            this.gbAutoMode.Location = new System.Drawing.Point(261, 12);
            this.gbAutoMode.Name = "gbAutoMode";
            this.gbAutoMode.Size = new System.Drawing.Size(252, 135);
            this.gbAutoMode.TabIndex = 15;
            this.gbAutoMode.TabStop = false;
            this.gbAutoMode.Text = "Автоматический выбор вопроса";
            // 
            // btnGoToProductionES
            // 
            this.btnGoToProductionES.Location = new System.Drawing.Point(724, 665);
            this.btnGoToProductionES.Name = "btnGoToProductionES";
            this.btnGoToProductionES.Size = new System.Drawing.Size(133, 69);
            this.btnGoToProductionES.TabIndex = 17;
            this.btnGoToProductionES.Text = "Перейти в систему продукционного вывода";
            this.btnGoToProductionES.UseVisualStyleBackColor = true;
            this.btnGoToProductionES.Click += new System.EventHandler(this.btnGoToProductionES_Click);
            // 
            // cbManualMode
            // 
            this.cbManualMode.AutoSize = true;
            this.cbManualMode.Enabled = false;
            this.cbManualMode.Location = new System.Drawing.Point(991, 723);
            this.cbManualMode.Name = "cbManualMode";
            this.cbManualMode.Size = new System.Drawing.Size(98, 17);
            this.cbManualMode.TabIndex = 16;
            this.cbManualMode.Text = "Ручной режим";
            this.cbManualMode.UseVisualStyleBackColor = true;
            // 
            // chkBoxTrainingMode
            // 
            this.chkBoxTrainingMode.AutoSize = true;
            this.chkBoxTrainingMode.Checked = true;
            this.chkBoxTrainingMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxTrainingMode.Location = new System.Drawing.Point(303, 474);
            this.chkBoxTrainingMode.Name = "chkBoxTrainingMode";
            this.chkBoxTrainingMode.Size = new System.Drawing.Size(158, 17);
            this.chkBoxTrainingMode.TabIndex = 18;
            this.chkBoxTrainingMode.Text = "Режим обучения системы";
            this.chkBoxTrainingMode.UseVisualStyleBackColor = true;
            // 
            // gbAnswers
            // 
            this.gbAnswers.Controls.Add(this.btn_yes);
            this.gbAnswers.Controls.Add(this.btn_noMatter);
            this.gbAnswers.Controls.Add(this.btn_dontKnow);
            this.gbAnswers.Controls.Add(this.btn_no);
            this.gbAnswers.Location = new System.Drawing.Point(261, 153);
            this.gbAnswers.Name = "gbAnswers";
            this.gbAnswers.Size = new System.Drawing.Size(252, 142);
            this.gbAnswers.TabIndex = 19;
            this.gbAnswers.TabStop = false;
            this.gbAnswers.Text = "Ответы";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 752);
            this.Controls.Add(this.btnClearSession);
            this.Controls.Add(this.gbAnswerManualMode);
            this.Controls.Add(this.gbAnswers);
            this.Controls.Add(this.btnGetResult);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.chkBoxTrainingMode);
            this.Controls.Add(this.btnSelectQuestion);
            this.Controls.Add(this.btnGoToProductionES);
            this.Controls.Add(this.cbManualMode);
            this.Controls.Add(this.gbAutoMode);
            this.Controls.Add(this.gbManualMode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGoToKBEditForm);
            this.Controls.Add(this.dgvProbList);
            this.Controls.Add(this.dgvQuestion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.EnabledChanged += new System.EventHandler(this.MainForm_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProbList)).EndInit();
            this.gbManualMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).EndInit();
            this.gbAnswerManualMode.ResumeLayout(false);
            this.gbAnswerManualMode.PerformLayout();
            this.gbAutoMode.ResumeLayout(false);
            this.gbAutoMode.PerformLayout();
            this.gbAnswers.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnGoToKBEditForm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbManualMode;
        private System.Windows.Forms.Button btnSelectQuestion;
        private System.Windows.Forms.GroupBox gbAnswerManualMode;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.RadioButton rbDontKnow;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbNoMatter;
        private System.Windows.Forms.Button btnGetResult;
        private System.Windows.Forms.DataGridView dgvSession;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.GroupBox gbAutoMode;
        private System.Windows.Forms.Button btnClearSession;
        private System.Windows.Forms.Button btnGoToProductionES;
        private System.Windows.Forms.CheckBox cbManualMode;
        private System.Windows.Forms.CheckBox chkBoxTrainingMode;
        private System.Windows.Forms.GroupBox gbAnswers;
    }
}

