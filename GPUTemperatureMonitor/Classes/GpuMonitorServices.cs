using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GPUTemperatureMonitor.Classes
{
    public static class GpuMonitorServices
    {
        #region

        // OpenHardwareMonitor.Computer is used to access hardware information
        private static readonly Computer _computer;

        private static int _currentGpuTemp = 0;

        private static bool _tempFound = false;

        private static readonly int MinimumTempAlert = 75;

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

        /// <summary>
        /// Default constructor initializes the Computer object
        /// </summary>
        static GpuMonitorServices() 
        {
            _computer = new Computer
            {
                GPUEnabled = true,
                CPUEnabled = false
            };

            _computer.Open();
        }

        /// <summary>
        /// fGet the GPU fan RPM (Revolutions Per Minute)
        /// </summary>
        /// <returns></returns>
        public static int GetGpuFanRpm()
        {
            foreach (IHardware hardware in _computer.Hardware)
            {
                if (IsGpu(hardware))
                {
                    hardware.Update();
                    var fanSensor = hardware.Sensors
                        .FirstOrDefault(s => s.SensorType == SensorType.Fan);
                    return (int)(fanSensor?.Value ?? 0);
                }
            }

            return 0;
        }

        /// <summary>
        /// Get the GPU temperature
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetGpuTempAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    foreach (IHardware hardware in _computer.Hardware)
                    {
                        if (hardware.HardwareType == HardwareType.GpuNvidia || hardware.HardwareType == HardwareType.GpuAti)
                        {
                            hardware.Update();

                            var tempSensor = hardware.Sensors
                                .FirstOrDefault(x => x.SensorType == SensorType.Temperature);

                            _currentGpuTemp = (int)tempSensor?.Max.GetValueOrDefault();

                            if (tempSensor != null)
                            {
                                _tempFound = true;
                                return string.Format("{0}", _currentGpuTemp);
                            }
                            else
                            {
                                _tempFound = false;
                                return "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    _tempFound = false;
                    MessageBox.Show("An error occurred while retrieving GPU temperature: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Should not ever reach here unless no GPU is found, due to try-catch above
                return "This code should not have been reached! Form1.cs, Line 94";
            });
        }

        /// <summary>
        /// Boolean to check if the hardware is GPU
        /// </summary>
        /// <param name="hardware"></param>
        /// <returns></returns>
        private static bool IsGpu(IHardware hardware) =>
            hardware.HardwareType == HardwareType.GpuNvidia ||
            hardware.HardwareType == HardwareType.GpuAti;
        }
}

//using OpenHardwareMonitor.Hardware;
//using System.Linq;

//public class GpuMonitorService
//{
//    private Computer _computer;

//    public GpuMonitorService()
//    {
//        _computer = new Computer
//        {
//            GPUEnabled = true,
//            CPUEnabled = false
//        };
//        _computer.Open();
//    }

//    public int GetGpuTemperature()
//    {
//        foreach (IHardware hardware in _computer.Hardware)
//        {
//            if (IsGpu(hardware))
//            {
//                hardware.Update();
//                var tempSensor = hardware.Sensors
//                    .FirstOrDefault(s => s.SensorType == SensorType.Temperature);
//                return (int)(tempSensor?.Value ?? 0);
//            }
//        }

//        return 0;
//    }

//    public int GetGpuFanRpm()
//    {
//        foreach (IHardware hardware in _computer.Hardware)
//        {
//            if (IsGpu(hardware))
//            {
//                hardware.Update();
//                var fanSensor = hardware.Sensors
//                    .FirstOrDefault(s => s.SensorType == SensorType.Fan);
//                return (int)(fanSensor?.Value ?? 0);
//            }
//        }

//        return 0;
//    }

//    private bool IsGpu(IHardware hardware) =>
//        hardware.HardwareType == HardwareType.GpuNvidia ||
//        hardware.HardwareType == HardwareType.GpuAti;
//}
