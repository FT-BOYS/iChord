using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice
{
    class WordDictionaries
    {
        public string[] refers;
        public string[] speaks;
        public WordDictionaries()
        {
            dictionaryInit();
        }
        private void dictionaryInit()
        {
            speaks = new string[100];
            refers = new string[100];
            speaks[0] = "您好，欢迎使用本软件，请问您是第一次使用本软件吗？";
            speaks[1] = "那么您需要我们为您准备的新手教程么？";
            speaks[2] = "那么我们一起来完成一首曲子吧";
            speaks[3] = "首先请点击音符时值，选中1/2";
            speaks[4] = "很好，然后点击键盘音do";
            speaks[5] = "接下来请点击和弦编配按钮";
            speaks[6] = "接下来请点击播放";
            speaks[7] = "教程到此结束，请尽请享受您的音乐之旅";
            refers[0] = "是第一次使用";
            refers[1] = "不是的";
            refers[2] = "好的";
            refers[3] = "不需要";



        }
    }
}
