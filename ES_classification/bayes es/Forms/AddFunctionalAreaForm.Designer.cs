namespace ES_classification
{
    partial class AddFunctionalAreaForm
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
            this.tbFunctionalAreaName = new System.Windows.Forms.TextBox();
            this.btnAddFunctionalArea = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название функциональной области:";
            // 
            // tbFunctionalAreaName
            // 
            this.tbFunctionalAreaName.Location = new System.Drawing.Point(210, 6);
            this.tbFunctionalAreaName.Name = "tbFunctionalAreaName";
            this.tbFunctionalAreaName.Size = new System.Drawing.Size(179, 20);
            this.tbFunctionalAreaName.TabIndex = 1;
            // 
            // btnAddFunctionalArea
            // 
            this.btnAddFunctionalArea.Location = new System.Drawing.Point(12, 35);
            this.btnAddFunctionalArea.Name = "btnAddFunctionalArea";
            this.btnAddFunctionalArea.Size = new System.Drawing.Size(377, 23);
            this.btnAddFunctionalArea.TabIndex = 2;
            this.btnAddFunctionalArea.Text = "Добавить функциональную область";
            this.btnAddFunctionalArea.UseVisualStyleBackColor = true;
            this.btnAddFunctionalArea.Click += new System.EventHandler(this.btnAddFunctionalArea_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(12, 64);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(377, 23);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Назад";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // AddFunctionalAreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 99);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnAddFunctionalArea);
            this.Controls.Add(this.tbFunctionalAreaName);
            this.Controls.Add(this.label1);
            this.Name = "AddFunctionalAreaForm";
            this.Text = "AddFunctionalAreaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFunctionalAreaName;
        private System.Windows.Forms.Button btnAddFunctionalArea;
        private System.Windows.Forms.Button btnReturn;
    }
}