using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
  public class Form1 : Form
  {
    private IContainer components = (IContainer) null;
    public const int WM_NCLBUTTONDOWN = 161;
    public const int HT_CAPTION = 2;
    public int value;
    public string sizing;
    private Timer timer1;
    private Label label1;

    public Form1(int sizer)
    {
      this.InitializeComponent();
      this.sizing = "42";
      this.value = 42;
      if (sizer == 0)
        return;
      this.value = sizer;
      this.sizing = sizer.ToString();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      int.TryParse(this.sizing, out this.value);
      if (this.value >= 0)
        this.label1.Font = new Font(this.label1.Font.FontFamily, (float) this.value);
      this.label1.Text = DateTime.Now.ToShortTimeString();
    }

    private void label1_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show("Would You Like To Exit This Program?", "Exit", MessageBoxButtons.YesNo))
      {
        case DialogResult.Yes:
          this.Close();
          break;
        case DialogResult.Cancel:
          new Form2(this.value).Show();
          break;
      }
    }

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    private void label1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      Form1.ReleaseCapture();
      Form1.SendMessage(this.Handle, 161, 2, 0);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.BackColor = Color.White;
      this.TransparencyKey = Color.White;
    }

    private void label1_DoubleClick(object sender, EventArgs e)
    {
      if (MessageBox.Show("Would You Like To Exit This Program?", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.timer1 = new Timer(this.components);
      this.label1 = new Label();
      this.SuspendLayout();
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.label1.BackColor = Color.Transparent;
      this.label1.Cursor = Cursors.Default;
      this.label1.Font = new Font("Microsoft Sans Serif", 19.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(12, 50);
      this.label1.Name = "label1";
      this.label1.Size = new Size(416, 161);
      this.label1.TabIndex = 0;
      this.label1.Text = "XXXXX";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.label1.DoubleClick += new EventHandler(this.label1_DoubleClick);
      this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(440, 410);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "Form1";
      this.Text = "Form1";
      this.TopMost = true;
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
    }
  }
}
