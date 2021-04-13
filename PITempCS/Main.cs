using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
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
        private static StringBuilder data;
        private static StringBuilder data1;
        private static StringBuilder data2;
        private static StringBuilder data3;
        private static StringBuilder data4;
        private static StringBuilder data5;
        private static StringBuilder data6;
        private static StringBuilder data7;
        private static StringBuilder data8;
        private static StringBuilder data9;
        private static StringBuilder data10;
        private static StringBuilder data11;

        private static int z;
        private static int spd;
        private static int t;
        private static int bc;
        private static int mr;
        private static int er;
        private static int bp;
        private static int sap;
        private static int am;

        private static int dooropn;
        private static int doorcls;

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
            z = (int)st.Z;
            spd = (int)st.V;
            t = st.T;
            bc = (int)st.BC;
            mr = (int)st.MR;
            er = (int)st.ER;
            bp = (int)st.BP;
            sap = (int)st.SAP;
            am = (int)st.I;

            if (myPort == null)
            {
                return;
            }


            writePort();

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
            dooropn = 1;
            doorcls = 0;

        }
        static internal void DoorClose()
        {

            dooropn = 0;
            doorcls = 1;
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
            string iniFileName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/ATSPISerial.ini";
            uint ret = GetPrivateProfileString("Data", "COM", "none", COMnumber, Convert.ToUInt32(COMnumber.Capacity), iniFileName);

            //パスの読み取りに成功しました

        }

        

        static internal void writePort()
        {
            try
            {
                //! 受信データを読み込む.
                string readdata = myPort.ReadTo("\n");

                if (readdata == "aa")
                {
                    data1 = new StringBuilder();
                    data1.Append("aa");
                    data1.Append(z.ToString());
                    data1.Append('\n');

                    try
                    {
                        myPort.Write(data1.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "ab")
                {
                    data2 = new StringBuilder();
                    data2.Append("ab");
                    data2.Append(spd.ToString());
                    data2.Append('\n');

                    try
                    {
                        myPort.Write(data2.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "ac")
                {
                    data3 = new StringBuilder();
                    data3.Append("ac");
                    data3.Append(t.ToString());
                    data3.Append('\n');

                    try
                    {
                        myPort.Write(data3.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "ad")
                {
                    data4 = new StringBuilder();
                    data4.Append("ad");
                    data4.Append(bc.ToString());
                    data4.Append('\n');

                    try
                    {
                        myPort.Write(data4.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "ae")
                {
                    data5 = new StringBuilder();
                    data5.Append("ae");
                    data5.Append(mr.ToString());
                    data5.Append('\n');

                    try
                    {
                        myPort.Write(data5.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "af")
                {
                    data6 = new StringBuilder();
                    data6.Append("af");
                    data6.Append(er.ToString());
                    data6.Append('\n');

                    try
                    {
                        myPort.Write(data6.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "ag")
                {
                    data7 = new StringBuilder();
                    data7.Append("ag");
                    data7.Append(bp.ToString());
                    data7.Append('\n');

                    try
                    {
                        myPort.Write(data7.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "ah")
                {
                    data8 = new StringBuilder();
                    data8.Append("ah");
                    data8.Append(sap.ToString());
                    data8.Append('\n');

                    try
                    {
                        myPort.Write(data8.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "ai")
                {
                    data9 = new StringBuilder();
                    data9.Append("ai");
                    data9.Append(am.ToString());
                    data9.Append('\n');

                    try
                    {
                        myPort.Write(data9.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }

                //ドア状態

                if (readdata == "ba")
                {
                    data10 = new StringBuilder();
                    data10.Append("ba");
                    data10.Append(dooropn.ToString());
                    data10.Append('\n');

                    try
                    {
                        myPort.Write(data10.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }
                if (readdata == "bb")
                {
                    data11 = new StringBuilder();
                    data11.Append("bb");
                    data11.Append(doorcls.ToString());
                    data11.Append('\n');

                    try
                    {
                        myPort.Write(data11.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATSPISerial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClosePort();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        static internal void OpenPort()
        {
            try
            {
                myPort = new SerialPort("COM" + COMnumber.ToString(), 19200, Parity.None, 8, StopBits.One);
                //やっと動くようになった
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
