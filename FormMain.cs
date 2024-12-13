using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace Example1
{
    public partial class FormMain : Form
    {
        private VideoCapture _capture = null;
        private Mat _frame;
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                bool canCapture = _capture.Retrieve(_frame, 0);
                if (canCapture)
                {
                    imageBox1.Image = _frame;
                }
            }
          
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _capture = new VideoCapture();
                _capture.ImageGrabbed += ProcessFrame;
                _frame = new Mat();

            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_capture != null) 
            {
                _capture.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if ( _capture != null)
                {
                    _capture.Pause();
                    _capture.Dispose();

                }
               
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                _capture.Pause();
            }
        }

        private void buttonFlipHor_Click(object sender, EventArgs e)
        {
            if (_capture != null)
                _capture.FlipHorizontal = !_capture.FlipHorizontal;
        }

        private void buttonFlipVer_Click(object sender, EventArgs e)
        {
            if (_capture != null)
                _capture.FlipVertical = !_capture.FlipVertical;
        }
    }
}
