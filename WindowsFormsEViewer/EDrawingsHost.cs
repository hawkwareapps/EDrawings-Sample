using eDrawings.Interop.EModelViewControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEViewer
{
    public class EDrawingsHost : AxHost
    {
        public event Action<EModelViewControl> ControlLoaded;

        private bool _isLoaded;

        public EDrawingsHost() : base("22945A69-1191-4DCF-9E6F-409BDE94D101")
        {
            _isLoaded = false;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!_isLoaded) {
                _isLoaded = true;
                var control = this.GetOcx() as EModelViewControl;
                ControlLoaded?.Invoke(control);
            }
        }
    }
}
