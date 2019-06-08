using Crycker.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Crycker.Controls
{
    public partial class MiniChartForm : Form
    {
        // TODO:
        //   - save position
        //   - double click to hide
        //   - don't draw if hidden        

        public Values Values { get; set; }        

        public MiniChartForm()
        {
            InitializeComponent();
            Values = new Values();
            Values.ValuesChanged += Values_ValuesChanged;
        }

        private void Values_ValuesChanged(object sender, System.EventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
            if (Visible)
            {
                var mc = new MiniChart(pictureBox.Width, pictureBox.Height, Values);                
                pictureBox.Image = mc.Image;                
            }
        }

        // dragging form around
        bool mouseDown = false;
        Point lastPos;        

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int xoffset = Form.MousePosition.X - lastPos.X;
                int yoffset = Form.MousePosition.Y - lastPos.Y;
                Left += xoffset;
                Top += yoffset;
                lastPos = Form.MousePosition;
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastPos = Form.MousePosition;
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        
    }
}