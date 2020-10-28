using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO.Ports;
using System.Runtime.InteropServices;


namespace PITempCS
{

    /// <summary>メインの機能をここに実装する。</summary>
    public class Main
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);


        private static SerialPort myPort = null;
        private static StringBuilder COMnumber;

        static internal void Load()
        {
            Openini();
            OpenPort();

            if (myPort != null)
            {
                try
                {
                    myPort.Write(new byte[] { 0 }, 0, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        static internal void Dispose()
        {
            ClosePort();

        }

        static internal void GetVehicleSpec(Spec s)
        {

        }

        static internal void Initialize(int s)
        {

        }
        static unsafe internal void Elapse(State st, int* Pa, int* Sa)
        {
            int z = (int)st.Z;
            int spd = (int)st.V;
            int t = st.T;
            int bc = (int)st.BC;
            int mr = (int)st.MR;
            int er = (int)st.ER;
            int bp = (int)st.BP;
            int sap = (int)st.SAP;
            int am = (int)st.I;
            if (myPort == null)
            {
                return;
            }
            try
            {
                String data;
                String data1 = "aa" + z.ToString() + '\n';
                String data2 = "ab" + spd.ToString() + '\n';
                String data3 = "ac" + t.ToString() + '\n';
                String data4 = "ad" + bc.ToString() + '\n';
                String data5 = "ae" + mr.ToString() + '\n';
                String data6 = "af" + er.ToString() + '\n';
                String data7 = "ag" + bp.ToString() + '\n';
                String data8 = "ah" + sap.ToString() + '\n';
                String data9 = "ai" + am.ToString() + '\n';
                data = data1 + data2 + data3 + data4 + data5 + data6 + data7+ data8 + data9;
                //これ重たいからどうにかしないといけない

                //! シリアルポートからテキストを送信する.
                myPort.Write(data);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        static internal void SetPower(int p)
        {

        }

        static internal void SetBrake(int b)
        {

        }

        static internal void SetReverser(int r)
        {

        }
        static internal void KeyDown(int k)
        {

        }

        static internal void KeyUp(int k)
        {

        }

        static internal void DoorOpen()
        {

        }
        static internal void DoorClose()
        {

        }
        static internal void HornBlow(int h)
        {

        }
        static internal void SetSignal(int s)
        {

        }
        static internal void SetBeaconData(Beacon b)
        {

        }

        static internal void Openini()
        {

            int capacitySize = 256;

            COMnumber = new StringBuilder(capacitySize);
            string iniFileName = AppDomain.CurrentDomain.BaseDirectory + "ATSPISerial.ini";
            uint ret = GetPrivateProfileString("Data", "COM", "none", COMnumber, Convert.ToUInt32(COMnumber.Capacity), iniFileName);

            //これだとiniの中身を読んでもらえません
            //設定データを読むやつ、初心者にはどの方法もよく分からなかった
            //読んでます
            //https://www.ipentec.com/document/csharp-read-ini-file-value
            //https://qiita.com/caf2for4/items/3078375bb8e79a5771b4

        }

        static internal void OpenPort()
        {
            try
            {
                //myPort = new SerialPort("COM" + COMnumber.ToString(), 19200, Parity.None, 8, StopBits.One);
                myPort = new SerialPort("COM6", 19200, Parity.None, 8, StopBits.One);
                //とりあえず固定値入れている
                myPort.Open();
                myPort.RtsEnable = true;
                myPort.DtrEnable = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ClosePort();
            }
        }

        static internal void ClosePort()
        {
            if (myPort != null)
            {
                try
                {
                    myPort.Close();
                }
                catch { }
                try
                {
                    myPort.Dispose();
                }
                catch { }
                myPort = null;
            }
        }
    }
}
