namespace SplitImageSeries
{
    partial class SplitImageSeriesMainFormVersie2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitImageSeriesMainFormVersie2));
            this.bgwFileCheck = new System.ComponentModel.BackgroundWorker();
            this.lbRemadeImages = new System.Windows.Forms.ListBox();
            this.lbOriginalImages = new System.Windows.Forms.ListBox();
            this.bSubmit = new System.Windows.Forms.Button();
            this.grpbxOpenFiles = new System.Windows.Forms.GroupBox();
            this.btOpenFiles = new System.Windows.Forms.Button();
            this.lOpenFileLocation = new System.Windows.Forms.Label();
            this.btCancelFileCheck = new System.Windows.Forms.Button();
            this.pgbCheckImageDimensions = new System.Windows.Forms.ProgressBar();
            this.lProgressFileCheck = new System.Windows.Forms.Label();
            this.grpbxSaveFiles = new System.Windows.Forms.GroupBox();
            this.btSaveFiles = new System.Windows.Forms.Button();
            this.lSaveFileLocation = new System.Windows.Forms.Label();
            this.lOriginalCount = new System.Windows.Forms.Label();
            this.lRemadeCount = new System.Windows.Forms.Label();
            this.pgbSplitProgress = new System.Windows.Forms.ProgressBar();
            this.lPercentageDone = new System.Windows.Forms.Label();
            this.lTotalProgress = new System.Windows.Forms.Label();
            this.pgbTotalProgress = new System.Windows.Forms.ProgressBar();
            this.lRuntime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbxOpenFiles.SuspendLayout();
            this.grpbxSaveFiles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwFileCheck
            // 
            this.bgwFileCheck.WorkerReportsProgress = true;
            this.bgwFileCheck.WorkerSupportsCancellation = true;
            this.bgwFileCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgwFileCheck.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            this.bgwFileCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // lbRemadeImages
            // 
            this.lbRemadeImages.FormattingEnabled = true;
            this.lbRemadeImages.ItemHeight = 16;
            this.lbRemadeImages.Location = new System.Drawing.Point(177, 42);
            this.lbRemadeImages.Margin = new System.Windows.Forms.Padding(4);
            this.lbRemadeImages.Name = "lbRemadeImages";
            this.lbRemadeImages.Size = new System.Drawing.Size(394, 356);
            this.lbRemadeImages.TabIndex = 26;
            // 
            // lbOriginalImages
            // 
            this.lbOriginalImages.FormattingEnabled = true;
            this.lbOriginalImages.ItemHeight = 16;
            this.lbOriginalImages.Location = new System.Drawing.Point(8, 42);
            this.lbOriginalImages.Margin = new System.Windows.Forms.Padding(4);
            this.lbOriginalImages.Name = "lbOriginalImages";
            this.lbOriginalImages.Size = new System.Drawing.Size(160, 356);
            this.lbOriginalImages.Sorted = true;
            this.lbOriginalImages.TabIndex = 24;
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(8, 55);
            this.bSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(100, 28);
            this.bSubmit.TabIndex = 25;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // grpbxOpenFiles
            // 
            this.grpbxOpenFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpbxOpenFiles.Controls.Add(this.btOpenFiles);
            this.grpbxOpenFiles.Controls.Add(this.lOpenFileLocation);
            this.grpbxOpenFiles.Controls.Add(this.btCancelFileCheck);
            this.grpbxOpenFiles.Controls.Add(this.pgbCheckImageDimensions);
            this.grpbxOpenFiles.Controls.Add(this.lProgressFileCheck);
            this.grpbxOpenFiles.Location = new System.Drawing.Point(13, 13);
            this.grpbxOpenFiles.Margin = new System.Windows.Forms.Padding(4);
            this.grpbxOpenFiles.Name = "grpbxOpenFiles";
            this.grpbxOpenFiles.Padding = new System.Windows.Forms.Padding(4);
            this.grpbxOpenFiles.Size = new System.Drawing.Size(400, 122);
            this.grpbxOpenFiles.TabIndex = 27;
            this.grpbxOpenFiles.TabStop = false;
            this.grpbxOpenFiles.Text = "Open";
            // 
            // btOpenFiles
            // 
            this.btOpenFiles.Location = new System.Drawing.Point(8, 23);
            this.btOpenFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btOpenFiles.Name = "btOpenFiles";
            this.btOpenFiles.Size = new System.Drawing.Size(100, 28);
            this.btOpenFiles.TabIndex = 0;
            this.btOpenFiles.Text = "Open";
            this.btOpenFiles.UseVisualStyleBackColor = true;
            this.btOpenFiles.Click += new System.EventHandler(this.btOpenFiles_Click);
            // 
            // lOpenFileLocation
            // 
            this.lOpenFileLocation.AutoSize = true;
            this.lOpenFileLocation.Location = new System.Drawing.Point(116, 55);
            this.lOpenFileLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lOpenFileLocation.Name = "lOpenFileLocation";
            this.lOpenFileLocation.Size = new System.Drawing.Size(46, 17);
            this.lOpenFileLocation.TabIndex = 2;
            this.lOpenFileLocation.Text = "label1";
            this.lOpenFileLocation.Visible = false;
            // 
            // btCancelFileCheck
            // 
            this.btCancelFileCheck.Location = new System.Drawing.Point(8, 83);
            this.btCancelFileCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btCancelFileCheck.Name = "btCancelFileCheck";
            this.btCancelFileCheck.Size = new System.Drawing.Size(100, 28);
            this.btCancelFileCheck.TabIndex = 11;
            this.btCancelFileCheck.Text = "Cancel";
            this.btCancelFileCheck.UseVisualStyleBackColor = true;
            this.btCancelFileCheck.Click += new System.EventHandler(this.btCancelFileCheck_Click);
            // 
            // pgbCheckImageDimensions
            // 
            this.pgbCheckImageDimensions.Location = new System.Drawing.Point(116, 23);
            this.pgbCheckImageDimensions.Margin = new System.Windows.Forms.Padding(4);
            this.pgbCheckImageDimensions.Name = "pgbCheckImageDimensions";
            this.pgbCheckImageDimensions.Size = new System.Drawing.Size(133, 28);
            this.pgbCheckImageDimensions.TabIndex = 3;
            // 
            // lProgressFileCheck
            // 
            this.lProgressFileCheck.AutoSize = true;
            this.lProgressFileCheck.Location = new System.Drawing.Point(116, 89);
            this.lProgressFileCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lProgressFileCheck.Name = "lProgressFileCheck";
            this.lProgressFileCheck.Size = new System.Drawing.Size(46, 17);
            this.lProgressFileCheck.TabIndex = 6;
            this.lProgressFileCheck.Text = "label4";
            this.lProgressFileCheck.Visible = false;
            // 
            // grpbxSaveFiles
            // 
            this.grpbxSaveFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpbxSaveFiles.Controls.Add(this.label1);
            this.grpbxSaveFiles.Controls.Add(this.numericUpDown1);
            this.grpbxSaveFiles.Controls.Add(this.btSaveFiles);
            this.grpbxSaveFiles.Controls.Add(this.lSaveFileLocation);
            this.grpbxSaveFiles.Location = new System.Drawing.Point(13, 143);
            this.grpbxSaveFiles.Margin = new System.Windows.Forms.Padding(4);
            this.grpbxSaveFiles.Name = "grpbxSaveFiles";
            this.grpbxSaveFiles.Padding = new System.Windows.Forms.Padding(4);
            this.grpbxSaveFiles.Size = new System.Drawing.Size(400, 91);
            this.grpbxSaveFiles.TabIndex = 28;
            this.grpbxSaveFiles.TabStop = false;
            this.grpbxSaveFiles.Text = "Save";
            // 
            // btSaveFiles
            // 
            this.btSaveFiles.Location = new System.Drawing.Point(8, 23);
            this.btSaveFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btSaveFiles.Name = "btSaveFiles";
            this.btSaveFiles.Size = new System.Drawing.Size(100, 28);
            this.btSaveFiles.TabIndex = 1;
            this.btSaveFiles.Text = "Save";
            this.btSaveFiles.UseVisualStyleBackColor = true;
            this.btSaveFiles.Click += new System.EventHandler(this.btSaveFiles_Click);
            // 
            // lSaveFileLocation
            // 
            this.lSaveFileLocation.AutoSize = true;
            this.lSaveFileLocation.Location = new System.Drawing.Point(8, 55);
            this.lSaveFileLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lSaveFileLocation.Name = "lSaveFileLocation";
            this.lSaveFileLocation.Size = new System.Drawing.Size(46, 17);
            this.lSaveFileLocation.TabIndex = 4;
            this.lSaveFileLocation.Text = "label2";
            this.lSaveFileLocation.Visible = false;
            // 
            // lOriginalCount
            // 
            this.lOriginalCount.AutoSize = true;
            this.lOriginalCount.Location = new System.Drawing.Point(8, 22);
            this.lOriginalCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lOriginalCount.Name = "lOriginalCount";
            this.lOriginalCount.Size = new System.Drawing.Size(46, 17);
            this.lOriginalCount.TabIndex = 29;
            this.lOriginalCount.Text = "label3";
            this.lOriginalCount.Visible = false;
            // 
            // lRemadeCount
            // 
            this.lRemadeCount.AutoSize = true;
            this.lRemadeCount.Location = new System.Drawing.Point(177, 22);
            this.lRemadeCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRemadeCount.Name = "lRemadeCount";
            this.lRemadeCount.Size = new System.Drawing.Size(46, 17);
            this.lRemadeCount.TabIndex = 30;
            this.lRemadeCount.Text = "label5";
            this.lRemadeCount.Visible = false;
            // 
            // pgbSplitProgress
            // 
            this.pgbSplitProgress.Location = new System.Drawing.Point(8, 95);
            this.pgbSplitProgress.Margin = new System.Windows.Forms.Padding(4);
            this.pgbSplitProgress.Name = "pgbSplitProgress";
            this.pgbSplitProgress.Size = new System.Drawing.Size(100, 28);
            this.pgbSplitProgress.TabIndex = 31;
            // 
            // lPercentageDone
            // 
            this.lPercentageDone.AutoSize = true;
            this.lPercentageDone.Location = new System.Drawing.Point(116, 101);
            this.lPercentageDone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPercentageDone.Name = "lPercentageDone";
            this.lPercentageDone.Size = new System.Drawing.Size(46, 17);
            this.lPercentageDone.TabIndex = 32;
            this.lPercentageDone.Text = "label6";
            this.lPercentageDone.Visible = false;
            // 
            // lTotalProgress
            // 
            this.lTotalProgress.AutoSize = true;
            this.lTotalProgress.Location = new System.Drawing.Point(116, 137);
            this.lTotalProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTotalProgress.Name = "lTotalProgress";
            this.lTotalProgress.Size = new System.Drawing.Size(46, 17);
            this.lTotalProgress.TabIndex = 33;
            this.lTotalProgress.Text = "label6";
            this.lTotalProgress.Visible = false;
            // 
            // pgbTotalProgress
            // 
            this.pgbTotalProgress.Location = new System.Drawing.Point(8, 130);
            this.pgbTotalProgress.Margin = new System.Windows.Forms.Padding(4);
            this.pgbTotalProgress.Name = "pgbTotalProgress";
            this.pgbTotalProgress.Size = new System.Drawing.Size(100, 28);
            this.pgbTotalProgress.TabIndex = 34;
            // 
            // lRuntime
            // 
            this.lRuntime.AutoSize = true;
            this.lRuntime.Location = new System.Drawing.Point(116, 62);
            this.lRuntime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRuntime.Name = "lRuntime";
            this.lRuntime.Size = new System.Drawing.Size(46, 17);
            this.lRuntime.TabIndex = 35;
            this.lRuntime.Text = "label6";
            this.lRuntime.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.bSubmit);
            this.groupBox1.Controls.Add(this.pgbTotalProgress);
            this.groupBox1.Controls.Add(this.pgbSplitProgress);
            this.groupBox1.Controls.Add(this.lTotalProgress);
            this.groupBox1.Controls.Add(this.lPercentageDone);
            this.groupBox1.Controls.Add(this.lRuntime);
            this.groupBox1.Location = new System.Drawing.Point(13, 242);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(400, 181);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Submit";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(252, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 21);
            this.radioButton2.TabIndex = 38;
            this.radioButton2.Text = "32 Threads";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(102, 21);
            this.radioButton1.TabIndex = 37;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "16 Threads";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.lbOriginalImages);
            this.groupBox2.Controls.Add(this.lOriginalCount);
            this.groupBox2.Controls.Add(this.lRemadeCount);
            this.groupBox2.Controls.Add(this.lbRemadeImages);
            this.groupBox2.Location = new System.Drawing.Point(421, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(578, 410);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0001.png");
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(119, 28);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Colunms";
            // 
            // SplitImageSeriesMainFormVersie2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1010, 433);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbxSaveFiles);
            this.Controls.Add(this.grpbxOpenFiles);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SplitImageSeriesMainFormVersie2";
            this.Text = "Split & Merge";
            this.grpbxOpenFiles.ResumeLayout(false);
            this.grpbxOpenFiles.PerformLayout();
            this.grpbxSaveFiles.ResumeLayout(false);
            this.grpbxSaveFiles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwFileCheck;
        private System.Windows.Forms.ListBox lbRemadeImages;
        private System.Windows.Forms.ListBox lbOriginalImages;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.GroupBox grpbxOpenFiles;
        private System.Windows.Forms.Button btOpenFiles;
        private System.Windows.Forms.Label lOpenFileLocation;
        private System.Windows.Forms.Button btCancelFileCheck;
        private System.Windows.Forms.ProgressBar pgbCheckImageDimensions;
        private System.Windows.Forms.Label lProgressFileCheck;
        private System.Windows.Forms.GroupBox grpbxSaveFiles;
        private System.Windows.Forms.Button btSaveFiles;
        private System.Windows.Forms.Label lSaveFileLocation;
        private System.Windows.Forms.Label lOriginalCount;
        private System.Windows.Forms.Label lRemadeCount;
        private System.Windows.Forms.ProgressBar pgbSplitProgress;
        private System.Windows.Forms.Label lPercentageDone;
        private System.Windows.Forms.Label lTotalProgress;
        private System.Windows.Forms.ProgressBar pgbTotalProgress;
        private System.Windows.Forms.Label lRuntime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

