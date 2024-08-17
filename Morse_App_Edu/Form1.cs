using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
//テーマ:単一の意匠により与えられた文字データを工夫したプログラム運用
namespace Morse_App_Edu
{
    public partial class Form1 : Form
    {
        //オブジェクト接触時のイベントは動かせないので、処理をブロック化して別クラスに配置すること。
        readonly string Version = "1.0.3a";
        readonly string Form_text = "モールス符号早覚えゲーム";
        readonly Morse morse = new Morse();//Morse.cs
        readonly Dxf_writer dxf_Writer = new Dxf_writer();//Dxf_writer.cs
        bool q_judge;
        Stopwatch stopwatch = new Stopwatch();
        StreamWriter stream;//使用時に宣言するのでも良いが、メモリ使用量が多くなる希ガス
        Point Upperpanelpoint = new Point(0, 20);
        string Content_2;
        Size Defaultformsize = new Size(450, 350);
        Bitmap diagram;//クイズでの付表生成用
        Graphics morsecode;
        readonly SolidBrush brush = new SolidBrush(Color.Blue);
        Bitmap Code_image;//画像生成用
        Graphics Code_image2;
        readonly SolidBrush Stripe = new SolidBrush(Color.Black);
        readonly SolidBrush Back = new SolidBrush(Color.White);
        public Form1()
        {
            InitializeComponent();
        }
        private void モールス信号WikipediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            int h, m, s;
            h = DateTime.Now.Hour;
            m = DateTime.Now.Minute;
            s = DateTime.Now.Second;
            LocalTimeLabel1.Text = "只今の時間:" + h.ToString() + ":" + m.ToString() + ":" + s.ToString();
        }
        private void Location_adjustment_load()//Form_Load関数実行時に一緒に実行。初期の位置調整関連の処理を格納
        {
            Size defaultpanelsize = new Size(440, 270);
            TitlePanel.Size = defaultpanelsize;
            GenePanel.Size = defaultpanelsize;
            Quizpanel.Size = defaultpanelsize;
            morse.HorizonalAlignCenter(Question, 30);
            morse.HorizonalAlignCenter(Codeunder, 80);
            morse.HorizonalAlignCenter(Title, 30);
            morse.HorizonalAlignCenter(Codeinput, 30);
            GenerateOrSave.Location = new Point(40, 100);
            ResetCode.Location = new Point(40, 120);
            Play.Location = new Point(40, 140);
            Dxf_Sector_morse.Location = new Point(40, 180);
            Generate_Image.Location = new Point(40, 160);
            morse.HorizonalAlignUserValue(Understand, 0.33f, 150);
            morse.HorizonalAlignUserValue(Dontunderstand, 0.66f, 150);
            morse.HorizonalAlignCenter(MCode, 120);
            GenePanel.Location = Upperpanelpoint;
            Quizpanel.Location = Upperpanelpoint;
            label1.Location = new Point(240, 100);
            label2.Location = new Point(240, 180);
            trackBar1.Location = new Point(200, 120);
            trackBar2.Location = new Point(200, 210);
            trackBar1.Size = new Size(190, trackBar1.Height);
            trackBar2.Size = new Size(190, trackBar1.Height);
        }
        private void Form1_Load(object sender, EventArgs e)//順番変えると狂う場所があるため注意
        {
            Text = Form_text;
            Title.Text = Text;
            Codeinput.Width = 350;
            MCode.BackColor = MCode.Parent.BackColor;
            localtime.Stop();
            localtime.Start();
            GenePanel.Hide();
            Codeinput.Height = 45;
            Quizpanel.Hide();
            Debugger.Hide();
            ImeMode = ImeMode.Alpha;
            Size = Defaultformsize;
            Location_adjustment_load();
            MinimumSize = Defaultformsize;
            MaximumSize = Defaultformsize;
            NextQuestion();
            MCode.Height = 10;
            MCode.Visible = false;
            pictureBox1.Size = new Size(100, 100);
            saveFileDialog1.InitialDirectory = morse.DesktopFilepath;
            label1.Text = trackBar1.Maximum.ToString();
            trackBar1.Minimum = 40;
            trackBar1.Value = trackBar1.Maximum;
            trackBar2.Maximum = 20000;
            trackBar2.Value = 600;
            trackBar1_Scroll(sender, e);
            trackBar2_Scroll(sender, e);
            pictureBox2.Hide();
            backgroundWorker1.RunWorkerAsync();
        }
        private void MorseTable_Click(object sender, EventArgs e)
        {
            Title.Hide();
        }
        private void Title_Click(object sender, EventArgs e)//
        {
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)//試用:押下していた時間を計測
        {
            stopwatch.Start();
            Pu.BackColor = Color.Blue;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)//偶に呼び出されないことがある。
        {
            if (e.KeyValue == 27)
            {
                TitlePanel.Show();
                Quizpanel.Hide();
                GenePanel.Hide();
            }
            else
            {
                if (e.KeyValue >= 65 && e.KeyValue <= 65 + 26 && Quizpanel.Visible == true)//練習モード(A~Z)時
                {
                    //この部分の処理が動作しない事がある。
                    if (e.KeyValue == 67) Understand_Click(sender, e);//C
                    else if (e.KeyValue == 78) Dontunderstand_Click(sender, e);//N
                    //確認用
                    //MessageBox.Show(e.KeyCode.ToString());
                }
            }
            stopwatch.Reset();
        }
        private void Generate_Click(object sender, EventArgs e)
        {
            Codeinput.Text = "";
            GenePanel.Show();
            TitlePanel.Hide();
            Quizpanel.Hide();
        }
        private void ResetCode_Click(object sender, EventArgs e)
        {
            Codeinput.Text = "";
            backgroundWorker1.CancelAsync();
        }
        private void Quiz_Click(object sender, EventArgs e)
        {
            TitlePanel.Hide();
            GenePanel.Hide();
            Quizpanel.Show();
            morse.Quizpanel_Click(Question);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//2行二渡ったところで1行に補正する
        {
            int[] a;
            a = new int[Codeinput.TextLength];
            for (int i = 0; i <= Codeinput.Text.ToCharArray().Length - 1; i++) a[i] = Codeinput.Text.ToCharArray()[i];
            for (int i = 0; i <= Codeinput.TextLength - 1; i++)
            {
                if (a[i] == 13)
                {
                    Codeinput.Text = Content_2;
                    //カーソルを右端に渡したい
                    return;
                }
            }
            Content_2 = Codeinput.Text;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            morse.Quizpanel_Click(Question);
        }
        private void Dontunderstand_Click(object sender, EventArgs e)
        {
            if (MCode.Visible == true)
            {
                MCode.Visible = false;
                NextQuestion();
            }
            else if (MCode.Visible == false)//pictureboxによる描画に処理を切り替える
            {
                MCode.Visible = true;
                char code = Convert.ToChar(Question.Text);
                string str = morse.MorseCode(code);
                //符号に対応する文字列に応じてpictureboxのimageを再描画させる処理
                char[] chars1 = str.ToCharArray();
                int widthpoint = 0;//文字に応じたpictureboxのwidthを計上する変数
                int letteroffset = 20;
                for (int a = 1; a <= str.Length; a++)
                {
                    if (chars1[a - 1] == '.') widthpoint += 10;
                    else if (chars1[a - 1] == '-') widthpoint += 30;
                    if (a == str.Length) continue;
                    else widthpoint += letteroffset;
                }
                MCode.Width = widthpoint;
                Debugger.Text = widthpoint.ToString();

                diagram = new Bitmap(MCode.Width, MCode.Height);
                morsecode = Graphics.FromImage(diagram);
                int origin = 0;
                for (int a = 1; a <= str.Length; a++)
                {
                    if (chars1[a - 1] == '.')//モールスの付表が変わる事を前提に作っている
                    {
                        morsecode.FillPie(brush, origin, 0, 10, 10, 0, 360);//基本実装
                        origin += 10;
                    }
                    else if (chars1[a - 1] == '-')
                    {
                        morsecode.FillPie(brush, origin, -1, 10, 11, 90, 180);//基本実装1
                        morsecode.FillRectangle(brush, origin + 5, 0, 20, 10);//基本実装2
                        morsecode.FillPie(brush, origin + 20, -1, 10, 11, -90, 180);//基本実装3()
                        origin += 30;
                    }
                    origin += letteroffset;
                }
                MCode.Image = diagram;
                //morsecode.Dispose();
                morse.HorizonalAlignCenter(MCode, MCode.Location.Y);
                Dontunderstand.Text = "次の問題(N)";
                q_judge = true;
                //morse.Play_Click(code.ToString());//CとNを交互に連打したとき描画が止まり音声再生処理だけが動いている。
            }
        }
        private void NextQuestion()
        {
            Codeunder.Text = "???";
            morse.HorizonalAlignCenter(Codeunder, Codeunder.Location.Y);
            Dontunderstand.Text = "分からない(N)";
            q_judge = false;
            morse.Quizpanel_Click(Question);
        }
        private void Understand_Click(object sender, EventArgs e)
        {
            MCode.Visible = false;
            if (q_judge == true) NextQuestion();
            else morse.Quizpanel_Click(Question);
        }
        private void Dakenrensyuu_Click(object sender, EventArgs e)
        {

        }
        private void Other_Click(object sender, EventArgs e)
        {
            MessageBox.Show("バージョン:" + Version + "\n作成者:keinz\n", "Version info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Title_Click(sender, e);
        }
        private void ReferenceMorseTable_Click(object sender, EventArgs e)
        {
            TitlePanel.Hide();
            GenePanel.Hide();
            pictureBox2.Show();
        }
        private void Practice_Click(object sender, EventArgs e)
        {
            morse.Yetdevelop();
        }
        private void GenerateOrSave_Click(object sender, EventArgs e)
        {
            if (morse.Notice_error(Codeinput.Text.Length)) return;
            morse.SaveDialog_DefaultSetting(saveFileDialog1);
            char[] C;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            C = Codeinput.Text.ToCharArray();
            using (stream = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8))//ファイルの上書き作成
            {
            }
            for (int i = 1; i <= Codeinput.TextLength; i++) using (stream = new StreamWriter(saveFileDialog1.FileName, true, Encoding.UTF8)) stream.Write(morse.MorseCode(C[i - 1]) + " ");
        }
        private void Generate_Image_Click(object sender, EventArgs e)//入力に応じた画像を生成する処理
        {
            if (morse.Notice_error(Codeinput.Text.Length)) return;
            morse.SaveDialog_ImageSetting(saveFileDialog1);
            string Convert_content;
            int locate_origin = 0;
            char[] C;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;//OK以外を選択したとき(エラー処理)
            //確認用
            C = Codeinput.Text.ToCharArray();
            char[] C_2;
            for (int i = 1; i <= Codeinput.TextLength; i++)//PIctureboxのWidth値の計上
            {
                Convert_content = morse.MorseCode(C[i - 1]);
                C_2 = Convert_content.ToCharArray();
                for (int k = 0; k <= Convert_content.Length - 1; k++)
                {
                    if (C_2[k] == '.') locate_origin += 1;
                    else if (C_2[k] == '-') locate_origin += 3;
                    if (k != Convert_content.Length) locate_origin += 1;
                }
                locate_origin += 3;
            }
            pictureBox1.Width = locate_origin;
            locate_origin = 0;
            Code_image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Code_image2 = Graphics.FromImage(Code_image);
            Code_image2.FillRectangle(Back, -1, -1, pictureBox1.Width + 1, pictureBox1.Height + 1);
            for (int i = 1; i <= Codeinput.TextLength; i++)//描画処理
            {
                Convert_content = morse.MorseCode(C[i - 1]);
                C_2 = Convert_content.ToCharArray();
                for (int k = 1; k <= Convert_content.Length; k++)
                {
                    if (C_2[k - 1] == '.') FillRect(1, locate_origin);
                    else if (C_2[k - 1] == '-') FillRect(3, locate_origin);
                    if (k != Convert_content.Length) locate_origin += 1;
                }
                locate_origin += 3;
            }
            pictureBox1.Image = Code_image;
            Code_image.Save(saveFileDialog1.FileName, ImageFormat.Png);
        }
        private void FillRect(int size, int locate)
        {
            Code_image2.FillRectangle(Stripe, locate, -1, size, pictureBox1.Height + 1);
            locate += size;
        }
        private void Play_Click(object sender, EventArgs e)
        {
            Text = Form_text + " - 信号再生中 - ";
            backgroundWorker1.RunWorkerAsync();
        }
        int a, b;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "再生速度 : " + trackBar1.Value.ToString();
            a = trackBar1.Value;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "周波数 : " + trackBar2.Value.ToString();
            b = trackBar2.Value;
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            morse.Play_Click(Codeinput.Text, a, b);
        }

        private void Dxf_Sector_morse_Click(object sender, EventArgs e)
        {
            if (morse.Notice_error(Codeinput.Text.Length)) return;
            dxf_Writer.SaveDialog_DxfSetting(saveFileDialog1);
            string Convert_content;
            int locate_origin = 0;
            char[] C;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;//OK以外を選択したとき(エラー処理)
            //確認用
            C = Codeinput.Text.ToCharArray();
            char[] C_2;
            for (int i = 1; i <= Codeinput.TextLength; i++)//morse のコードから分割数の算出
            {
                Convert_content = morse.MorseCode(C[i - 1]);
                C_2 = Convert_content.ToCharArray();
                for (int k = 0; k <= Convert_content.Length - 1; k++)
                {
                    if (C_2[k] == '.') locate_origin += 1;
                    else if (C_2[k] == '-') locate_origin += 3;
                    if (k != Convert_content.Length) locate_origin += 1;
                }
                locate_origin += 2;
            }
            Console.WriteLine("分割数 : " + locate_origin);
            double bb = locate_origin;
            dxf_Writer.header(saveFileDialog1.FileName);
            double aa = 0;
            //double x_end_pos = 0;
            //double y_end_pos = 0;
            /*
            for (int kk = 0; kk <= locate_origin; kk++)
            {
                x_end_pos = 19 * Math.Cos((double)((double)kk / (double)locate_origin)*360 * Math.PI / 180);
                y_end_pos = 19 * Math.Sin((double)((double)kk / (double)locate_origin)*360 * Math.PI / 180);
                //Console.WriteLine(kk + " : " + x_end_pos + "\t" + y_end_pos + "\t" + (double)((double)kk / (double)locate_origin));
                //dxf_Writer.Dxf_line(0, 0, x_end_pos, y_end_pos);
            }
            */
            //分割生成計算
            for (int i = 1; i <= Codeinput.TextLength; i++)//扇の描画
            {
                Convert_content = morse.MorseCode(C[i - 1]);
                C_2 = Convert_content.ToCharArray();
                for (int k = 0; k <= Convert_content.Length - 1; k++)
                {
                    aa = locate_origin / bb;
                    if (C_2[k] == '.')
                    {
                        dxf_Writer.Dxf_Sector(20, 50, aa * 360, (locate_origin + 1) / bb * 360, 0, 0);
                        locate_origin += 1;
                    }
                    else if (C_2[k] == '-')
                    {
                        dxf_Writer.Dxf_Sector(20, 50, aa * 360, (locate_origin + 3) / bb * 360, 0, 0);
                        locate_origin += 3;
                    }
                    if (k != Convert_content.Length) locate_origin += 1;
                }
                locate_origin += 2;
            }
            dxf_Writer.footer();
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Text = Form_text;
        }
    }
}
