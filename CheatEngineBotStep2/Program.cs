using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // 시스템 진단
using System.Security.Principal; // 시스템 권한

namespace CheatEngineBotStep2
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsAdministrator() == false) // 관리자 권한으로 실행되지 않는 경우라면 ..
            {
                try
                {
                    ProcessStartInfo procInfo = new ProcessStartInfo();
                    procInfo.UseShellExecute = true;
                    procInfo.FileName = Application.ExecutablePath;
                    procInfo.WorkingDirectory = Environment.CurrentDirectory;
                    procInfo.Verb = "runas";
                    Process.Start(procInfo);
                }
                catch (Exception ex)
                {
                    // 사용자가 프로그램을 관리자 권한으로 실행하기를 원하지 않을 경우에 대한 처리
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            { // 처음부터 프로그램은 관리자 권한으로 실행되고 있는 경우라면 ..
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (identity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return false;
        }
    }

    // 우리가 다룰 구조체의 위치를 찾는데 필요한 정보
    public class PointerData // 하나의 포인터 사용했지만 다중 포인터로도 사용 가능합니다.
    {
        public int baseAddress; // 5FD5D0
        public int[] multiLevel; // 0x480, 0x5, ... 
        public PointerDataStruct offsets; // 해당 구조물에 들어있는 각종 변수를 분석하는... hp,mp,str,vit

        public PointerData(int _baseAddress, int[] _multiLevel, PointerDataStruct _offsets)
        {
            this.baseAddress = _baseAddress;
            this.multiLevel = _multiLevel;
            this.offsets = _offsets;
        }
    }

    // 구조체의 멤버에 대한 주소 정보를 전달
    public class PointerDataStruct
    {
        public int health; //위치정보 0x480
        //int mp; // 500

        public PointerDataStruct(int _health) // .... 
        {
            health = _health;
        }
    }


    public class Step9PlayerData // 하나의 포인터 사용했지만 다중 포인터로도 사용 가능합니다.
    {
        public int baseAddress; 
        public int healthOffset; // 해당 구조물에 들어있는 각종 변수를 분석하는... hp,mp,str,vit
        public int teamOffset;
        public int nameOffset;

        public int[] step9P1multiLevel = { 0x4CC, 0x0 };
        public int[] step9P2multiLevel = { 0x4D0, 0x0 };
        public int[] step9P3multiLevel = { 0x4D4, 0x0 };
        public int[] step9P4multiLevel = { 0x4D8, 0x0 };

        public Step9PlayerData()
        {
            baseAddress = 0x5fd670;
            healthOffset = 0x4;
            teamOffset = 0x10;
            nameOffset = 0x15;
        }

    }
}
