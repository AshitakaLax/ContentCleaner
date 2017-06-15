using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSDBnet;

namespace ContentCleaner
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void openInputFileLocation_Click(object sender, EventArgs e)
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      openDialog.Filter = "MP4 (*.mp4|*.mp4|All files (*.*)|*.*";
      if( openDialog.ShowDialog() == DialogResult.OK)
      {
        this.InputFileTextBox.Text = openDialog.FileName;
      }
    }

    private void outputFileButton_Click(object sender, EventArgs e)
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      openDialog.Filter = "MP4 (*.mp4|*.mp4|All files (*.*)|*.*";
      if (openDialog.ShowDialog() == DialogResult.OK)
      {
        this.outputFileTextBox.Text = openDialog.FileName;
      }
    }

    private void FetchButton_Click(object sender, EventArgs e)
    {
      //Osdb.Login()
    }
  }
}
