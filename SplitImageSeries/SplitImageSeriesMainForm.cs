using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SplitImageSeries
{
    public partial class SplitImageSeriesMainFormVersie2 : Form
    {
        // Variables
        private bool _cancelled = false;
        private bool _areFilesOpened = false;
        private bool _areFilesSaved = false;
        private bool _error = false;
        private string _saveFileLocation;
        private string[] _imagesToCheck;
        private List<byte[]> _imageArray = new List<byte[]>();
        ManualResetEvent eventx = new ManualResetEvent(false);

        private  List<Bitmap>[] bmp = new List<Bitmap>[1024];
        private Thread[] thread = new Thread[32];
        private Thread[] MergeThread = new Thread[32];
        private Thread[] Pool;


        // Instances of Classes
        Stopwatch sw = new Stopwatch();

        // Delegates
        public delegate void UpdateGraphics(bool check, string filename);
        public UpdateGraphics UpdateDelegate;


        //--------------------------------------------------------------------------------------------
        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();
  
        //SetThreadAffinityMask 指定hThread 运行在 核心 dwThreadAffinityMask
        [DllImport("kernel32.dll")]
        static extern UIntPtr SetThreadAffinityMask(IntPtr hThread,
                             UIntPtr dwThreadAffinityMask);
 
        //得到当前线程的handler
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentThread();

         static ulong SetCpuID(long id)
         {
             ulong cpuid = 0;
             if (id < 0 || id >= System.Environment.ProcessorCount)
             {
                 id = 0;
             }
             cpuid |= 1UL << (int)id;
             return cpuid;
         }
        //-------------------------------------------------------------------------------------------------

        public SplitImageSeriesMainFormVersie2()
        {
            InitializeComponent();

            UpdateDelegate = new UpdateGraphics(UpdateGUI);
            // Change Graphic Properties
            bSubmit.Enabled = false;
            btCancelFileCheck.Enabled = false;
            lRuntime.Text = string.Format("Runtime Elapsed: {0}", sw.Elapsed.ToString(@"hh\:mm\:ss"));

            if (radioButton1.Checked && !radioButton2.Checked)
            {
                Pool = new Thread[16];
            }
            else if (!radioButton1.Checked && radioButton2.Checked)
            {
                Pool = new Thread[32];
            }
        }



        private void btOpenFiles_Click(object sender, EventArgs e)
        {
            // If the worker is busy, and the user uploads new files, the old files will be overwritten.
            // Throw warning because it's proper to do so.
            if (bgwFileCheck.IsBusy)
            {
                if (MessageBox.Show("Opening new files will cause the program to stop checking the previous file. \r\n Do you wish to proceed?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    bgwFileCheck.CancelAsync();
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ResetOpen(ofd);
                // Start the worker
                bgwFileCheck.RunWorkerAsync();
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            e.Result = CheckDimensions(worker, e);
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbCheckImageDimensions.Value = (int)((object[])e.UserState)[0];
            lbOriginalImages.Items.Add(Path.GetFileName((string)((object[])e.UserState)[1]));
            lbOriginalImages.SelectedIndex = lbOriginalImages.Items.Count - 1;
            lProgressFileCheck.Text = "Checking image " + pgbCheckImageDimensions.Value + " of " + pgbCheckImageDimensions.Maximum;
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else
                if (_error)
                {
                    MessageBox.Show(e.Result.ToString());
                    lProgressFileCheck.Text = e.Result.ToString();
                }
                else if (_cancelled)
                {
                    lProgressFileCheck.Text = e.Result.ToString();
                }
                else
                {
                    lProgressFileCheck.Text = e.Result.ToString();
                    btCancelFileCheck.Enabled = false;
                    _areFilesOpened = true;
                    if (_areFilesOpened && _areFilesSaved)
                    {
                        bSubmit.Enabled = true;
                    }
                }
            lOriginalCount.Text = string.Format("There are {0} images", lbOriginalImages.Items.Count.ToString());
            lOriginalCount.Visible = true;
        }

        private string CheckDimensions(BackgroundWorker worker, DoWorkEventArgs e)
        {
            int count = 0;
            string result = "";
            Image originalImage = Image.FromFile(_imagesToCheck[0]);
            foreach (string fileName in _imagesToCheck)
            {
                Image file = Image.FromFile(fileName);
                if (originalImage.Height != file.Height)
                {
                    result += "Error: Image " + fileName + " Height (" + file.Size.ToString() + ") is not the same as " + originalImage.Size.ToString();
                    _error = true;
                    break;
                }
                else if (originalImage.Width != file.Width)
                {
                    result += "Error: Image " + fileName + " Width (" + file.Size.ToString() + ") is not the same as " + originalImage.Size.ToString();
                    _error = true;
                    break;
                }
                else
                {
                    _imageArray.Add(ConvertImageByteArray.ImageToByteArray(fileName));
                    result = "Done";
                }
                count++;
                int percentageCompleted = (int)(count / _imagesToCheck.Length);
                worker.ReportProgress(percentageCompleted, new object[] { count, fileName });
                file.Dispose();
                if (worker.CancellationPending)
                    break;
            }
            if (_cancelled)
            {
                result = "Cancelled";
            }
            originalImage.Dispose();
            return result;
        }

        private void btSaveFiles_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Set some Variables
                _saveFileLocation = Path.GetDirectoryName(sfd.FileName) + "\\" + Path.GetFileNameWithoutExtension(sfd.FileName) + "_{0}" + Path.GetExtension(sfd.FileName);
                
                // Change Graphic Properties
                lSaveFileLocation.Visible = true;
                _areFilesSaved = true;
                lSaveFileLocation.Text = "File location: " + Path.GetFullPath(sfd.FileName);

                // Only allow the images to be split and merged if 
                // 1) There's a place they come from (Opened files)
                // 2) There's a place where they can go (Save file location)
                if (_areFilesOpened && _areFilesSaved)
                {
                    bSubmit.Enabled = true;
                }
            }
        }

        private void btCancelFileCheck_Click(object sender, EventArgs e)
        {
            bgwFileCheck.CancelAsync();
            btCancelFileCheck.Enabled = false;
            _cancelled = true;
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            int NumOfCol = Convert.ToInt32(this.numericUpDown1.Value);
            if (lbOriginalImages.Items.Count > 0)
            {
                ResetSubmit();
                int threadNum = 0;
                if (radioButton1.Checked && !radioButton2.Checked)
                {
                    threadNum = 16;
                }
                else if (!radioButton1.Checked && radioButton2.Checked)
                {
                    threadNum = 32;
                }
                // start all threads
                for (int o = 0; o < threadNum; o++)
                {
                    object[] stuff = new object[] { o, NumOfCol - 1};
                    Pool[o] = new Thread(ProcessImages);
                    Pool[o].Start(stuff);
                }
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
                this.numericUpDown1.Enabled = false;
            }
        }

        private void ResetOpen(OpenFileDialog ofd)
        {
            // Change Graphic Properties
            lbOriginalImages.Items.Clear();
            lOriginalCount.Visible = false;
            lOpenFileLocation.Visible = true;
            lProgressFileCheck.Visible = true;
            lRuntime.Visible = false;
            lPercentageDone.Visible = false;
            lTotalProgress.Visible = false;
            btCancelFileCheck.Enabled = true;
            bSubmit.Enabled = false;
            pgbCheckImageDimensions.Value = 0;
            pgbCheckImageDimensions.Maximum = ofd.FileNames.Length;
            lOpenFileLocation.Text = Path.GetDirectoryName(ofd.FileName);

            // Set some Variables
            _cancelled = false;
            _imagesToCheck = ofd.FileNames;

            lbRemadeImages.Items.Clear();
            pgbSplitProgress.Value = 0;
            pgbTotalProgress.Value = 0;

            if (_imageArray.Count != 0)
                _imageArray.Clear();
        }
        private void ResetSubmit()
        {
            // Start the Stopwatch
            sw.Reset();
            sw.Start();
            // Change Graphic Properties
            lbRemadeImages.Items.Clear();
            lRuntime.Visible = true;
            lPercentageDone.Visible = true;
            lTotalProgress.Visible = true;
            btOpenFiles.Enabled = false;
            btSaveFiles.Enabled = false;
            bSubmit.Enabled = false;
            lTotalProgress.Text = string.Empty;
            lPercentageDone.Text = string.Empty;

            pgbTotalProgress.Value = 0;
            pgbTotalProgress.Maximum = 1024;
            pgbSplitProgress.Maximum = 1048576;

            // Set some Variables
            _error = false;
        }


        private void ProcessImages(object stateObj)
        {
            object[] state = (object[])stateObj;
            //SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID((int)state[0])));

            //if ((int)state[0] == 0 || (int)state[0] == 1)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(0)));
            //}
            //else if ((int)state[0] == 2 || (int)state[0] == 3)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(1)));
            //}
            //else if ((int)state[0] == 4 || (int)state[0] == 5)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(2)));
            //}
            //else if ((int)state[0] == 6 || (int)state[0] == 7)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(3)));
            //}
            //else if ((int)state[0] == 8 || (int)state[0] == 9)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(4)));
            //}
            //else if ((int)state[0] == 10 || (int)state[0] == 11)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(5)));
            //}
            //else if ((int)state[0] == 12 || (int)state[0] == 13)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(6)));
            //}
            //else if ((int)state[0] == 14 || (int)state[0] == 15)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(7)));
            //}
            //else if ((int)state[0] == 16 || (int)state[0] == 17)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(8)));
            //}
            //else if ((int)state[0] == 18 || (int)state[0] == 19)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(9)));
            //}
            //else if ((int)state[0] == 20 || (int)state[0] == 21)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(10)));
            //}
            //else if ((int)state[0] == 22 || (int)state[0] == 23)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(11)));
            //}
            //else if ((int)state[0] == 24 || (int)state[0] == 25)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(12)));
            //}
            //else if ((int)state[0] == 26 || (int)state[0] == 27)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(13)));
            //}
            //else if ((int)state[0] == 28 || (int)state[0] == 29)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(14)));
            //}
            //else if ((int)state[0] == 30 || (int)state[0] == 31)
            //{
            //    SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(15)));
            //}

            int taskNum = 0;
            if (radioButton1.Checked && !radioButton2.Checked)
            {
                taskNum = 64;
            }
            else if (!radioButton1.Checked && radioButton2.Checked)
            {
                taskNum = 32;
            }

            for (int i = (int)state[0] * taskNum; i <= (int)state[0] * taskNum + taskNum - 1; i++)
            {
                bmp[i] = new List<Bitmap>();
                //set a base image for merging
                Image img = ConvertImageByteArray.ByteArrayToImage(_imageArray[0]);
                for (int startPoint = 0; startPoint < (int)state[1]; startPoint++)
                {
                    //store columns in list
                    bmp[i].Add(SplitMerge.Split(_imageArray[startPoint], i));
                    //Update interface lable.text
                    try { this.Invoke(UpdateDelegate, new object[] { true, string.Empty }); }
                    catch { }
                }
                // merge , bmp[i] will be the base and will be cleaned
                SplitMerge.Merge(bmp[i],img).Save(string.Format(_saveFileLocation, i));
                //Update interface lable.text
                try { this.Invoke(UpdateDelegate, new object[] { false, string.Format(_saveFileLocation, i) }); }
                catch { }
                // clear list to release memory
                bmp[i] = null;
            }
        }

        private void UpdateGUI(bool check, string fileName)
        {
            try
            {
                if (check)
                {
                    pgbSplitProgress.Value+= 1;
                    lPercentageDone.Text = string.Format("Processed image {0} of {1}", pgbSplitProgress.Value, pgbSplitProgress.Maximum);
                }
                else
                {
                    pgbTotalProgress.Value+= 1;
                    lbRemadeImages.Items.Add(fileName);
                    lTotalProgress.Text = "Processed image " + pgbTotalProgress.Value + " of " + _imagesToCheck.Length;
                    Graphics gr = this.CreateGraphics();
                    //if (_currentWidth < (int)gr.MeasureString(fileName, this.Font).Width + 15)
                    //    _currentWidth = (int)gr.MeasureString(fileName, this.Font).Width + 15;
                    //lbRemadeImages.Width = _currentWidth;
                    lbRemadeImages.SelectedIndex = lbRemadeImages.Items.Count - 1;
                    if (pgbTotalProgress.Value == pgbTotalProgress.Maximum)
                    {
                        btOpenFiles.Enabled = true;
                        btSaveFiles.Enabled = true;
                    }
                }
                lRuntime.Text = string.Format("Runtime Elapsed: {0}", sw.Elapsed.ToString(@"hh\:mm\:ss"));
            }
            catch (Exception)
            {
            }
        }
    }
}
