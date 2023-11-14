using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
//テーマ:単一の意匠により与えられた文字データを工夫したプログラム運用
namespace Morse_App_Edu
{
    /*
        2023/8/15 :開発着手開始
                  :文字→コード変換機能の作成
        2023/8/16 :横スクロール&改行防止機能の実装
        2023/8/18 :Randbetweenの移植
                  :クイズ機能の作成に着手。入力させるか選択させるかは要検討(入力の方が過去のプログラムを参照できるため楽ではあるが)
                  :クイズ機能の作成。回答方式は必要に応じて後に追加予定である。
        2023/8/19 :コード再生機能の作成開始。未知の要素が多い。
                  :コード再生機能の作成。
                  :主要機能の最低限の実装を完了。今後当分はUIの調整や未解決要素の解明を中心に追加する。
        2023/8/21 :大体のUIの調整を完了。クイズモードに表示される符号の改装を開始。
                  :符号表示処理の改装を完了。以前の表示処理はコメント化して残している。。
        2023/9/3  :信号入力に伴う画像の生成機能の作成開始。併せて、使用フレームワークを.NET Freamwork 4.8 から 3.5に切り替えた。
        2023/9/4  :画像生成機能の作成完了。3.5ではNet.httpの参照に問題が発生した。が現状ここを参照していない為問題ない。
        2023/11/13:再生処理に関して、速度を調整できるようにした。位置調整の値の調整を別関数に格納した。
        2023/11/15:再生処理について、半角スペースを入力時に待機するように処理を変更した。
     */
    public partial class Form1 : Form
    {
        string Version = "1.0.2a";
        string Form_text = "モールス符号早覚えゲーム";
        Morse morse = new Morse();
        //MorseEventhandler morseEventhandler = new MorseEventhandler();
        bool q_judge;
        Stopwatch stopwatch = new Stopwatch();
        //Stopwatch Stopwatch_morse = new Stopwatch();
        StreamWriter stream;
        Point Upperpanelpoint = new Point(0, 20);
        string Content_2;
        Size Defaultformsize = new Size(450, 350);
        Bitmap diagram;
        Graphics morsecode;
        SolidBrush brush = new SolidBrush(Color.Blue);
        Bitmap Code_image;
        Graphics Code_image2;
        SolidBrush Stripe = new SolidBrush(Color.Black);
        SolidBrush Back = new SolidBrush(Color.White);
        //Pen Stripe = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();
        }
        private void モールス信号WikipediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.DownloadData("https://www.gunma-ct.ac.jp/cms/wp-content/themes/kosen/images/common/header_logo.svg");
            client.DownloadFile("https://www.gunma-ct.ac.jp/cms/wp-content/themes/kosen/images/common/header_logo.svg", "C:\\Users\\kokkoro\\Desktop\\a.svg");
            //int p = DateTime.Now .Hour ;
            //MessageBox.Show(p.ToString());
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            int h, m, s;
            h = DateTime.Now.Hour;
            m = DateTime.Now.Minute;
            s = DateTime.Now.Second;
            //PerformanceCounter counter = new PerformanceCounter();
            //counter.


            LocalTimeLabel1.Text = "只今の時間:" + h.ToString() + ":" + m.ToString() + ":" + s.ToString();
            //ApplicationMemory.Text = "現在の使用メモリサイズ :";//+ Process.GetCurrentProcess().ToString();
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
            //stopwatch.Start();
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

        }
        private void MorseTable_Click(object sender, EventArgs e)
        {
            Title.Hide();
        }
        private void Title_Click(object sender, EventArgs e)//
        {
            //MessageBox.Show(GC.GetTotalMemory(true).ToString());
            char[] a;
            string b = "abcde";
            a = b.ToCharArray();
            //MessageBox.Show(a.Length.ToString() + "\n" + a[0].ToString() + "\n" + a[1].ToString());
            //MessageBox.Show(Stopwatch.GetTimestamp().ToString());
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)//試用:押下していた時間を計測
        {
            stopwatch.Start();
            Pu.BackColor = Color.Blue;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)//偶に呼び出されないことがある。
        {
            //この辺のコードは後に使用するため消さない事

            //MessageBox.Show(e.KeyValue.ToString());
            //stopwatch.Stop();
            //SystemSounds.Beep.Play();
            //TimeSpan timeSpan = stopwatch.Elapsed;

            //Text = timeSpan.Milliseconds.ToString();
            //Pu.BackColor = Color.Red;
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
                    if (e.KeyValue == 67)//C
                    {
                        Understand_Click(sender, e);
                    }
                    else if (e.KeyValue == 78)//N
                    {
                        Dontunderstand_Click(sender, e);
                    }
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
            //GC.Collect();
            Codeinput.Text = "";
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
            char[] content;
            int i;
            content = Codeinput.Text.ToCharArray();
            for (i = 0; i <= content.Length - 1; i++)
            {
                a[i] = content[i];
            }
            for (i = 0; i <= Codeinput.TextLength - 1; i++)
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
            if (MCode.Visible == true)//(q_judge == true)
            {
                MCode.Visible = false;
                NextQuestion();
            }
            else if (MCode.Visible == false)//(q_judge == false)//pictureboxによる描画に処理を切り替える
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
                    if (chars1[a - 1] == '.')
                    {
                        widthpoint += 10;
                    }
                    else if (chars1[a - 1] == '-')
                    {
                        widthpoint += 30;
                    }
                    if (a == str.Length)
                    {
                        continue;
                    }
                    else
                    {
                        widthpoint += letteroffset;
                    }
                }
                MCode.Width = widthpoint;
                Debugger.Text = widthpoint.ToString();

                diagram = new Bitmap(MCode.Width, MCode.Height);
                morsecode = Graphics.FromImage(diagram);
                int origin = 0;
                for (int a = 1; a <= str.Length; a++)
                {
                    if (chars1[a - 1] == '.')
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
            if (q_judge == true)
            {
                NextQuestion();
            }
            else
            {
                morse.Quizpanel_Click(Question);
            }
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
            if (Codeinput.Text.Length == 0)
            {
                MessageBox.Show("文字を入力してください", "Errorのお知らせ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveDialog_DefaultSetting();
            char[] C;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)//OK以外を選択したとき(エラー処理)
            {//このタイミングでプロセスメモリが一様に増加している。
                //Dispose();
                return;
            }
            C = Codeinput.Text.ToCharArray();
            using (stream = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8))//ファイルの上書き作成
            {
            }
            for (int i = 1; i <= Codeinput.TextLength; i++)
            {
                using (stream = new StreamWriter(saveFileDialog1.FileName, true, Encoding.UTF8))//ファイルに追記
                {
                    stream.Write(morse.MorseCode(C[i - 1]) + " ");
                }
            }
            //stream.Dispose();
        }
        private void SaveDialog_DefaultSetting()
        {
            saveFileDialog1.FileName = "output";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "テキスト|*.txt*";
        }
        private void SaveDialog_ImageSetting()
        {
            saveFileDialog1.FileName = "output";
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "PNG|*.png*";
        }
        private void Generate_Image_Click(object sender, EventArgs e)//入力に応じた画像を生成する処理
        {
            if (Codeinput.Text.Length == 0)
            {
                MessageBox.Show("文字を入力してください","Errorのお知らせ",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveDialog_ImageSetting();
            int i, j, k;
            string Convert_content;
            int locate_origin = 0;
            int len;
            char[] C;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)//OK以外を選択したとき(エラー処理)
            {
                return;
            }
            j = Codeinput.TextLength;
            //確認用
            C = Codeinput.Text.ToCharArray();
            char[] C_2;
            for (i = 1; i <= j; i++)//PIctureboxのWidth値の計上
            {
                Convert_content = morse.MorseCode(C[i - 1]);
                C_2 = Convert_content.ToCharArray();
                for (k = 0; k <= Convert_content.Length - 1; k++)
                {
                    if (C_2[k] == '.')
                    {
                        locate_origin += 1;
                    }
                    else if (C_2[k] == '-')
                    {
                        locate_origin += 3;
                    }
                    if (k != Convert_content.Length) locate_origin += 1;
                }
                locate_origin += 3;
            }
            pictureBox1.Width = locate_origin;
            locate_origin = 0;
            Code_image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Code_image2 = Graphics.FromImage(Code_image);
            Code_image2.FillRectangle(Back, -1, -1, pictureBox1.Width + 1, pictureBox1.Height + 1);
            for (i = 1; i <= j; i++)//描画処理
            {
                Convert_content = morse.MorseCode(C[i - 1]);
                len = Convert_content.Length;
                C_2 = Convert_content.ToCharArray();
                for (k = 1; k <= Convert_content.Length; k++)
                {
                    if (C_2[k - 1] == '.')
                    {
                        Code_image2.FillRectangle(Stripe, locate_origin, -1, 1, pictureBox1.Height + 1);
                        locate_origin += 1;
                    }
                    else if (C_2[k - 1] == '-')
                    {
                        Code_image2.FillRectangle(Stripe, locate_origin, -1, 3, pictureBox1.Height + 1); ;
                        locate_origin += 3;
                    }
                    if (k != Convert_content.Length) locate_origin += 1;
                }
                locate_origin += 3;
            }
            pictureBox1.Image = Code_image;
            Code_image.Save(saveFileDialog1.FileName, ImageFormat.Png);
        }
        private void Play_Click(object sender, EventArgs e)
        {
            Text = Form_text + " - 信号再生中 - ";
            morse.Play_Click(Codeinput.Text, trackBar1.Value, trackBar2.Value);
            Text = Form_text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "再生速度 : " + trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "周波数 : " + trackBar2.Value.ToString();
        }
    }
}
