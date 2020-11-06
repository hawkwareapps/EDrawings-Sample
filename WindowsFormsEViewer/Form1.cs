using eDrawings.Interop.EModelViewControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEViewer
{
    public partial class Form1 : Form
    {
        private EModelViewControl _eModelViewControl;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.eDrawingsUserControl1.EDrawingsControlLoaded += OnEDrawingControlLoaded;
            this.eDrawingsUserControl1.LoadControl();
        }

        private void OnEDrawingControlLoaded(EModelViewControl obj)
        {
            _eModelViewControl = obj;
            _eModelViewControl.OnFailedLoadingDocument += OnFailedLoadingDocument;
        }

        private void OnFailedLoadingDocument(string FileName, int ErrorCode, string ErrorString)
        {
            MessageBox.Show(ErrorString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "SolidWorks|*.SLDDRW;*.SLDPRT;*.SLDASM";

            if(ofd.ShowDialog() == DialogResult.OK) {
                this.textBox1.Text = ofd.FileName;
                _eModelViewControl.OpenDoc(ofd.FileName, true, false, true, "");
            }
        }
    }
}
