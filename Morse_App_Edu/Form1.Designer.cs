namespace Morse_App_Edu
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Title = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Recognize = new System.Windows.Forms.ToolStripSplitButton();
            this.WikipediaLink = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferenceMorseTable = new System.Windows.Forms.ToolStripMenuItem();
            this.Study = new System.Windows.Forms.ToolStripDropDownButton();
            this.Practice = new System.Windows.Forms.ToolStripMenuItem();
            this.Quiz = new System.Windows.Forms.ToolStripMenuItem();
            this.Generate = new System.Windows.Forms.ToolStripLabel();
            this.Other = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LocalTimeLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ApplicationMemory = new System.Windows.Forms.ToolStripStatusLabel();
            this.localtime = new System.Windows.Forms.Timer(this.components);
            this.Pu = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GenePanel = new System.Windows.Forms.Panel();
            this.Dxf_Sector_morse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Generate_Image = new System.Windows.Forms.Label();
            this.ResetCode = new System.Windows.Forms.Label();
            this.Play = new System.Windows.Forms.Label();
            this.GenerateOrSave = new System.Windows.Forms.Label();
            this.Codeinput = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.Quizpanel = new System.Windows.Forms.Panel();
            this.MCode = new System.Windows.Forms.PictureBox();
            this.Debugger = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Dontunderstand = new System.Windows.Forms.Label();
            this.Codeunder = new System.Windows.Forms.Label();
            this.Understand = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Question = new System.Windows.Forms.Label();
            this.Dakenrensyuu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.GenePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.TitlePanel.SuspendLayout();
            this.Quizpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Title.Location = new System.Drawing.Point(2, 7);
            this.Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(335, 27);
            this.Title.TabIndex = 0;
            this.Title.Text = "モールス信号早覚えゲーム(仮)";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Recognize,
            this.Study,
            this.Generate,
            this.Other});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Recognize
            // 
            this.Recognize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Recognize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WikipediaLink,
            this.ReferenceMorseTable});
            this.Recognize.Image = ((System.Drawing.Image)(resources.GetObject("Recognize.Image")));
            this.Recognize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Recognize.Name = "Recognize";
            this.Recognize.Size = new System.Drawing.Size(44, 22);
            this.Recognize.Text = "知る";
            // 
            // WikipediaLink
            // 
            this.WikipediaLink.ForeColor = System.Drawing.Color.Blue;
            this.WikipediaLink.Name = "WikipediaLink";
            this.WikipediaLink.Size = new System.Drawing.Size(194, 22);
            this.WikipediaLink.Text = "モールス信号(Wikipedia)";
            this.WikipediaLink.ToolTipText = "ブラウザを開きます";
            this.WikipediaLink.Click += new System.EventHandler(this.モールス信号WikipediaToolStripMenuItem_Click);
            // 
            // ReferenceMorseTable
            // 
            this.ReferenceMorseTable.Name = "ReferenceMorseTable";
            this.ReferenceMorseTable.Size = new System.Drawing.Size(194, 22);
            this.ReferenceMorseTable.Text = "モールス表を参照する";
            this.ReferenceMorseTable.Click += new System.EventHandler(this.ReferenceMorseTable_Click);
            // 
            // Study
            // 
            this.Study.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Study.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Practice,
            this.Quiz});
            this.Study.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Study.Name = "Study";
            this.Study.Size = new System.Drawing.Size(50, 22);
            this.Study.Text = "覚える";
            // 
            // Practice
            // 
            this.Practice.Name = "Practice";
            this.Practice.Size = new System.Drawing.Size(132, 22);
            this.Practice.Text = "打鍵練習";
            this.Practice.Click += new System.EventHandler(this.Practice_Click);
            // 
            // Quiz
            // 
            this.Quiz.Name = "Quiz";
            this.Quiz.Size = new System.Drawing.Size(132, 22);
            this.Quiz.Text = "クイズ(A~Z)";
            this.Quiz.Click += new System.EventHandler(this.Quiz_Click);
            // 
            // Generate
            // 
            this.Generate.AccessibleDescription = "";
            this.Generate.AccessibleName = "";
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(50, 22);
            this.Generate.Text = "生成する";
            this.Generate.ToolTipText = "アルファベットからモールス信号を生成、又は再生します。";
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Other
            // 
            this.Other.Name = "Other";
            this.Other.Size = new System.Drawing.Size(38, 22);
            this.Other.Text = "その他";
            this.Other.Click += new System.EventHandler(this.Other_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalTimeLabel1,
            this.ApplicationMemory});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(600, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LocalTimeLabel1
            // 
            this.LocalTimeLabel1.Name = "LocalTimeLabel1";
            this.LocalTimeLabel1.Size = new System.Drawing.Size(68, 17);
            this.LocalTimeLabel1.Text = "只今の時間:";
            // 
            // ApplicationMemory
            // 
            this.ApplicationMemory.Name = "ApplicationMemory";
            this.ApplicationMemory.Size = new System.Drawing.Size(118, 17);
            this.ApplicationMemory.Text = "toolStripStatusLabel1";
            // 
            // localtime
            // 
            this.localtime.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Pu
            // 
            this.Pu.AutoSize = true;
            this.Pu.Location = new System.Drawing.Point(110, 205);
            this.Pu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Pu.Name = "Pu";
            this.Pu.Size = new System.Drawing.Size(35, 12);
            this.Pu.TabIndex = 4;
            this.Pu.Text = "label2";
            this.Pu.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(51, 150);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(75, 18);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GenePanel
            // 
            this.GenePanel.Controls.Add(this.Dxf_Sector_morse);
            this.GenePanel.Controls.Add(this.label2);
            this.GenePanel.Controls.Add(this.trackBar2);
            this.GenePanel.Controls.Add(this.label1);
            this.GenePanel.Controls.Add(this.trackBar1);
            this.GenePanel.Controls.Add(this.Generate_Image);
            this.GenePanel.Controls.Add(this.ResetCode);
            this.GenePanel.Controls.Add(this.Play);
            this.GenePanel.Controls.Add(this.GenerateOrSave);
            this.GenePanel.Controls.Add(this.Codeinput);
            this.GenePanel.Location = new System.Drawing.Point(345, 112);
            this.GenePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GenePanel.Name = "GenePanel";
            this.GenePanel.Size = new System.Drawing.Size(176, 378);
            this.GenePanel.TabIndex = 7;
            // 
            // Dxf_Sector_morse
            // 
            this.Dxf_Sector_morse.AutoSize = true;
            this.Dxf_Sector_morse.Location = new System.Drawing.Point(16, 201);
            this.Dxf_Sector_morse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dxf_Sector_morse.Name = "Dxf_Sector_morse";
            this.Dxf_Sector_morse.Size = new System.Drawing.Size(53, 12);
            this.Dxf_Sector_morse.TabIndex = 16;
            this.Dxf_Sector_morse.Text = "円弧生成";
            this.Dxf_Sector_morse.Click += new System.EventHandler(this.Dxf_Sector_morse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(106, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "label2";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 10;
            this.trackBar2.Location = new System.Drawing.Point(92, 148);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar2.Maximum = 2000;
            this.trackBar2.Minimum = 200;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.SmallChange = 100;
            this.trackBar2.TabIndex = 14;
            this.trackBar2.TickFrequency = 1000;
            this.trackBar2.Value = 200;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(164, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(124, 129);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 12;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Generate_Image
            // 
            this.Generate_Image.AutoSize = true;
            this.Generate_Image.Location = new System.Drawing.Point(14, 129);
            this.Generate_Image.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Generate_Image.Name = "Generate_Image";
            this.Generate_Image.Size = new System.Drawing.Size(94, 12);
            this.Generate_Image.TabIndex = 11;
            this.Generate_Image.Text = "画像を生成(保存)";
            this.Generate_Image.Click += new System.EventHandler(this.Generate_Image_Click);
            // 
            // ResetCode
            // 
            this.ResetCode.AutoSize = true;
            this.ResetCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ResetCode.Location = new System.Drawing.Point(32, 100);
            this.ResetCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ResetCode.Name = "ResetCode";
            this.ResetCode.Size = new System.Drawing.Size(56, 12);
            this.ResetCode.TabIndex = 3;
            this.ResetCode.Text = "リセットする";
            this.ResetCode.Click += new System.EventHandler(this.ResetCode_Click);
            // 
            // Play
            // 
            this.Play.AutoSize = true;
            this.Play.Location = new System.Drawing.Point(169, 100);
            this.Play.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(29, 12);
            this.Play.TabIndex = 2;
            this.Play.Text = "再生";
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // GenerateOrSave
            // 
            this.GenerateOrSave.AutoSize = true;
            this.GenerateOrSave.Location = new System.Drawing.Point(28, 72);
            this.GenerateOrSave.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GenerateOrSave.Name = "GenerateOrSave";
            this.GenerateOrSave.Size = new System.Drawing.Size(106, 12);
            this.GenerateOrSave.TabIndex = 1;
            this.GenerateOrSave.Text = "テキストを生成(保存)";
            this.GenerateOrSave.Click += new System.EventHandler(this.GenerateOrSave_Click);
            // 
            // Codeinput
            // 
            this.Codeinput.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.Codeinput.Location = new System.Drawing.Point(16, 19);
            this.Codeinput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Codeinput.Multiline = true;
            this.Codeinput.Name = "Codeinput";
            this.Codeinput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Codeinput.Size = new System.Drawing.Size(181, 37);
            this.Codeinput.TabIndex = 0;
            this.Codeinput.TabStop = false;
            this.Codeinput.WordWrap = false;
            this.Codeinput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = " ";
            this.saveFileDialog1.Filter = "テキスト|*.txt*";
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TitlePanel.Controls.Add(this.Pu);
            this.TitlePanel.Controls.Add(this.progressBar1);
            this.TitlePanel.Controls.Add(this.Title);
            this.TitlePanel.Location = new System.Drawing.Point(0, 24);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(320, 261);
            this.TitlePanel.TabIndex = 4;
            // 
            // Quizpanel
            // 
            this.Quizpanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Quizpanel.Controls.Add(this.MCode);
            this.Quizpanel.Controls.Add(this.Debugger);
            this.Quizpanel.Controls.Add(this.label7);
            this.Quizpanel.Controls.Add(this.Dontunderstand);
            this.Quizpanel.Controls.Add(this.Codeunder);
            this.Quizpanel.Controls.Add(this.Understand);
            this.Quizpanel.Controls.Add(this.label3);
            this.Quizpanel.Controls.Add(this.textBox2);
            this.Quizpanel.Controls.Add(this.Question);
            this.Quizpanel.Location = new System.Drawing.Point(333, 174);
            this.Quizpanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Quizpanel.Name = "Quizpanel";
            this.Quizpanel.Size = new System.Drawing.Size(374, 182);
            this.Quizpanel.TabIndex = 8;
            // 
            // MCode
            // 
            this.MCode.BackColor = System.Drawing.Color.White;
            this.MCode.Location = new System.Drawing.Point(53, 146);
            this.MCode.Margin = new System.Windows.Forms.Padding(0);
            this.MCode.Name = "MCode";
            this.MCode.Size = new System.Drawing.Size(191, 30);
            this.MCode.TabIndex = 6;
            this.MCode.TabStop = false;
            // 
            // Debugger
            // 
            this.Debugger.AutoSize = true;
            this.Debugger.Location = new System.Drawing.Point(0, 0);
            this.Debugger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Debugger.Name = "Debugger";
            this.Debugger.Size = new System.Drawing.Size(54, 12);
            this.Debugger.TabIndex = 7;
            this.Debugger.Text = "デバッガ―";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "セルフチェック方式";
            this.label7.Visible = false;
            // 
            // Dontunderstand
            // 
            this.Dontunderstand.AutoSize = true;
            this.Dontunderstand.Location = new System.Drawing.Point(233, 117);
            this.Dontunderstand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dontunderstand.Name = "Dontunderstand";
            this.Dontunderstand.Size = new System.Drawing.Size(71, 12);
            this.Dontunderstand.TabIndex = 5;
            this.Dontunderstand.Text = "分からない(N)";
            this.Dontunderstand.Click += new System.EventHandler(this.Dontunderstand_Click);
            // 
            // Codeunder
            // 
            this.Codeunder.AutoSize = true;
            this.Codeunder.Font = new System.Drawing.Font("MS UI Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Codeunder.Location = new System.Drawing.Point(178, 65);
            this.Codeunder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Codeunder.Name = "Codeunder";
            this.Codeunder.Size = new System.Drawing.Size(59, 38);
            this.Codeunder.TabIndex = 4;
            this.Codeunder.Text = ".-_";
            this.Codeunder.Visible = false;
            // 
            // Understand
            // 
            this.Understand.AutoSize = true;
            this.Understand.Location = new System.Drawing.Point(140, 117);
            this.Understand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Understand.Name = "Understand";
            this.Understand.Size = new System.Drawing.Size(52, 12);
            this.Understand.TabIndex = 3;
            this.Understand.Text = "分かる(C)";
            this.Understand.Click += new System.EventHandler(this.Understand_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "質問形式";
            this.label3.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(286, 146);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 19);
            this.textBox2.TabIndex = 1;
            this.textBox2.Visible = false;
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Font = new System.Drawing.Font("MS UI Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Question.Location = new System.Drawing.Point(158, 25);
            this.Question.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(42, 38);
            this.Question.TabIndex = 0;
            this.Question.Text = "A";
            // 
            // Dakenrensyuu
            // 
            this.Dakenrensyuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Dakenrensyuu.Location = new System.Drawing.Point(428, 40);
            this.Dakenrensyuu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dakenrensyuu.Name = "Dakenrensyuu";
            this.Dakenrensyuu.Size = new System.Drawing.Size(150, 80);
            this.Dakenrensyuu.TabIndex = 9;
            this.Dakenrensyuu.Visible = false;
            this.Dakenrensyuu.Click += new System.EventHandler(this.Dakenrensyuu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(333, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 40);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(138, 298);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 40);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.GenePanel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Quizpanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Dakenrensyuu);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.GenePanel.ResumeLayout(false);
            this.GenePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.Quizpanel.ResumeLayout(false);
            this.Quizpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton Recognize;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Study;
        private System.Windows.Forms.ToolStripMenuItem Practice;
        private System.Windows.Forms.ToolStripMenuItem WikipediaLink;
        private System.Windows.Forms.ToolStripStatusLabel LocalTimeLabel1;
        private System.Windows.Forms.Label Pu;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripLabel Generate;
        private System.Windows.Forms.ToolStripLabel Other;
        private System.Windows.Forms.ToolStripMenuItem ReferenceMorseTable;
        private System.Windows.Forms.ToolStripMenuItem Quiz;
        private System.Windows.Forms.Panel GenePanel;
        private System.Windows.Forms.Label Play;
        private System.Windows.Forms.Label GenerateOrSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label ResetCode;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Panel Quizpanel;
        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Dontunderstand;
        private System.Windows.Forms.Label Codeunder;
        private System.Windows.Forms.Label Understand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Debugger;
        private System.Windows.Forms.Panel Dakenrensyuu;
        private System.Windows.Forms.ToolStripStatusLabel ApplicationMemory;
        private System.Windows.Forms.TextBox Codeinput;
        private System.Windows.Forms.Timer localtime;
        private System.Windows.Forms.PictureBox MCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Generate_Image;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Dxf_Sector_morse;
    }
}

