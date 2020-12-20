using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    public class SkillObject : IJsonFileObjectDictionaryExt
    {
        public Dictionary<string, Skill> Skills = new Dictionary<string, Skill>();

        public IDictionary GetDictionary()
        {
            return Skills;
        }

        public Type GetSubType()
        {
            return typeof(Skill);
        }
    }
    public class Skill
    {
        public string skillId { get; set; }
        public object iconId { get; set; }
        public bool hidden { get; set; }
        public SkillLevel[] levels { get; set; }
    }

    public class SkillLevel
    {
        public string name { get; set; }
        public object rangeId { get; set; }
        public string description { get; set; }
        public int skillType { get; set; }
        public CharacterSpdata spData { get; set; }
        public string prefabId { get; set; }
        public float duration { get; set; }
        public Blackboard[] blackboard { get; set; }
    }

    public class CharacterSpdata
    {
        public int spType { get; set; }
        public object levelUpCost { get; set; }
        public int maxChargeTime { get; set; }
        public int spCost { get; set; }
        public int initSp { get; set; }
        public float increment { get; set; }
    }
}
