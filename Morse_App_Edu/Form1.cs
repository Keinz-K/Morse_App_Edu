using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
     */
    public partial class Form1 : Form
    {
        string Version = "1.0.1a";
        Morse morse = new Morse();
        //MorseEventhandler morseEventhandler = new MorseEventhandler();
        bool q_judge;
        Stopwatch stopwatch = new Stopwatch();
        //Stopwatch Stopwatch_morse = new Stopwatch();
        StreamWriter stream;
        Point Upperpanelpoint = new Point(0, 20);
        string Content_1, Content_2;
        Size Defaultformsize = new Size(450, 350);
        Bitmap diagram;
        Graphics morsecode;
        SolidBrush brush = new SolidBrush(Color.Blue);
        Bitmap Code_image;
        Graphics Code_image2;
        SolidBrush Stripe = new SolidBrush(Color.Black);
        //Pen Stripe = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();
        }
        private void モールス信号WikipediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var client = new WebClient();
            //client.DownloadData("https://www.gunma-ct.ac.jp/cms/wp-content/themes/kosen/images/common/header_logo.svg");
            //client.DownloadFile("https://www.gunma-ct.ac.jp/cms/wp-content/themes/kosen/images/common/header_logo.svg", "C:\\Users\\kokkoro\\Desktop\\a.svg");
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
        private void Form1_Control_InitStatus()
        {
            //Loction


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_Control_InitStatus();
            Text = "モールス符号早覚えゲーム";
            Title.Text = Text;
            Codeinput.Width = 350;
            MCode.BackColor = MCode.Parent.BackColor;
            Size defaultpanelsize = new Size(440, 270);
            //stopwatch.Start();
            localtime.Stop();
            localtime.Start();
            GenePanel.Hide();
            Codeinput.Height = 45;
            Quizpanel.Hide();
            Debugger.Hide();
            ImeMode = ImeMode.Alpha;
            Size = Defaultformsize;
            TitlePanel.Size = defaultpanelsize;
            GenePanel.Size = defaultpanelsize;
            Quizpanel.Size = defaultpanelsize;
            MinimumSize = Defaultformsize;
            MaximumSize = Defaultformsize;
            morse.HorizonalAlignCenter(Question, 30);
            morse.HorizonalAlignCenter(Codeunder, 80);
            morse.HorizonalAlignCenter(Title, 30);
            morse.HorizonalAlignCenter(Codeinput, 30);
            GenerateOrSave.Location = new Point(40, 100);
            ResetCode.Location = new Point(40, 120);
            Play.Location = new Point(40, 140);
            Generate_Image.Location = new Point(40, 160);
            NextQuestion();
            morse.HorizonalAlignUserValue(Understand, 0.33f, 150);
            morse.HorizonalAlignUserValue(Dontunderstand, 0.66f, 150);
            MCode.Height = 10;
            morse.HorizonalAlignCenter(MCode, 120);
            MCode.Visible = false;
            GenePanel.Location = Upperpanelpoint;
            Quizpanel.Location = Upperpanelpoint;
            pictureBox1.Size = new Size(100, 100);
            saveFileDialog1.InitialDirectory = morse.DesktopFilepath;
        }
        private void MorseTable_Click(object sender, EventArgs e)
        {
            Title.Hide();
        }
        private void Title_Click(object sender, EventArgs e)//開発進捗()
        {
            MessageBox.Show("現在開発中です。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int len = Codeinput.Text.Length;
            Content_1 = Codeinput.Text;
            int[] a;
            a = new int[len];
            char[] content;
            content = new char[len];
            int i;
            for (i = 1; i <= len; i++)
            {
                content[i - 1] = Convert.ToChar(Content_1.Substring(i - 1, 1));
                a[i - 1] = content[i - 1];
            }
            for (i = 0; i <= len - 1; i++)
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

                int len = str.Length;
                char[] chars1 = new char[len];
                int a;
                int widthpoint = 0;//文字に応じたpictureboxのwidthを計上する変数
                int letteroffset = 20;

                for (a = 1; a <= len; a++)
                {
                    chars1[a - 1] = Convert.ToChar(morse.Left(morse.Right(str, 1 + len - a), 1));
                    if (chars1[a - 1] == '.')
                    {
                        widthpoint += 10;
                    }
                    else if (chars1[a - 1] == '-')
                    {
                        widthpoint += 30;
                    }
                    if (a == len)
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
                for (a = 1; a <= len; a++)
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

                /*
                //strの文字間にスペースを入れる処理
                //int len = str.Length;
                string c = " ";
                int i;
                char[] chars = new char[len];
                string fstr = "";
                for (i = 1; i <= len; i++)
                {
                    chars[i - 1] = Convert.ToChar(morse.Left(morse.Right(str, 1 + len - i), 1));
                    fstr += (chars[i - 1] + c);
                }
                Codeunder.Text = fstr;
                */


                morse.HorizonalAlignCenter(MCode, MCode.Location.Y);
                Dontunderstand.Text = "次の問題(N)";
                q_judge = true;
                //morse.Play_Click(code.ToString());//CとNを交互に連打したとき描画が止まり音声再生処理だけが動いている。
            }
            //Debugger.Text = q_judge.ToString();
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
        }
        private void ReferenceMorseTable_Click(object sender, EventArgs e)
        {
            TitlePanel.Hide();
            GenePanel.Hide();
        }
        private void Practice_Click(object sender, EventArgs e)
        {
            morse.Yetdevelop();
        }
        private void GenerateOrSave_Click(object sender, EventArgs e)
        {
            SaveDialog_DefaultSetting();
            int i, j;
            string Fpath, Content, Convert_content;
            char[] C;
            DialogResult result;
            result = saveFileDialog1.ShowDialog();//このタイミングでプロセスメモリが一様に増加している。
            if (result == DialogResult.Cancel)//OK以外を選択したとき(エラー処理)
            {
                return;
            }
            Fpath = saveFileDialog1.FileName;//選択したパスが返
            j = Codeinput.Text.Length;
            Content = Codeinput.Text;
            //確認用
            C = new char[j];
            using (stream = new StreamWriter(Fpath, false, Encoding.UTF8))//ファイルの上書き作成
            {
            }
            for (i = 1; i <= j; i++)
            {
                C[i - 1] = Convert.ToChar(morse.Left(morse.Right(Content, 1 + j - i), 1));//複雑さ増しているような
                //確認用
                //MessageBox.Show(C[i - 1].ToString());
                using (stream = new StreamWriter(Fpath, true, Encoding.UTF8))//ファイルに追記
                {
                    Convert_content = morse.MorseCode(C[i - 1]);
                    stream.Write(Convert_content + " ");
                }
            }

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
            SaveDialog_ImageSetting();
            int i, j, k;
            string Content, Convert_content;
            int locate_origin = 0;
            int len;
            char[] C;
            DialogResult result;
            result = saveFileDialog1.ShowDialog();//このタイミングでプロセスメモリが一様に増加している。
            if (result == DialogResult.Cancel)//OK以外を選択したとき(エラー処理)
            {
                return;
            }
            j = Codeinput.Text.Length;
            Content = Codeinput.Text;
            //確認用
            C = new char[j];
            char[] C_2;
            for (i = 1; i <= j; i++)//PIctureboxのWidth値の計上
            {
                C[i - 1] = Convert.ToChar(morse.Left(morse.Right(Content, 1 + j - i), 1));//複雑さ増しているような
                Convert_content = morse.MorseCode(C[i - 1]);
                len = Convert_content.Length;
                C_2 = new char[len];
                for (k = 1; k <= len; k++)
                {

                    C_2[k - 1] = Convert.ToChar(Convert_content.Substring(k - 1, 1));
                    if (C_2[k - 1] == '.')
                    {
                        locate_origin += 1;
                    }
                    else if (C_2[k - 1] == '-')
                    {
                        locate_origin += 3;
                    }
                    if (k != len) locate_origin += 1;
                }
                locate_origin += 3;
            }
            pictureBox1.Width = locate_origin;
            locate_origin = 0;
            Code_image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Code_image2 = Graphics.FromImage(Code_image);

            for (i = 1; i <= j; i++)//描画処理
            {
                C[i - 1] = Convert.ToChar(morse.Left(morse.Right(Content, 1 + j - i), 1));//複雑さ増しているような
                Convert_content = morse.MorseCode(C[i - 1]);
                len = Convert_content.Length;
                C_2 = new char[len];
                for (k = 1; k <= len; k++)
                {

                    C_2[k - 1] = Convert.ToChar(Convert_content.Substring(k - 1, 1));
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
                    if (k != len)locate_origin += 1;
                }
                locate_origin += 3;
            }
            pictureBox1.Image = Code_image;
            Code_image.Save(saveFileDialog1.FileName, ImageFormat.Png);

        }
        private void Play_Click(object sender, EventArgs e)
        {
            morse.Play_Click(Codeinput.Text);
        }
    }
}
