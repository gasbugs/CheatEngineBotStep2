using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics; // 시스템 진단
using ProcessMemoryReaderLib;

namespace CheatEngineBotStep2
{
    public partial class Form1 : Form
    {

        Process[] MyProcess;
        ProcessMemoryReader mem = new ProcessMemoryReader();
        bool attach = false;
        bool healthHack = false;
        bool ammoHack = false;


        static PointerDataStruct step2DataAddr = new PointerDataStruct(0x480); // step2 value, hp  
        static int[] step2array = { 0x0 };
        PointerData step2Data = new PointerData(0x5FD5D0, step2array, step2DataAddr);

        static PointerDataStruct step8DataAddr = new PointerDataStruct(0x0); // step8 value, hp  
        static int[] step8array = { 0xC, 0x14, 0x0, 0x18};
        PointerData step8Data = new PointerData(0x5FD660, step8array, step8DataAddr);

        static Step9PlayerData step9PlayerData = new Step9PlayerData(); // 데이터 초기화는 내부에서 알아서
        

        public Form1()
        {
            InitializeComponent();
        }

        private void CloseBT_Click(object sender, EventArgs e) // 닫기 버튼
        {
            DialogResult result;
            result = MessageBox.Show("종료하시겠습니까?", "종료 메시지", 
                                        MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.Abort;
                Application.Exit();
            }
        }

        // 클릭했을 때 프로세스 리스트를 검색
        private void ProcessChoiceCB_Click(object sender, EventArgs e)
        {
            ProcessChoiceCB.Items.Clear(); // 기존 프로세스 목록 초기화
            MyProcess = Process.GetProcesses(); // 프로세스 목록 불어오기

            for (int i = 0; i < MyProcess.Length; i++) // 프로세스 목록 하나씩 items에 추가
            {
                //여기에 작성되는 내용이 총 MyProcess.Length번 진행됩니다.
                string text = MyProcess[i].ProcessName + "-" + MyProcess[i].Id;
                ProcessChoiceCB.Items.Add(text);
            }
        }
    
        // 리스트 중에 선택한 그 프로세스로 어태치
        private void ProcessChoiceCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try // 시도!
            {
                if(ProcessChoiceCB.SelectedIndex != -1) // 인덱스가 선택됐다면
                {
                    string selectedItem = ProcessChoiceCB.SelectedItem.ToString(); // MsMpEng.exe-3444
                    int pid = int.Parse(selectedItem.Split('-')[selectedItem.Split('-').Length - 1]);
                    Process attachProc = Process.GetProcessById(pid);

                    
                    mem.ReadProcess = attachProc;
                    mem.OpenProcess();

                    attach = true;
                    MessageBox.Show("프로세스 권한 획득! " + attachProc.ProcessName);
                }
            }
            catch(Exception ex) // 시도했으나 에러발생
            {
                attach = false;
                MessageBox.Show("프로세스 어태치에 실패했습니다. " + ex.Message);
            }
        }

        private void LoopTMR_Tick(object sender, EventArgs e)
        {
            if (attach)
            {
                try
                {
                    // Step2 Value를 찾아서 모니터링 (현재 값이 무엇인지 계속적으로 확인)
                    int step2SturctAddress = mem.ReadMultiLevelPointer(step2Data.baseAddress, 4, step2Data.multiLevel);
                    int step2value = mem.ReadInt(step2SturctAddress + step2Data.offsets.health);
                    Step2ValueLBL.Text = "Step 2 Value: " + step2value;

                    // Step8 Value를 찾아서 모니터링
                    int step8SturctAddress = mem.ReadMultiLevelPointer(step8Data.baseAddress, 4, step8Data.multiLevel);
                    int step8value = mem.ReadInt(step8SturctAddress + step8Data.offsets.health);
                    Step8ValueLBL.Text = "Step 8 Value: " + step8value;

                    // Step9의 플레이어 데이터를 모니터링
                    int p1Base = mem.ReadMultiLevelPointer(step9PlayerData.baseAddress, 4, step9PlayerData.step9P1multiLevel);
                    int p2Base = mem.ReadMultiLevelPointer(step9PlayerData.baseAddress, 4, step9PlayerData.step9P2multiLevel);
                    int p3Base = mem.ReadMultiLevelPointer(step9PlayerData.baseAddress, 4, step9PlayerData.step9P3multiLevel);
                    int p4Base = mem.ReadMultiLevelPointer(step9PlayerData.baseAddress, 4, step9PlayerData.step9P4multiLevel);

                    P1LBL.Text = "P1: [" + mem.ReadInt(p1Base + step9PlayerData.teamOffset) +" 팀]" + mem.ReadString(p1Base + step9PlayerData.nameOffset) + ": " + mem.ReadFloat(p1Base + step9PlayerData.healthOffset);
                    P2LBL.Text = "P2: [" + mem.ReadInt(p2Base + step9PlayerData.teamOffset) + " 팀]" + mem.ReadString(p2Base + step9PlayerData.nameOffset) + ": " + mem.ReadFloat(p2Base + step9PlayerData.healthOffset);
                    P3LBL.Text = "P3: [" + mem.ReadInt(p3Base + step9PlayerData.teamOffset) + " 팀]" + mem.ReadString(p3Base + step9PlayerData.nameOffset) + ": " + mem.ReadFloat(p3Base + step9PlayerData.healthOffset);
                    P4LBL.Text = "P4: [" + mem.ReadInt(p4Base + step9PlayerData.teamOffset) + " 팀]" + mem.ReadString(p4Base + step9PlayerData.nameOffset) + ": " + mem.ReadFloat(p4Base + step9PlayerData.healthOffset);
                    
                    // 크랙을 동작시켰을때, 현재 크랙이 값을 수정하도록 만드는 작업
                    int hotkey = ProcessMemoryReaderApi.GetKeyState(0x02); // 마우스 오른쪽키에 대한 상태
                    if ((hotkey & 0x8000)!= 0) // 키가 눌렸을 경우
                    {
                        if (crackState == false) // 크랙이 꺼져있는 경우에는 크랙 켜고 크랙 시도!
                        {
                            crackState = true;
                            CrackStatusLBL.Text = "크랙 상태: On";
                        }
                        else // 크랙이 켜져있는 경우에는 크랙을 끕니다.
                        {
                            crackState = false;
                            CrackStatusLBL.Text = "크랙 상태: Off";
                        }
                    }
                    if (crackState)
                    {
                        Step2Solve(step2SturctAddress); // step2 Value를 1000으로 수정
                        Step8Solve(step8SturctAddress); // step2 Value를 1000으로 수정
                    }
                        


                }
                catch (Exception ex)
                {
                    crackState = false;
                    MessageBox.Show("읽기 쓰기 오류: " + ex.Message);
                }
            }
        }

        private void Step8Solve(int step8SturctAddress)
        {
            mem.WriteInt(step8SturctAddress + step8Data.offsets.health, 5000);
        }

        private void Step2Solve(int step2SturctAddress)
        {
            mem.WriteInt(step2SturctAddress + step2Data.offsets.health, 1000);
        }
        
    }
}
