using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    public class HandbookObject : IJsonFileObjectDictionaryExt
    {
        public Dictionary<string, Handbook> Handbooks = new Dictionary<string, Handbook>();

        public IDictionary GetDictionary()
        {
            return Handbooks;
        }

        public Type GetSubType()
        {
            return typeof(Handbook);
        }
    }



    public class Handbook
    {
        public string charID { get; set; }
        public string drawName { get; set; }
        public string infoName { get; set; }
        public Storytextaudio[] storyTextAudio { get; set; }
        public object[] handbookAvgList { get; set; }
    }

    public class Storytextaudio
    {
        public Story[] stories { get; set; }
        public string storyTitle { get; set; }
        public bool unLockorNot { get; set; }
    }

    public class Story
    {
        public string storyText { get; set; }
        public int unLockType { get; set; }
        public string unLockParam { get; set; }
        public string unLockString { get; set; }
    }

}
