using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Hardware.CPU;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace GPUTemperatureMonitor
{
    public partial class HomeScreen : Form
    {
        #region Properties

        private static int _currentGpuTemp = 0;
        private static bool _tempFound = false;

        private static readonly int MinimumTempAlert = 75;
        private static readonly int CriticalTemp = 95;
        private static readonly int WarningTemp = 85;

        /// <summary>
        /// This controls the 
        /// </summary>
        public static bool TempFound
        {
            get { return _tempFound; }
            set { _tempFound = value; }
        }

        /// <summary>
        /// The up-to-date Graphics Card temperature
        /// </summary>
        public static int CurrentGpuTemp
        {
            get { return _currentGpuTemp; }
            set { _currentGpuTemp = value; }
        }

        #endregion

        public HomeScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load event handler to initialize the GPU temperature monitoring
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            // try to start monitoring the GPU temperature when the form loads
            // and handle any exceptions that may occur.
            try
            {
                toolStripStatusLabel1.Text = "Monitoring GPU Temperature...";

                // Kicks off the asynchronous method to start monitoring the GPU temperature
                // on form load and updates the label accordingly.
                bool a = await StartMonitoring();


            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error: " + ex.Message;
                MessageBox.Show("An error occurred while starting the GPU temperature monitor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Continuously monitor the GPU temperature and update the label on the form.
        /// </summary>
        /// <returns></returns>        
        public async Task<bool> StartMonitoring()
        {
            Computer comp = new Computer();
            comp.Open();
            comp.CPUEnabled = false;
            comp.GPUEnabled = true;

            await Task.Run(async () =>
            {
                while (true)
                {
                    _currentGpuTemp = Convert.ToInt32(await Classes.GpuMonitorServices.GetGpuTempAsync());

                    this.Invoke((MethodInvoker)(() =>
                    {
                        gpuTempLabel.Text = _currentGpuTemp.ToString() + "°C";

                        if (_currentGpuTemp >= CriticalTemp)
                        {
                            gpuTempLabel.ForeColor = Color.Red;
                            toolStripStatusLabel1.Text = "🔥 Critical GPU Temperature!";
                        }
                        else if (_currentGpuTemp >= WarningTemp)
                        {
                            gpuTempLabel.ForeColor = Color.Orange;
                            toolStripStatusLabel1.Text = "⚠️ High GPU Temperature";
                        }
                        else
                        {
                            gpuTempLabel.ForeColor = Color.Green;
                            toolStripStatusLabel1.Text = "GPU Temperature is normal.";
                        }

                    }));

                    

                    await Task.Delay(1000); // non-blocking delay
                }
            });

            return false;
        }
    }
}
