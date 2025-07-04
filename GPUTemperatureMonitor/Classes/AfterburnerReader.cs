using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class AfterburnerReader
{
    private const string SharedMemoryName = "Global\\Access_MSI_Afterburner_SharedMemory";

    [StructLayout(LayoutKind.Sequential)]
    private struct GpuEntry
    {
        public int Index;
        public int Temperature;
        public int FanSpeedRPM;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct SharedMemoryHeader
    {
        public uint Signature;
        public uint Version;
        public uint GpuEntryCount;
        public uint GpuEntrySize;
    }

    public void ReadGpuTelemetry()
    {
        try
        {
            var mmf = MemoryMappedFile.OpenExisting(SharedMemoryName, MemoryMappedFileRights.Read);
            var accessor = mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read);

            SharedMemoryHeader header;
            accessor.Read(0, out header);

            long offset = Marshal.SizeOf<SharedMemoryHeader>();

            for (int i = 0; i < header.GpuEntryCount; i++)
            {
                GpuEntry entry;
                accessor.Read(offset, out entry);

                //Console.WriteLine($"GPU {entry.Index}: Temp = {entry.Temperature}°C, Fan = {entry.FanSpeedRPM} RPM");
                MessageBox.Show($"GPU {entry.Index}: Temp = {entry.Temperature}°C, Fan = {entry.FanSpeedRPM} RPM");

                offset += header.GpuEntrySize;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading Afterburner shared memory: {ex.Message}");
        }
    }
}
