using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    public class EnemyDatabaseObject : IJsonFileObject
    {
        public Enemy[] Enemies { get; set; }
    }

    public class Enemy
    {
        public string Key { get; set; }
        public EnemyInfo[] Value { get; set; }
    }

    public class EnemyInfo
    {
        public int Level { get; set; }
        public EnemyData EnemyData { get; set; }
    }

    public class EnemyAttributes
    {
        public Definedable<int> MaxHp { get; set; }
        public Definedable<int> Atk { get; set; }
        public Definedable<int> Def { get; set; }
        public Definedable<float> MagicResistance { get; set; }
        public Definedable<int> Cost { get; set; }
        public Definedable<int> BlockCnt { get; set; }
        public Definedable<float> MoveSpeed { get; set; }
        public Definedable<float> AttackSpeed { get; set; }
        public Definedable<float> BaseAttackTime { get; set; }
        public Definedable<int> RespawnTime { get; set; }
        public Definedable<float> HpRecoveryPerSec { get; set; }
        public Definedable<float> SpRecoveryPerSec { get; set; }
        public Definedable<int> MaxDeployCount { get; set; }
        public Definedable<int> MassLevel { get; set; }
        public Definedable<int> BaseForceLevel { get; set; }
        public Definedable<bool> StunImmune { get; set; }
        public Definedable<bool> SilenceImmune { get; set; }
    }

    public class EnemySpdata
    {
        public int SpType { get; set; }
        public int MaxSp { get; set; }
        public int InitSp { get; set; }
        public float Increment { get; set; }
    }

    public class EnemySkill
    {
        public string PrefabKey { get; set; }
        public int Priority { get; set; }
        public float Cooldown { get; set; }
        public float InitCooldown { get; set; }
        public int SpCost { get; set; }
        public Blackboard[] Blackboard { get; set; }
    }



}
