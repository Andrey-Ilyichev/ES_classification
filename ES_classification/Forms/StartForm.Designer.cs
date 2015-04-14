namespace ES_classification
{
    partial class StartForm
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
            this.btnCreateNewKB = new System.Windows.Forms.Button();
            this.btnOpenKnowlegeBase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateNewKB
            // 
            this.btnCreateNewKB.Location = new System.Drawing.Point(12, 12);
            this.btnCreateNewKB.Name = "btnCreateNewKB";
            this.btnCreateNewKB.Size = new System.Drawing.Size(308, 23);
            this.btnCreateNewKB.TabIndex = 0;
            this.btnCreateNewKB.Text = "Создать новую Базу знаний";
            this.btnCreateNewKB.UseVisualStyleBackColor = true;
            this.btnCreateNewKB.Click += new System.EventHandler(this.btnCreateNewKB_Click);
            // 
            // btnOpenKnowlegeBase
            // 
            this.btnOpenKnowlegeBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenKnowlegeBase.Location = new System.Drawing.Point(12, 41);
            this.btnOpenKnowlegeBase.Name = "btnOpenKnowlegeBase";
            this.btnOpenKnowlegeBase.Size = new System.Drawing.Size(308, 23);
            this.btnOpenKnowlegeBase.TabIndex = 1;
            this.btnOpenKnowlegeBase.Text = "Открыть существующую Базу знаний";
            this.btnOpenKnowlegeBase.UseVisualStyleBackColor = true;
            this.btnOpenKnowlegeBase.Click += new System.EventHandler(this.btnOpenKnowlegeBase_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 76);
            this.Controls.Add(this.btnOpenKnowlegeBase);
            this.Controls.Add(this.btnCreateNewKB);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateNewKB;
        private System.Windows.Forms.Button btnOpenKnowlegeBase;
    }
}