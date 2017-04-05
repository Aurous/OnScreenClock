using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
  public class Form2 : Form
  {
    private IContainer components = (IContainer) null;
    public int sizze;
    private Button button1;
    private Button button2;
    private Button button3;
    private Label label1;

    public Form2(int sizer)
    {
      this.InitializeComponent();
      this.sizze = sizer;
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      this.label1.Font = new Font(this.label1.Font.FontFamily, (float) this.sizze);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (this.sizze < 1)
        return;
      this.sizze = this.sizze - 1;
      this.label1.Font = new Font(this.label1.Font.FontFamily, (float) this.sizze);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.sizze > 50)
        return;
      this.sizze = this.sizze + 1;
      this.label1.Font = new Font(this.label1.Font.FontFamily, (float) this.sizze);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Form1 form1 = new Form1(this.sizze);
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
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.label1 = new Label();
      this.SuspendLayout();
      this.button1.Location = new Point(12, 152);
      this.button1.Name = "button1";
      this.button1.Size = new Size(251, 44);
      this.button1.TabIndex = 0;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Location = new Point(143, 107);
      this.button2.Name = "button2";
      this.button2.Size = new Size(120, 39);
      this.button2.TabIndex = 1;
      this.button2.Text = "+";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.Location = new Point(12, 107);
      this.button3.Name = "button3";
      this.button3.Size = new Size(125, 39);
      this.button3.TabIndex = 2;
      this.button3.Text = "-";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 49.8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(251, 95);
      this.label1.TabIndex = 3;
      this.label1.Text = "00:00";
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(274, 205);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form2";
      this.ShowIcon = false;
      this.Text = "Change Font";
      this.Load += new EventHandler(this.Form2_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
