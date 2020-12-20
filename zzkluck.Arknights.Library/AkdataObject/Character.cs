using System;
using System.Collections.Generic;
using System.Linq;

using static System.Diagnostics.Debug;
using static zzkluck.Tools.Algorithm;
using Zzkluck.Arknights.Library.AkdataObject;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    public class Character
    {
        #region Properties
        /// <summary>
        /// 干员代号
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 特性描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否能使用通用信物
        /// </summary>
        public bool CanUseGeneralPotentialItem { get; set; }
        /// <summary>
        /// 信物编号
        /// </summary>
        public string PotentialItemId { get; set; }
        /// <summary>
        /// 小队编号
        /// </summary>
        public int Team { get; set; }
        /// <summary>
        /// 干员编号
        /// </summary>
        public string DisplayNumber { get; set; }
        /// <summary>
        /// ？？？？
        /// </summary>
        public object TokenKey { get; set; }
        /// <summary>
        /// 代号
        /// </summary>
        public string Appellation { get; set; }
        /// <summary>
        /// 部署位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// TAG
        /// </summary>
        public string[] TagList { get; set; }
        public string DisplayLogo { get; set; }
        /// <summary>
        /// 信物说明
        /// </summary>
        public string ItemUsage { get; set; }
        /// <summary>
        /// 信物说明2
        /// </summary>
        public string ItemDesc { get; set; }
        /// <summary>
        /// 信物获取途径
        /// </summary>
        public string ItemObtainApproach { get; set; }
        /// <summary>
        /// 最大潜能等级
        /// </summary>
        public int MaxPotentialLevel { get; set; }
        /// <summary>
        /// 稀有度
        /// </summary>
        public int Rarity { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string Profession { get; set; }
        public object Trait { get; set; }
        /// <summary>
        /// 精英化阶段信息
        /// </summary>
        public Phase[] Phases { get; set; }
        public CharacterSkill[] Skills { get; set; }
        public Talent[] Talents { get; set; }
        public Potentialrank[] PotentialRanks { get; set; }
        public Favorkeyframe[] FavorKeyFrames { get; set; }
        public Allskilllvlup[] AllSkillLvlup { get; set; }

        #endregion

        private static List<string> attributesName
            = typeof(CharacterAttributes).GetProperties().Select(finfo => finfo.Name.ToLowerInvariant()).ToList();
        private static Dictionary<int, string> attributeType = new Dictionary<int, string>
        { {0,"maxHp"},{1,"atk"},{2,"def"},{3,"magicResistance" },{4,"cost"},{7,"attackSpeed" },{21,"respawnTime" } };

        private Dictionary<string, double> _favor = new Dictionary<string, double>
        {
            {"atk",0 },{"def",0},{ "maxHp",0}
        };
        private Dictionary<string, double> _potent = new Dictionary<string, double>
        {
            {"atk",0 },{"def",0},{ "maxHp",0},{"cost",0},{"attackSpeed",0},{"respawnTime",0},{"magicResistance",0}
        };
        private Dictionary<string, double> _talent = new Dictionary<string, double>
        {
            {"atk",0 },{"def",0},{ "maxHp",0},{"cost",0},{"attackSpeed",0},{"respawnTime",0},{"magicResistance",0},
            {"sp_recovery_per_sec",0},{"baseAttackTime", 0},{"hp_recovery_per_sec",0}
        };

        private void DealAdditionalAttributes()
        {
            // 处理信赖加成
            if (FavorKeyFrames != null)
            {
                _favor["maxHp"] = FavorKeyFrames[1].Data.MaxHp;
                _favor["atk"] = FavorKeyFrames[1].Data.Atk;
                _favor["def"] = FavorKeyFrames[1].Data.Def;
            }

            //处理潜能加成
            if (PotentialRanks != null)
            {
                foreach (var potent in PotentialRanks)
                {
                    if (potent.Type == 0)
                    {
                        int attributeTypeInt = potent.Buff.Attributes.AttributeModifiers[0].AttributeType;
                        if (attributeType.TryGetValue(attributeTypeInt, out string attributeTypeString) == false)
                        {
                            throw new Exception(attributeTypeInt.ToString());
                        }
                        double value = potent.Buff.Attributes.AttributeModifiers[0].Value;
                        _potent[attributeTypeString] += value;
                    }
                }
            }

            //处理天赋加成
            //TODO: deal talent
        }

        public (double maxHp, double atk, double def)
    GetAttributesByLevel(int phase, int level)
        {
            //TODO: ADD TEST
            var phasesInfo = Phases[phase];
            Assert(level > 0);
            level = (level >= phasesInfo.MaxLevel) ? phasesInfo.MaxLevel : level;
            Assert(phasesInfo.AttributesKeyFrames.Length == 2);
            var phaseMinAttributes = phasesInfo.AttributesKeyFrames[0].Data;
            var phaseMaxAttributes = phasesInfo.AttributesKeyFrames[1].Data;
            return (maxHp: InsertValue(1, phasesInfo.MaxLevel, level, phaseMinAttributes.MaxHp, phaseMaxAttributes.MaxHp),
                atk: InsertValue(1, phasesInfo.MaxLevel, level, phaseMinAttributes.Atk, phaseMaxAttributes.Atk),
                def: InsertValue(1, phasesInfo.MaxLevel, level, phaseMinAttributes.Def, phaseMaxAttributes.Def));
        }
    }
}
