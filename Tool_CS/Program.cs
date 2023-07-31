using Microsoft.Win32;
using System.Diagnostics;

var key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\DWMFRAMEINTERVAL", true);
if (key == null)
{
    key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations");
    key.SetValue("DWMFRAMEINTERVAL", 15);
    return;
}
key.Close();
Registry.LocalMachine.DeleteSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\DWMFRAMEINTERVAL");
Process.Start("shutdown.exe", "-r -t 0");