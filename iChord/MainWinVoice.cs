using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Xml;
using System.IO;
using SimpleMidiPlayer.Midi;
using System.Windows.Markup;
using SpeechLib;
using Voice;

namespace iChord
{
    #region Windows Voice
    public partial class MainWindow : Window
    {
        //SpRecognition sp;
        Thread t;
        bool flag=false;
        private string cur;
        SpVoice sv = new SpVoice();
        WordDictionaries wd = new WordDictionaries();
        private void Intro()
        {
            introduction();
        }
        private void spInit()
        {
            //sp = SpRecognition.instance();
            //sp.SetMessage += ShowMessage;
        }
        private void introduction()
        {
            judgeReturn(-1);
        }
        private void Speak_Click(object sender, RoutedEventArgs e)
        {
            Speak(cur);
        }
        private void Recognition_Click(object sender, RoutedEventArgs e)
        {
            Recognition();
        }
        private void Speak_Start(object data)
        {
            string datastr = data as string;
            Speak_Inner(datastr);
        }
        private void Speak(string str)
        {
            t = new Thread(new ParameterizedThreadStart(Speak_Start));
            t.IsBackground = true;
            t.Start(str);
            flag = true;
        }
        private void Speak_Inner(string str)
        {
            sv.Voice = sv.GetVoices(string.Empty, string.Empty).Item(0);
            sv.Speak(str);
        }
        private void ShowMessage(string msg)
        {
            //sp.CloseRec();
            t.Abort();
            int loc = -1;
            double maxrate = 0;
            for (int i = 0; i < 4; i++)
            {
                double tmp = CompareFunc.CompareString(msg, wd.refers[i]);
                if (tmp > maxrate)
                {
                    loc = i;
                    maxrate = tmp;
                }
            }
            if (loc == -1)
            {
                Speak("抱歉我没有听清楚，请再说一遍吧");
            }
            else
            {
                cur = wd.refers[loc];
            }
            judgeReturn(loc);
        }
        private void judgeReturn(int i)
        {
            switch (i)
            {
                case -1:
                    Speak(wd.speaks[0]);
                    cur = wd.speaks[0];
                    Recognition();
                    break;
                case 0:
                    Speak(wd.speaks[1]);
                    cur = wd.speaks[1];
                    Recognition();
                    break;
                case 1:
                    Speak(wd.speaks[1]);
                    cur = wd.speaks[1];
                    Recognition();
                    break;
                case 2:
                    Speak(wd.speaks[2]);
                    cur = wd.speaks[2];
                    Recognition();
                    break;
                case 3:
                    Speak(wd.speaks[7]);
                    cur = wd.speaks[7];
                    break;

            }
        }
        private void Recognition()
        {
            SpRecognition sp;
            sp = SpRecognition.instance();
            sp.SetMessage += ShowMessage;
            //while (t.IsAlive) ;
            flag = false;
            sp.BeginRec();
        }
    }
    #endregion
}