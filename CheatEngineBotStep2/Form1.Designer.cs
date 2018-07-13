namespace CheatEngineBotStep2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TitleLBL = new System.Windows.Forms.Label();
            this.ProcessChoiceLBL = new System.Windows.Forms.Label();
            this.HelpLBL = new System.Windows.Forms.Label();
            this.Step2ValueLBL = new System.Windows.Forms.Label();
            this.CrackStatusLBL = new System.Windows.Forms.Label();
            this.ProcessChoiceCB = new System.Windows.Forms.ComboBox();
            this.CloseBT = new System.Windows.Forms.Button();
            this.LoopTMR = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Step8ValueLBL = new System.Windows.Forms.Label();
            this.Step9GB = new System.Windows.Forms.GroupBox();
            this.P1LBL = new System.Windows.Forms.Label();
            this.P2LBL = new System.Windows.Forms.Label();
            this.P4LBL = new System.Windows.Forms.Label();
            this.P3LBL = new System.Windows.Forms.Label();
            this.Step9GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLBL
            // 
            this.TitleLBL.AutoSize = true;
            this.TitleLBL.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TitleLBL.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.TitleLBL.Location = new System.Drawing.Point(27, 24);
            this.TitleLBL.Name = "TitleLBL";
            this.TitleLBL.Size = new System.Drawing.Size(278, 37);
            this.TitleLBL.TabIndex = 0;
            this.TitleLBL.Text = "치트엔진 튜토리얼 봇";
            // 
            // ProcessChoiceLBL
            // 
            this.ProcessChoiceLBL.AutoSize = true;
            this.ProcessChoiceLBL.Location = new System.Drawing.Point(25, 78);
            this.ProcessChoiceLBL.Name = "ProcessChoiceLBL";
            this.ProcessChoiceLBL.Size = new System.Drawing.Size(197, 12);
            this.ProcessChoiceLBL.TabIndex = 1;
            this.ProcessChoiceLBL.Text = "튜토리얼 프로그램을 선택해주세요!";
            // 
            // HelpLBL
            // 
            this.HelpLBL.AutoSize = true;
            this.HelpLBL.Location = new System.Drawing.Point(32, 274);
            this.HelpLBL.Name = "HelpLBL";
            this.HelpLBL.Size = new System.Drawing.Size(451, 12);
            this.HelpLBL.TabIndex = 1;
            this.HelpLBL.Text = "※ 마우스 오른쪽 키를 누르면 크랙의 활성화/비활성화 상태를 전환할 수 있습니다.";
            // 
            // Step2ValueLBL
            // 
            this.Step2ValueLBL.AutoSize = true;
            this.Step2ValueLBL.Location = new System.Drawing.Point(316, 106);
            this.Step2ValueLBL.Name = "Step2ValueLBL";
            this.Step2ValueLBL.Size = new System.Drawing.Size(84, 12);
            this.Step2ValueLBL.TabIndex = 1;
            this.Step2ValueLBL.Text = "Step 2 Value: ";
            // 
            // CrackStatusLBL
            // 
            this.CrackStatusLBL.AutoSize = true;
            this.CrackStatusLBL.Location = new System.Drawing.Point(323, 300);
            this.CrackStatusLBL.Name = "CrackStatusLBL";
            this.CrackStatusLBL.Size = new System.Drawing.Size(57, 12);
            this.CrackStatusLBL.TabIndex = 1;
            this.CrackStatusLBL.Text = "크랙상태:";
            // 
            // ProcessChoiceCB
            // 
            this.ProcessChoiceCB.FormattingEnabled = true;
            this.ProcessChoiceCB.Location = new System.Drawing.Point(29, 103);
            this.ProcessChoiceCB.Name = "ProcessChoiceCB";
            this.ProcessChoiceCB.Size = new System.Drawing.Size(262, 20);
            this.ProcessChoiceCB.TabIndex = 2;
            this.ProcessChoiceCB.Text = "프로세스 선택";
            this.ProcessChoiceCB.SelectedIndexChanged += new System.EventHandler(this.ProcessChoiceCB_SelectedIndexChanged);
            this.ProcessChoiceCB.Click += new System.EventHandler(this.ProcessChoiceCB_Click);
            // 
            // CloseBT
            // 
            this.CloseBT.Location = new System.Drawing.Point(524, 312);
            this.CloseBT.Name = "CloseBT";
            this.CloseBT.Size = new System.Drawing.Size(95, 37);
            this.CloseBT.TabIndex = 3;
            this.CloseBT.Text = "닫기";
            this.CloseBT.UseVisualStyleBackColor = true;
            this.CloseBT.Click += new System.EventHandler(this.CloseBT_Click);
            // 
            // LoopTMR
            // 
            this.LoopTMR.Enabled = true;
            this.LoopTMR.Tick += new System.EventHandler(this.LoopTMR_Tick);
            // 
            // Step8ValueLBL
            // 
            this.Step8ValueLBL.AutoSize = true;
            this.Step8ValueLBL.Location = new System.Drawing.Point(316, 127);
            this.Step8ValueLBL.Name = "Step8ValueLBL";
            this.Step8ValueLBL.Size = new System.Drawing.Size(80, 12);
            this.Step8ValueLBL.TabIndex = 4;
            this.Step8ValueLBL.Text = "Step 8 Value:";
            // 
            // Step9GB
            // 
            this.Step9GB.Controls.Add(this.P3LBL);
            this.Step9GB.Controls.Add(this.P4LBL);
            this.Step9GB.Controls.Add(this.P2LBL);
            this.Step9GB.Controls.Add(this.P1LBL);
            this.Step9GB.Location = new System.Drawing.Point(290, 161);
            this.Step9GB.Name = "Step9GB";
            this.Step9GB.Size = new System.Drawing.Size(345, 85);
            this.Step9GB.TabIndex = 5;
            this.Step9GB.TabStop = false;
            this.Step9GB.Text = "Step9";
            // 
            // P1LBL
            // 
            this.P1LBL.AutoSize = true;
            this.P1LBL.Location = new System.Drawing.Point(26, 27);
            this.P1LBL.Name = "P1LBL";
            this.P1LBL.Size = new System.Drawing.Size(19, 12);
            this.P1LBL.TabIndex = 0;
            this.P1LBL.Text = "P1";
            // 
            // P2LBL
            // 
            this.P2LBL.AutoSize = true;
            this.P2LBL.Location = new System.Drawing.Point(26, 53);
            this.P2LBL.Name = "P2LBL";
            this.P2LBL.Size = new System.Drawing.Size(19, 12);
            this.P2LBL.TabIndex = 0;
            this.P2LBL.Text = "P2";
            // 
            // P4LBL
            // 
            this.P4LBL.AutoSize = true;
            this.P4LBL.Location = new System.Drawing.Point(175, 53);
            this.P4LBL.Name = "P4LBL";
            this.P4LBL.Size = new System.Drawing.Size(19, 12);
            this.P4LBL.TabIndex = 0;
            this.P4LBL.Text = "P4";
            // 
            // P3LBL
            // 
            this.P3LBL.AutoSize = true;
            this.P3LBL.Location = new System.Drawing.Point(175, 27);
            this.P3LBL.Name = "P3LBL";
            this.P3LBL.Size = new System.Drawing.Size(19, 12);
            this.P3LBL.TabIndex = 0;
            this.P3LBL.Text = "P3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 354);
            this.Controls.Add(this.Step9GB);
            this.Controls.Add(this.Step8ValueLBL);
            this.Controls.Add(this.CloseBT);
            this.Controls.Add(this.ProcessChoiceCB);
            this.Controls.Add(this.CrackStatusLBL);
            this.Controls.Add(this.Step2ValueLBL);
            this.Controls.Add(this.HelpLBL);
            this.Controls.Add(this.ProcessChoiceLBL);
            this.Controls.Add(this.TitleLBL);
            this.Name = "Form1";
            this.Text = "치트엔진 튜토리얼 봇";
            this.Step9GB.ResumeLayout(false);
            this.Step9GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLBL;
        private System.Windows.Forms.Label ProcessChoiceLBL;
        private System.Windows.Forms.Label HelpLBL;
        private System.Windows.Forms.Label Step2ValueLBL;
        private System.Windows.Forms.Label CrackStatusLBL;
        private System.Windows.Forms.ComboBox ProcessChoiceCB;
        private System.Windows.Forms.Button CloseBT;
        private System.Windows.Forms.Timer LoopTMR;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Step8ValueLBL;
        private System.Windows.Forms.GroupBox Step9GB;
        private System.Windows.Forms.Label P3LBL;
        private System.Windows.Forms.Label P4LBL;
        private System.Windows.Forms.Label P2LBL;
        private System.Windows.Forms.Label P1LBL;
    }
}

