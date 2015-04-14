using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADOX;

namespace ES_classification
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnCreateNewKB_Click(object sender, EventArgs e)
        {
            SaveFileDialog createNewDBDialog = new SaveFileDialog();
            createNewDBDialog.InitialDirectory = @"../";
            createNewDBDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;


            createNewDBDialog.Filter = @"DBfiles|*.mdb";
            if (createNewDBDialog.ShowDialog() == DialogResult.OK && createNewDBDialog.FileName.Length > 0)
            {
                try
                {
                    ADOX.Catalog cat = new Catalog();
                    string str = "provider=Microsoft.Jet.OleDb.4.0;Data Source=" + createNewDBDialog.FileName;
                    cat.Create(str);
                    cat = null;
                    DBWorker dbWorker = new DBWorker(createNewDBDialog.FileName);
                    dbWorker.formStructureOfKnowlegeBase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            createNewDBDialog = null;
        }

        private void btnOpenKnowlegeBase_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"../";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = @"DBfiles|*.mdb";
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0)
            {
                DBWorker dbWorker = new DBWorker(openFileDialog.FileName);
                MainForm formEdit = new MainForm(dbWorker);
                formEdit.Show();
            }
            openFileDialog = null;
        }
    }
}
