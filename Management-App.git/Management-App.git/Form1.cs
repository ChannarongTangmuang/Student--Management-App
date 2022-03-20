using System.Text;
namespace Management_App.git
{
    public partial class Form1 : Form
    {
        GPACal oGPAcal = new GPACal();
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv ";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);
                //this.textBox.Text = readAllText;
                //this.dataGridView.Rows.Add()

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string studentRAW = readAllLine[i];
                    string[] studentSplited = studentRAW.Split(',');

                    Student student = new Student(studentSplited[0], studentSplited[1], studentSplited[2]);

                    addDataToGridView("01", "name", "cis");
                }




            }
        }
        void addDataToGridView(string id, string name, string major)
        {
            this.dataGridView1.Rows.Add(new string[] { id, name, major });
        }
        private void saveTooStripMenuItem_Click(object sender, EventArgs e)
        {

            string strData = string.Empty;

            string filepath = string.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv)|*.csv";
            if(saveFileDialog.ShowDialog() ==DialogResult.OK)
            {
                if(saveFileDialog.FileName != string.Empty)
                {
                    filepath = saveFileDialog.FileName;

                   int row = this.dataGridView1.Rows.Count;

                    for(int i = 0; i <= row; i++)
                    {
                        int column = this.dataGridView1.Columns.Count;
                        for (int j = 0; j < column; j++)
                            strData = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //ToDo save doate
                    }


                    //save file
                    File.WriteAllText(saveFileDialog.FileName, strData,Encoding.UTF8);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Toodo add data to datgridview
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxID.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxName.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBoxMajor.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBoxGPA.Text;
            //Todo calculater GPA,Max Min
            string input = this.textBoxGPA.Text;

            double dInput = Convert.ToDouble(input);
            oGPAcal.addGPA(dInput, Name);

            double gpax = oGPAcal.getGPAx();
            textBoxGPAx.Text = gpax.ToString();

            double max = oGPAcal.getMax();
            textBoxMax.Text = max.ToString();

            double min = oGPAcal.getMin();
            textBoxMin.Text = min.ToString();

        }
    }
}