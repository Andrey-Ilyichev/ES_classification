namespace ES_classification
{
    partial class SelectOutcomeWindow
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
            this.dgvOutcome = new System.Windows.Forms.DataGridView();
            this.btnChoose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutcome)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOutcome
            // 
            this.dgvOutcome.AllowUserToAddRows = false;
            this.dgvOutcome.AllowUserToDeleteRows = false;
            this.dgvOutcome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutcome.Location = new System.Drawing.Point(12, 12);
            this.dgvOutcome.Name = "dgvOutcome";
            this.dgvOutcome.ReadOnly = true;
            this.dgvOutcome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutcome.Size = new System.Drawing.Size(468, 204);
            this.dgvOutcome.TabIndex = 0;
            this.dgvOutcome.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOutput_CellMouseClick);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(405, 222);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 1;
            this.btnChoose.Text = "Выбрать";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // SelectOutcomeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 262);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.dgvOutcome);
            this.Name = "SelectOutcomeWindow";
            this.Text = "SelectOutcomeWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutcome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOutcome;
        private System.Windows.Forms.Button btnChoose;
    }
}