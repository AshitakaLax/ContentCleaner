namespace ContentCleaner
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.FetchButton = new System.Windows.Forms.Button();
      this.outputFileTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.showLabel = new System.Windows.Forms.Label();
      this.seasonLabel = new System.Windows.Forms.Label();
      this.episodeLabel = new System.Windows.Forms.Label();
      this.showTextBox = new System.Windows.Forms.TextBox();
      this.seasonTextBox = new System.Windows.Forms.TextBox();
      this.episodeTextBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.InputFileTextBox = new System.Windows.Forms.TextBox();
      this.openInputFileLocation = new System.Windows.Forms.Button();
      this.outputFileButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // FetchButton
      // 
      this.FetchButton.Location = new System.Drawing.Point(113, 162);
      this.FetchButton.Name = "FetchButton";
      this.FetchButton.Size = new System.Drawing.Size(100, 23);
      this.FetchButton.TabIndex = 0;
      this.FetchButton.Text = "Fetch Subtitles";
      this.FetchButton.UseVisualStyleBackColor = true;
      this.FetchButton.Click += new System.EventHandler(this.FetchButton_Click);
      // 
      // outputFileTextBox
      // 
      this.outputFileTextBox.Location = new System.Drawing.Point(113, 51);
      this.outputFileTextBox.Name = "outputFileTextBox";
      this.outputFileTextBox.Size = new System.Drawing.Size(100, 20);
      this.outputFileTextBox.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(55, 57);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "outputFile";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // showLabel
      // 
      this.showLabel.AutoSize = true;
      this.showLabel.Location = new System.Drawing.Point(55, 83);
      this.showLabel.Name = "showLabel";
      this.showLabel.Size = new System.Drawing.Size(34, 13);
      this.showLabel.TabIndex = 3;
      this.showLabel.Text = "Show";
      // 
      // seasonLabel
      // 
      this.seasonLabel.AutoSize = true;
      this.seasonLabel.Location = new System.Drawing.Point(55, 109);
      this.seasonLabel.Name = "seasonLabel";
      this.seasonLabel.Size = new System.Drawing.Size(43, 13);
      this.seasonLabel.TabIndex = 4;
      this.seasonLabel.Text = "Season";
      // 
      // episodeLabel
      // 
      this.episodeLabel.AutoSize = true;
      this.episodeLabel.Location = new System.Drawing.Point(55, 136);
      this.episodeLabel.Name = "episodeLabel";
      this.episodeLabel.Size = new System.Drawing.Size(45, 13);
      this.episodeLabel.TabIndex = 5;
      this.episodeLabel.Text = "Episode";
      // 
      // showTextBox
      // 
      this.showTextBox.Location = new System.Drawing.Point(113, 83);
      this.showTextBox.Name = "showTextBox";
      this.showTextBox.Size = new System.Drawing.Size(100, 20);
      this.showTextBox.TabIndex = 6;
      // 
      // seasonTextBox
      // 
      this.seasonTextBox.Location = new System.Drawing.Point(113, 110);
      this.seasonTextBox.Name = "seasonTextBox";
      this.seasonTextBox.Size = new System.Drawing.Size(100, 20);
      this.seasonTextBox.TabIndex = 7;
      // 
      // episodeTextBox
      // 
      this.episodeTextBox.Location = new System.Drawing.Point(113, 136);
      this.episodeTextBox.Name = "episodeTextBox";
      this.episodeTextBox.Size = new System.Drawing.Size(100, 20);
      this.episodeTextBox.TabIndex = 8;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(55, 31);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(47, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "InputFile";
      // 
      // InputFileTextBox
      // 
      this.InputFileTextBox.Location = new System.Drawing.Point(113, 25);
      this.InputFileTextBox.Name = "InputFileTextBox";
      this.InputFileTextBox.Size = new System.Drawing.Size(100, 20);
      this.InputFileTextBox.TabIndex = 9;
      // 
      // openInputFileLocation
      // 
      this.openInputFileLocation.Location = new System.Drawing.Point(219, 26);
      this.openInputFileLocation.Name = "openInputFileLocation";
      this.openInputFileLocation.Size = new System.Drawing.Size(29, 23);
      this.openInputFileLocation.TabIndex = 11;
      this.openInputFileLocation.Text = "...";
      this.openInputFileLocation.UseVisualStyleBackColor = true;
      this.openInputFileLocation.Click += new System.EventHandler(this.openInputFileLocation_Click);
      // 
      // outputFileButton
      // 
      this.outputFileButton.Location = new System.Drawing.Point(219, 48);
      this.outputFileButton.Name = "outputFileButton";
      this.outputFileButton.Size = new System.Drawing.Size(29, 23);
      this.outputFileButton.TabIndex = 12;
      this.outputFileButton.Text = "...";
      this.outputFileButton.UseVisualStyleBackColor = true;
      this.outputFileButton.Click += new System.EventHandler(this.outputFileButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.outputFileButton);
      this.Controls.Add(this.openInputFileLocation);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.InputFileTextBox);
      this.Controls.Add(this.episodeTextBox);
      this.Controls.Add(this.seasonTextBox);
      this.Controls.Add(this.showTextBox);
      this.Controls.Add(this.episodeLabel);
      this.Controls.Add(this.seasonLabel);
      this.Controls.Add(this.showLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.outputFileTextBox);
      this.Controls.Add(this.FetchButton);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button FetchButton;
    private System.Windows.Forms.TextBox outputFileTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label showLabel;
    private System.Windows.Forms.Label seasonLabel;
    private System.Windows.Forms.Label episodeLabel;
    private System.Windows.Forms.TextBox showTextBox;
    private System.Windows.Forms.TextBox seasonTextBox;
    private System.Windows.Forms.TextBox episodeTextBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox InputFileTextBox;
    private System.Windows.Forms.Button openInputFileLocation;
    private System.Windows.Forms.Button outputFileButton;
  }
}

