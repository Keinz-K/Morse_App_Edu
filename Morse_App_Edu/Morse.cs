using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Morse_App_Edu
{
    internal class Morse//アプリ関連の関数群。コントロールを指定しているものを移動させたものは、MorseEventhandler classに格納されている。
    {
        public string DesktopFilepath = "C:\\Users\\" + Environment.UserName + "\\Desktop\\";
        public string Left(string target_str, int offset_length)//エクセルのLeft関数の再現
        {
            int len = target_str.Length;
            int i;
            char[] a = new char[len];
            string result = "";
            for (i = 1; i <= len; i++)
            {
                a[i - 1] = Convert.ToChar(target_str.Substring(i - 1, 1));
            }
            for (i = 1; i <= offset_length; i++)
            {
                result += a[i - 1];
            }
            return result;
        }

        public string Right(string target_str, int offset_length)//エクセルのRight関数の再現
        {
            int len = target_str.Length;
            int i;
            char[] a = new char[len];
            string result = "";
            for (i = 1; i <= len; i++)//左から壱文字ずつ順次代入
            {
                a[i - 1] = Convert.ToChar(target_str.Substring(i - 1, 1));
            }
            for (i = len - offset_length; i <= len - 1; i++)
            {
                result += a[i];
            }
            return result;
        }
        public void Quizpanel_Click(Control control)
        {
            int i = RandBetween(1, 26);
            char a = (char)(i + 64);
            control.Text = a.ToString();
        }
        public void HorizonalAlignCenter(Control control, int y)//コントロールのx軸を親コントロール内中心位置に合わせる関数。y軸方向は任意値
        {
            control.Location = new Point(control.Parent.Width / 2 - control.Width / 2, y);
        }
        public void HorizonalAlignUserValue(Control control, float ratio, int y)//コントロールのx軸を親コントロール内の任意値の位置に合わせる関数。第二引数は0~1の値を入れる事。そうしないと仕様上確実にはみ出します。。y軸方向は任意値
        {
            control.Location = new Point((int)(control.Parent.Width * ratio - control.Width / 2), y);
        }
        public void Yetdevelop()//作り切れていない機能にアクセス出来るボタンに触れた時にこれを表示させる。
        {
            MessageBox.Show("未だ未開発です。今後のアップデートにご期待ください。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public string MorseCode(char code)//個々の分岐については、ASCiicodetable を参照すること。
        {
            int a = (int)code;
            switch (a)//雑談であるが、此処の分岐先の返り値を書き換えれば本来のモールス表とは異なる独自の暗号表が作成出来る。(開発時に意図していた要素の一つ)
            {
                case 32: return " ";//半角スペース
                case 48: return "-----";//0
                case 49: return ".----";//1
                case 50: return "..---";//2
                case 51: return "...--";//3
                case 52: return "....-";//4
                case 53: return ".....";//5
                case 54: return "-....";//6
                case 55: return "--...";//7
                case 56: return "---..";//8
                case 57: return "----.";//9
                case 65: return ".-";//A
                case 66: return "-...";//B
                case 67: return "-.-.";//C
                case 68: return "-..";//D
                case 69: return ".";//E
                case 70: return "..-.";//F
                case 71: return "--.";//G
                case 72: return "....";//H
                case 73: return "..";//I
                case 74: return ".---";//J
                case 75: return "-.-";//K
                case 76: return ".-..";//L
                case 77: return "--";//M
                case 78: return "-.";//N
                case 79: return "---";//O
                case 80: return ".--.";//P
                case 81: return "--.-";//Q
                case 82: return ".-.";//R
                case 83: return "...";//S
                case 84: return "-";//T
                case 85: return "..-";//U
                case 86: return "...-";//V
                case 87: return ".--";//W
                case 88: return "-..-";//X
                case 89: return "-.--";//Y
                case 90: return "--..";//Z
                case 97: return ".-";//a
                case 98: return "-...";//b
                case 99: return "-.-.";//c
                case 100: return "-..";//d
                case 101: return ".";//e
                case 102: return "..-.";//f
                case 103: return "--.";//g
                case 104: return "....";//h
                case 105: return "..";//i
                case 106: return ".---";//j
                case 107: return "-.-";//k
                case 108: return ".-..";//l
                case 109: return "--";//m
                case 110: return "-.";//n
                case 111: return "---";//o
                case 112: return ".--.";//p
                case 113: return "--.-";//q
                case 114: return ".-.";//r
                case 115: return "...";//s
                case 116: return "-";//t
                case 117: return "..-";//u
                case 118: return "...-";//v
                case 119: return ".--";//w
                case 120: return "-..-";//x
                case 121: return "-.--";//y
                case 122: return "--..";//z
                default: return "Err";//
            }
        }
        public int RandBetween(int min, int max)//Excelの関数の再現
        {
            Random random = new Random();
            int a = max - min;
            int i = 0;
            int j;
            double b = random.NextDouble();
            //MessageBox.Show(b.ToString());
            for (j = min; j <= max; j++)
            {
                i++;
                if (1 / (double)a * i >= b) break;

            }
            return i;
        }
        public void Play_Click(string textBox, int time_unit, int frequency)//入力に応じた音声再生処理関数
        {
            int len = textBox.Length;
            char[] aa = new char[len];
            string[] audio = new string[len];
            int i, j;
            char[] aa_2;
            for (i = 1; i <= len; i++)//文字に対応するコードの代入
            {
                aa[i - 1] = Convert.ToChar(textBox.Substring(i - 1, 1));
                //MessageBox.Show(((int)(aa[i - 1])).ToString());
                if ((int)aa[i - 1] == 32 || ((int)(aa[i - 1]) >= 48 && (int)(aa[i - 1]) <= 59) || ((int)(aa[i - 1]) >= 65) && ((int)(aa[i - 1]) <= 122))//見づらい
                {
                    audio[i - 1] = MorseCode(aa[i - 1]);
                }
                else
                {
                    MessageBox.Show("処理できない文字が含まれている為再生できません。", "Error のお知らせ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }//代入終わり

            for (i = 1; i <= len; i++)//音声再生処理
            {
                int len_2 = audio[i - 1].Length;
                aa_2 = new char[len_2];//???
                for (j = 1; j <= len_2; j++)
                {
                    aa_2[j - 1] = Convert.ToChar(audio[i - 1].Substring(j - 1, 1));
                    if (aa_2[j - 1] == '.') Console.Beep(frequency, time_unit);
                    else if (aa_2[j - 1] == '-') Console.Beep(frequency, time_unit * 3);
                    else if (aa_2[j - 1] == ' ')
                    {
                        Thread.Sleep(time_unit * 7);
                        continue;
                    }
                    Thread.Sleep(time_unit);
                }
                Thread.Sleep(time_unit * 3);
            }
            //長文を打ち込んだ際に、安全の為アプリケーションを停止、或いはプロセスを中断する機能が必要である。
            //再生処理のみにアプリ内のプロセスの進行が占有されている。現状停止させる方法はあるので別に問題ないが素人向けでない為解決したい。

        }
        private void InitPictureDraw(PictureBox pictureBox)
        {
            Bitmap bitmap;
            Graphics graphics;
            Pen blackpen = new Pen(Color.Black, 1f);
            SolidBrush solidBrush = new SolidBrush(Color.DarkRed);
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.DrawLine(blackpen, 10, 10, 30, 30);
            graphics.DrawPie(blackpen, 10, 10, 30, 30, 0, 360);
            graphics.FillPie(solidBrush, 50, 50, 10, 10, 90, 180);//時計回り


            pictureBox.Image = bitmap;
        }

    }
}
