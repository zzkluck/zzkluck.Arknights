using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    [Serializable]
    public class CharacterObject :
        IJsonFileObjectDictionaryExt 
    {
        public Dictionary<string, Character> Characters = new Dictionary<string, Character>();

        public IDictionary GetDictionary()
        {
            return Characters;
        }

        public Type GetSubType()
        {
            return typeof(Character);
        }
    }

    public class Phase
    {
        public string CharacterPrefabKey { get; set; }
        public string RangeId { get; set; }
        public int MaxLevel { get; set; }
        public Attributeskeyframe[] AttributesKeyFrames { get; set; }
        public Evolvecost[] EvolveCost { get; set; }
    }

    public class Attributeskeyframe
    {
        public int Level { get; set; }
        public CharacterAttributes Data { get; set; }
    }

    public class CharacterAttributes
    {
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public float MagicResistance { get; set; }
        public int Cost { get; set; }
        public int BlockCnt { get; set; }
        public float MoveSpeed { get; set; }
        public float AttackSpeed { get; set; }
        public float BaseAttackTime { get; set; }
        public int RespawnTime { get; set; }
        public float HpRecoveryPerSec { get; set; }
        public float SpRecoveryPerSec { get; set; }
        public int MaxDeployCount { get; set; }
        public int MaxDeckStackCnt { get; set; }
        public int TauntLevel { get; set; }
        public int MassLevel { get; set; }
        public int BaseForceLevel { get; set; }
        public bool StunImmune { get; set; }
        public bool SilenceImmune { get; set; }
    }

    public class Evolvecost
    {
        public string Id { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }

    public class CharacterSkill
    {
        public string SkillId { get; set; }
        public object OverridePrefabKey { get; set; }
        public object OverrideTokenKey { get; set; }
        public Levelupcostcond[] LevelUpCostCond { get; set; }
        public CharacterLevel UnlockCond { get; set; }
    }

    public class CharacterLevel
    {
        public int Phase { get; set; }
        public int Level { get; set; }
    }

    public class Levelupcostcond
    {
        public CharacterLevel UnlockCond { get; set; }
        public int LvlUpTime { get; set; }
        public Levelupcost[] LevelUpCost { get; set; }
    }

    public class Levelupcost
    {
        public string Id { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }

    public class Talent
    {
        public Candidate[] Candidates { get; set; }
    }

    public class Candidate
    {
        public CharacterLevel UnlockCondition { get; set; }
        public int RequiredPotentialRank { get; set; }
        public string PrefabKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object RangeId { get; set; }
        public Blackboard[] Blackboard { get; set; }
    }

    public class Potentialrank
    {
        public int Type { get; set; }
        public string Description { get; set; }
        public Buff Buff { get; set; }
        public object EquivalentCost { get; set; }
    }

    public class Buff
    {
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
        public object AbnormalFlags { get; set; }
        public object AbnormalImmunes { get; set; }
        public object AbnormalCombos { get; set; }
        public object AbnormalComboImmunes { get; set; }
        public Attributemodifier[] AttributeModifiers { get; set; }
    }

    public class Attributemodifier
    {
        public int AttributeType { get; set; }
        public int FormulaItem { get; set; }
        public float Value { get; set; }
        public bool LoadFromBlackboard { get; set; }
        public bool FetchBaseValueFromSourceEntity { get; set; }
    }

    public class Favorkeyframe
    {
        public int Level { get; set; }
        public CharacterAttributes Data { get; set; }
    }
    public class Allskilllvlup
    {
        public CharacterLevel UnlockCond { get; set; }
        public Levelupcost[] LvlUpCost { get; set; }


    }
}
