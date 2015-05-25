using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ES_classification
{
    public partial class FindQuestionForm : Form
    {
        private DBWorker dbworker;
        private Form motherForm;

        public FindQuestionForm(Form f, DBWorker dbw)
        {
            this.dbworker = dbw;
            this.motherForm = f;

            InitializeComponent();
        }








    }
}
