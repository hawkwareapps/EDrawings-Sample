using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eDrawings.Interop.EModelViewControl;

namespace WindowsFormsEViewer
{
    public partial class EDrawingsUserControl : UserControl
    {
        public event Action<EModelViewControl> EDrawingsControlLoaded;

        public EDrawingsUserControl()
        {
            InitializeComponent();
        }

        public void LoadControl()
        {
            var host = new EDrawingsHost();
            host.ControlLoaded += OnControlLoaded;
            this.Controls.Add(host);
            host.Dock = DockStyle.Fill;
        }

        private void OnControlLoaded(EModelViewControl obj)
        {
            EDrawingsControlLoaded?.Invoke(obj);
        }
    }
}
