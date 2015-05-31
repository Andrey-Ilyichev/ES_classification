using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ADOX;
using System.Collections;
namespace ES_classification
{
    public partial class startForm : Form
    {
        private DataTable session;
        private DBWorker dbw4bes;

        public startForm()
        {
            InitializeComponent();
        }


        /// //////////////////////////////////////

        public startForm(DataTable sessionList, DBWorker dbw)
        {
            this.dbw4bes = dbw;
            this.session = sessionList;
            InitializeComponent();
        }

        /// ////////////////////////////////////////




        private void btn_createNewDB_Click(object sender, EventArgs e)
        {
            SaveFileDialog createNewDBDialog = new SaveFileDialog();
            createNewDBDialog.InitialDirectory = @"../";
            createNewDBDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;


            createNewDBDialog.Filter = @"DBfiles|*.mdb";
            if (createNewDBDialog.ShowDialog() == DialogResult.OK && createNewDBDialog.FileName.Length > 0)
            {
                try
                {
                    ADOX.CatalogClass cat = new CatalogClass();
                    string str = "provider=Microsoft.Jet.OleDb.4.0;Data Source=" + createNewDBDialog.FileName;
                    cat.Create(str);
                    cat = null;
                    DBWorkerForProductionES dbWorker = new DBWorkerForProductionES(createNewDBDialog.FileName);
                    dbWorker.formStructureKB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            createNewDBDialog = null;
        }

        private void btn_openDBfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"../";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = @"DBfiles|*.mdb";
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0)
            {
                //DBWorkerForProductionES dbWorker = new DBWorkerForProductionES(openFileDialog.FileName);
                //form_edit_kb formEdit = new form_edit_kb(dbWorker);
                //formEdit.ShowDialog();

                DBWorkerForProductionES dbWorker = new DBWorkerForProductionES(openFileDialog.FileName);

                this.Visible = false;
                ES_form esForm = new ES_form(dbWorker,dbw4bes, session);
                esForm.ShowDialog();
                this.Close();
            }
            openFileDialog = null;
        }
    }
}

//TODO: Embed Interop Types посмотреть на что влияет (из Adox)
