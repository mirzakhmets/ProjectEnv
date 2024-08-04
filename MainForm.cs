
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectEnv
{
  public class MainForm : Form
  {
    private Experiment experiment = (Experiment) null;
    private IContainer components = (IContainer) null;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private TabControl tabControl;
    private TabPage tabPageMain;
    private Button buttonRun;
    private Button buttonOpen;
    private Button buttonSave;
    private Label labelProjectFile;
    private TextBox textBoxProjectFile;
    private TextBox textBoxNumberOfFactors;
    private Label label1;
    private TabPage tabPageHelp;
    private RichTextBox richTextBoxHelp;
    private TabPage tabPageAbout;
    private LinkLabel linkLabelSite;
    private Label labelCopyright;

    public MainForm() {
    	this.InitializeComponent();
    }

    private void buttonOpen_Click(object sender, EventArgs e)
    {
      if (this.openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      CSVFile file = new CSVFile(new ParsingStream((Stream) new FileStream(this.openFileDialog.FileName, FileMode.Open)), this.openFileDialog.FileName);
      this.textBoxProjectFile.Text = this.openFileDialog.FileName;
      this.experiment = new Experiment(file);
    }

    private void buttonRun_Click(object sender, EventArgs e)
    {
      if (this.textBoxNumberOfFactors.Text.Equals("0"))
      {
        int num = (int) MessageBox.Show("Zero number of factors");
      }
      else
      {
        if (this.experiment == null)
          return;
        this.experiment.Optimize(int.Parse(this.textBoxNumberOfFactors.Text));
      }
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      if (this.experiment == null || this.saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.experiment.Save((Stream) new FileStream(this.saveFileDialog.FileName, FileMode.OpenOrCreate));
    }

    private void linkLabelSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.linkLabelSite.LinkVisited = true;
      Process.Start("http://ms-developers.infinityfreeapp.com/?i=1");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
    	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
    	this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
    	this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
    	this.tabControl = new System.Windows.Forms.TabControl();
    	this.tabPageMain = new System.Windows.Forms.TabPage();
    	this.textBoxNumberOfFactors = new System.Windows.Forms.TextBox();
    	this.label1 = new System.Windows.Forms.Label();
    	this.textBoxProjectFile = new System.Windows.Forms.TextBox();
    	this.labelProjectFile = new System.Windows.Forms.Label();
    	this.tabPageHelp = new System.Windows.Forms.TabPage();
    	this.richTextBoxHelp = new System.Windows.Forms.RichTextBox();
    	this.tabPageAbout = new System.Windows.Forms.TabPage();
    	this.linkLabelSite = new System.Windows.Forms.LinkLabel();
    	this.labelCopyright = new System.Windows.Forms.Label();
    	this.buttonRun = new System.Windows.Forms.Button();
    	this.buttonOpen = new System.Windows.Forms.Button();
    	this.buttonSave = new System.Windows.Forms.Button();
    	this.tabControl.SuspendLayout();
    	this.tabPageMain.SuspendLayout();
    	this.tabPageHelp.SuspendLayout();
    	this.tabPageAbout.SuspendLayout();
    	this.SuspendLayout();
    	// 
    	// openFileDialog
    	// 
    	this.openFileDialog.Filter = "CSV files (*.csv)|*.csv";
    	// 
    	// saveFileDialog
    	// 
    	this.saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
    	// 
    	// tabControl
    	// 
    	this.tabControl.Controls.Add(this.tabPageMain);
    	this.tabControl.Controls.Add(this.tabPageHelp);
    	this.tabControl.Controls.Add(this.tabPageAbout);
    	this.tabControl.Location = new System.Drawing.Point(1, 4);
    	this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabControl.Name = "tabControl";
    	this.tabControl.SelectedIndex = 0;
    	this.tabControl.Size = new System.Drawing.Size(637, 345);
    	this.tabControl.TabIndex = 0;
    	// 
    	// tabPageMain
    	// 
    	this.tabPageMain.Controls.Add(this.textBoxNumberOfFactors);
    	this.tabPageMain.Controls.Add(this.label1);
    	this.tabPageMain.Controls.Add(this.textBoxProjectFile);
    	this.tabPageMain.Controls.Add(this.labelProjectFile);
    	this.tabPageMain.Location = new System.Drawing.Point(4, 25);
    	this.tabPageMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageMain.Name = "tabPageMain";
    	this.tabPageMain.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageMain.Size = new System.Drawing.Size(629, 316);
    	this.tabPageMain.TabIndex = 0;
    	this.tabPageMain.Text = "Main";
    	this.tabPageMain.UseVisualStyleBackColor = true;
    	// 
    	// textBoxNumberOfFactors
    	// 
    	this.textBoxNumberOfFactors.Location = new System.Drawing.Point(459, 85);
    	this.textBoxNumberOfFactors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.textBoxNumberOfFactors.Name = "textBoxNumberOfFactors";
    	this.textBoxNumberOfFactors.Size = new System.Drawing.Size(132, 22);
    	this.textBoxNumberOfFactors.TabIndex = 3;
    	this.textBoxNumberOfFactors.Text = "1";
    	this.textBoxNumberOfFactors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
    	// 
    	// label1
    	// 
    	this.label1.AutoSize = true;
    	this.label1.Location = new System.Drawing.Point(21, 85);
    	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.label1.Name = "label1";
    	this.label1.Size = new System.Drawing.Size(197, 17);
    	this.label1.TabIndex = 2;
    	this.label1.Text = "Number of factors to optimize:";
    	// 
    	// textBoxProjectFile
    	// 
    	this.textBoxProjectFile.Location = new System.Drawing.Point(25, 39);
    	this.textBoxProjectFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.textBoxProjectFile.Name = "textBoxProjectFile";
    	this.textBoxProjectFile.ReadOnly = true;
    	this.textBoxProjectFile.Size = new System.Drawing.Size(565, 22);
    	this.textBoxProjectFile.TabIndex = 1;
    	// 
    	// labelProjectFile
    	// 
    	this.labelProjectFile.AutoSize = true;
    	this.labelProjectFile.Location = new System.Drawing.Point(21, 20);
    	this.labelProjectFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelProjectFile.Name = "labelProjectFile";
    	this.labelProjectFile.Size = new System.Drawing.Size(78, 17);
    	this.labelProjectFile.TabIndex = 0;
    	this.labelProjectFile.Text = "Project file:";
    	// 
    	// tabPageHelp
    	// 
    	this.tabPageHelp.Controls.Add(this.richTextBoxHelp);
    	this.tabPageHelp.Location = new System.Drawing.Point(4, 25);
    	this.tabPageHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageHelp.Name = "tabPageHelp";
    	this.tabPageHelp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageHelp.Size = new System.Drawing.Size(629, 316);
    	this.tabPageHelp.TabIndex = 1;
    	this.tabPageHelp.Text = "Help";
    	this.tabPageHelp.UseVisualStyleBackColor = true;
    	// 
    	// richTextBoxHelp
    	// 
    	this.richTextBoxHelp.Location = new System.Drawing.Point(23, 27);
    	this.richTextBoxHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.richTextBoxHelp.Name = "richTextBoxHelp";
    	this.richTextBoxHelp.ReadOnly = true;
    	this.richTextBoxHelp.Size = new System.Drawing.Size(568, 175);
    	this.richTextBoxHelp.TabIndex = 0;
    	this.richTextBoxHelp.Text = resources.GetString("richTextBoxHelp.Text");
    	// 
    	// tabPageAbout
    	// 
    	this.tabPageAbout.Controls.Add(this.linkLabelSite);
    	this.tabPageAbout.Controls.Add(this.labelCopyright);
    	this.tabPageAbout.Location = new System.Drawing.Point(4, 25);
    	this.tabPageAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageAbout.Name = "tabPageAbout";
    	this.tabPageAbout.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageAbout.Size = new System.Drawing.Size(629, 316);
    	this.tabPageAbout.TabIndex = 2;
    	this.tabPageAbout.Text = "About";
    	this.tabPageAbout.UseVisualStyleBackColor = true;
    	// 
    	// linkLabelSite
    	// 
    	this.linkLabelSite.AutoSize = true;
    	this.linkLabelSite.Location = new System.Drawing.Point(21, 53);
    	this.linkLabelSite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.linkLabelSite.Name = "linkLabelSite";
    	this.linkLabelSite.Size = new System.Drawing.Size(260, 17);
    	this.linkLabelSite.TabIndex = 1;
    	this.linkLabelSite.TabStop = true;
    	this.linkLabelSite.Text = "https://ovg-developers.mystrikingly.com/";
    	this.linkLabelSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSite_LinkClicked);
    	// 
    	// labelCopyright
    	// 
    	this.labelCopyright.AutoSize = true;
    	this.labelCopyright.Location = new System.Drawing.Point(21, 20);
    	this.labelCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelCopyright.Name = "labelCopyright";
    	this.labelCopyright.Size = new System.Drawing.Size(239, 17);
    	this.labelCopyright.TabIndex = 0;
    	this.labelCopyright.Text = "Copyright 2022 (C) OVG-Developers";
    	// 
    	// buttonRun
    	// 
    	this.buttonRun.Location = new System.Drawing.Point(513, 356);
    	this.buttonRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonRun.Name = "buttonRun";
    	this.buttonRun.Size = new System.Drawing.Size(120, 32);
    	this.buttonRun.TabIndex = 1;
    	this.buttonRun.Text = "Run";
    	this.buttonRun.UseVisualStyleBackColor = true;
    	this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
    	// 
    	// buttonOpen
    	// 
    	this.buttonOpen.Location = new System.Drawing.Point(1, 356);
    	this.buttonOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonOpen.Name = "buttonOpen";
    	this.buttonOpen.Size = new System.Drawing.Size(100, 32);
    	this.buttonOpen.TabIndex = 2;
    	this.buttonOpen.Text = "Open...";
    	this.buttonOpen.UseVisualStyleBackColor = true;
    	this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
    	// 
    	// buttonSave
    	// 
    	this.buttonSave.Location = new System.Drawing.Point(109, 356);
    	this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonSave.Name = "buttonSave";
    	this.buttonSave.Size = new System.Drawing.Size(103, 32);
    	this.buttonSave.TabIndex = 3;
    	this.buttonSave.Text = "Save...";
    	this.buttonSave.UseVisualStyleBackColor = true;
    	this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
    	// 
    	// MainForm
    	// 
    	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    	this.ClientSize = new System.Drawing.Size(640, 396);
    	this.Controls.Add(this.buttonSave);
    	this.Controls.Add(this.buttonOpen);
    	this.Controls.Add(this.buttonRun);
    	this.Controls.Add(this.tabControl);
    	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
    	this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.MaximizeBox = false;
    	this.MinimizeBox = false;
    	this.Name = "MainForm";
    	this.Text = "ProjectEnv";
    	this.tabControl.ResumeLayout(false);
    	this.tabPageMain.ResumeLayout(false);
    	this.tabPageMain.PerformLayout();
    	this.tabPageHelp.ResumeLayout(false);
    	this.tabPageAbout.ResumeLayout(false);
    	this.tabPageAbout.PerformLayout();
    	this.ResumeLayout(false);

    }
  }
}
