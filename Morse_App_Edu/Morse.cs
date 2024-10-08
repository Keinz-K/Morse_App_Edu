﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Morse_App_Edu
{
    internal class Morse//アプリ関連の関数群。
    {
        public string DesktopFilepath = "C:\\Users\\" + Environment.UserName + "\\Desktop\\";
        public string Left(string target_str, int offset_length)//エクセルのLeft関数の再現
        {
            int len = target_str.Length;
            int i;
            char[] a = new char[len];
            string result = "";
            for (i = 1; i <= len; i++) a[i - 1] = Convert.ToChar(target_str.Substring(i - 1, 1));
            for (i = 1; i <= offset_length; i++) result += a[i - 1];
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
            char a = (char)(RandBetween(1, 26) + 64);
            control.Text = a.ToString();
        }
        public void HorizonalAlignCenter(Control control, int y)//コントロールのx軸を親コントロール内中心位置に合わせる関数。y軸方向は任意値
        {
            control.Location = new Point(control.Parent.Width / 2 - control.Width / 2, y);
        }
        //コントロールのx軸を親コントロール内の任意値の位置に合わせる関数。第二引数は0~1の値を入れる事。そうしないと仕様上確実にはみ出します。。y軸方向は任意値
        public void HorizonalAlignUserValue(Control control, float ratio, int y)
        {
            control.Location = new Point((int)(control.Parent.Width * ratio - control.Width / 2), y);
        }
        public bool Notice_error(int length)
        {
            if (length == 0)
            {
                MessageBox.Show("文字を入力してください", "Errorのお知らせ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Yetdevelop()//作り切れていない機能にアクセス出来るボタンに触れた時にこれを表示させる。
        {
            MessageBox.Show("未だ未開発です。今後のアップデートにご期待ください。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public string MorseCode(int code)//個々の分岐については、ASCiicodetable を参照すること。
        {
            switch (code)//雑談であるが、此処の分岐先の返り値を書き換えれば本来のモールス表とは異なる独自の暗号表が作成出来る。(開発時に意図していた要素の一つ)
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
            int i = 0;
            double b = random.NextDouble();
            for (int j = min; j <= max; j++)
            {
                i++;
                if (1 / (double)(max - min) * i >= b) break;
            }
            return i;
        }
        public void Play_Click(string textBox, int time_unit, int frequency)//入力に応じた音声再生処理関数
        {
            int[] aa = new int[textBox.Length];
            string[] audio = new string[textBox.Length];
            int i, j;
            char[] aa_2;
            bool space, number, alphabet;
            for (i = 1; i <= textBox.Length; i++)//文字に対応するコードの代入
            {
                aa[i - 1] = Convert.ToChar(textBox.Substring(i - 1, 1));
                space = aa[i - 1] == 32;
                number = aa[i - 1] >= 48 && aa[i - 1] <= 59;
                alphabet = aa[i - 1] >= 65 && aa[i - 1] <= 122;
                if (space || number || alphabet) audio[i - 1] = MorseCode(aa[i - 1]);
                else
                {
                    MessageBox.Show("処理できない文字が含まれている為再生できません。", "Error のお知らせ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }//代入終わり
            for (i = 1; i <= textBox.Length; i++)//音声再生処理
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
        }
        public void SaveDialog_DefaultSetting(SaveFileDialog saveFileDialog1)
        {
            saveFileDialog1.FileName = "output";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "テキスト|*.txt*";
        }
        public void SaveDialog_ImageSetting(SaveFileDialog saveFileDialog1)
        {
            saveFileDialog1.FileName = "output";
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "PNG|*.png*";
        }

    }
}
