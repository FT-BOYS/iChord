using SpeechLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice
{
    public class SpRecognition
    {
        private static SpRecognition _Instance = null;
        private SpeechLib.ISpeechRecoGrammar isrg;
        private SpeechLib.SpSharedRecoContext ssrContex = null;

        public delegate void StringEvent(string str);
        public StringEvent SetMessage;

        private SpRecognition()
        {
            ssrContex = new SpSharedRecoContext();
            isrg = ssrContex.CreateGrammar(1);
            SpeechLib._ISpeechRecoContextEvents_RecognitionEventHandler recHandle =
                 new _ISpeechRecoContextEvents_RecognitionEventHandler(ContexRecognition);
            ssrContex.Recognition += recHandle;
        }
        public void BeginRec()
        {
            isrg.DictationSetState(SpeechRuleState.SGDSActive);
        }
        public static SpRecognition instance()
        {
            if (_Instance == null)
                _Instance = new SpRecognition();
            return _Instance;
        }
        public void CloseRec()
        {
            isrg.DictationSetState(SpeechRuleState.SGDSInactive);
        }
        private void ContexRecognition(int iIndex, object obj, SpeechLib.SpeechRecognitionType type, SpeechLib.ISpeechRecoResult result)
        {
            if (SetMessage != null)
            {
                SetMessage(result.PhraseInfo.GetText(0, -1, true));
            }
        }
    }
}
