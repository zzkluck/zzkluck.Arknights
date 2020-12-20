namespace Zzkluck.Arknights.Library.AkdataObject
{
    public class EnemyData
    {
        // 不要手动创建任何以下属性的实例，确保它们的所有实例都来自于JSON文件的反序列化
        // 用其他引用指向这些反序列化的对象，避免在内存中创建过多不必要的东西
        public Definedable<string> Name { get; set; }
        public Definedable<string> description { get; set; }
        public Definedable<string> prefabKey { get; set; }
        public EnemyAttributes attributes { get; set; }
        public Definedable<int> lifePointReduce { get; set; }
        public Definedable<float> rangeRadius { get; set; }
        public Blackboard[] talentBlackboard { get; set; }
        public EnemySkill[] skills { get; set; }
        public EnemySpdata spData { get; set; }

        /// <summary>
        /// 将当前对象的特定属性复写到<paramref name="basedata"/>
        /// </summary>
        /// <param name="basedata">将被复写的<c>Enemydata</c></param>
        /// <param name="replace">决定是在当前实例上进行修改，还是返回一个全新的对象</param>
        /// <remarks><paramref name="replace"/>会很大程度地改变函数的行为，说实话这不是一个太好的设计，不过，who care</remarks>
        /// <returns>返回被复写后的实例</returns>
        public EnemyData OverWriteTo(EnemyData basedata, bool replace = false)
        {
            EnemyData r = replace ? this : new EnemyData();
            #region 一段令人生畏的代码
            r.Name = this.Name.m_defined ? this.Name : basedata.Name;
            r.description = this.description.m_defined ? this.description : basedata.description;
            r.prefabKey = this.prefabKey.m_defined ? this.prefabKey : basedata.prefabKey;
            r.lifePointReduce = this.lifePointReduce.m_defined ? this.lifePointReduce : basedata.lifePointReduce;
            r.rangeRadius = this.rangeRadius.m_defined ? this.rangeRadius : basedata.rangeRadius;

            r.talentBlackboard = this.talentBlackboard ?? basedata.talentBlackboard;
            r.skills = this.skills ?? basedata.skills;
            r.spData = this.spData ?? basedata.spData;

            r.attributes = replace ? r.attributes : new EnemyAttributes();
            r.attributes.MaxHp = this.attributes.MaxHp.m_defined ? this.attributes.MaxHp : basedata.attributes.MaxHp;
            r.attributes.Atk = this.attributes.Atk.m_defined ? this.attributes.Atk : basedata.attributes.Atk;
            r.attributes.Def = this.attributes.Def.m_defined ? this.attributes.Def : basedata.attributes.Def;
            r.attributes.MagicResistance = this.attributes.MagicResistance.m_defined ? this.attributes.MagicResistance : basedata.attributes.MagicResistance;
            r.attributes.Cost = this.attributes.Cost.m_defined ? this.attributes.Cost : basedata.attributes.Cost;
            r.attributes.BlockCnt = this.attributes.BlockCnt.m_defined ? this.attributes.BlockCnt : basedata.attributes.BlockCnt;
            r.attributes.MoveSpeed = this.attributes.MoveSpeed.m_defined ? this.attributes.MoveSpeed : basedata.attributes.MoveSpeed;
            r.attributes.AttackSpeed = this.attributes.AttackSpeed.m_defined ? this.attributes.AttackSpeed : basedata.attributes.AttackSpeed;
            r.attributes.BaseAttackTime = this.attributes.BaseAttackTime.m_defined ? this.attributes.BaseAttackTime : basedata.attributes.BaseAttackTime;
            r.attributes.RespawnTime = this.attributes.RespawnTime.m_defined ? this.attributes.RespawnTime : basedata.attributes.RespawnTime;
            r.attributes.HpRecoveryPerSec = this.attributes.HpRecoveryPerSec.m_defined ? this.attributes.HpRecoveryPerSec : basedata.attributes.HpRecoveryPerSec;
            r.attributes.SpRecoveryPerSec = this.attributes.SpRecoveryPerSec.m_defined ? this.attributes.SpRecoveryPerSec : basedata.attributes.SpRecoveryPerSec;
            r.attributes.MaxDeployCount = this.attributes.MaxDeployCount.m_defined ? this.attributes.MaxDeployCount : basedata.attributes.MaxDeployCount;
            r.attributes.MassLevel = this.attributes.MassLevel.m_defined ? this.attributes.MassLevel : basedata.attributes.MassLevel;
            r.attributes.BaseForceLevel = this.attributes.BaseForceLevel.m_defined ? this.attributes.BaseForceLevel : basedata.attributes.BaseForceLevel;
            r.attributes.StunImmune = this.attributes.StunImmune.m_defined ? this.attributes.StunImmune : basedata.attributes.StunImmune;
            r.attributes.SilenceImmune = this.attributes.SilenceImmune.m_defined ? this.attributes.SilenceImmune : basedata.attributes.SilenceImmune;
            #endregion
            #region 幸运的是，这些代码是生成的
            //string sampleOutputPath = @"C:\Users\zzklu\Desktop\1.txt";
            //StreamWriter streamWriter = new StreamWriter(sampleOutputPath);
            //Console.SetOut(streamWriter);
            //string[] specialProperties = { "talentBlackboard", "skills", "spData" };
            //foreach (var pInfo in typeof(Enemydata).GetProperties().Where(p => p.Name != "attributes" && !specialProperties.Contains(p.Name)))
            //{
            //    Console.WriteLine($"r.{pInfo.Name} = this.{pInfo.Name}.m_defined ? this.{pInfo.Name} : basedata.{pInfo.Name};");
            //}
            //Console.WriteLine();
            //foreach (var pInfo in typeof(Enemydata).GetProperties().Where(p => specialProperties.Contains(p.Name)))
            //{
            //    Console.WriteLine($"r.{pInfo.Name} = this.{pInfo.Name} ?? basedata.{pInfo.Name};");
            //}
            //Console.WriteLine();
            //foreach (var pInfo in typeof(Attributes).GetProperties())
            //{
            //    Console.WriteLine
            //        ($"r.attributes.{pInfo.Name} = this.attributes.{pInfo.Name}.m_defined ? this.attributes.{pInfo.Name} : basedata.attributes.{pInfo.Name};");
            //}
            //Console.Beep();
            //streamWriter.Close();
            //Console.ReadLine();
            #endregion
            return r;
        }

        //TODO: 应该用一个formatter来做这件事
        private static string _format = "{0} {1,-7} {2,-7} {3,-7} {4,-7} {5,-7} {6,-7} {7,-7}";
        private static string[] _header = { "名称", "生命", "攻击", "防御", "魔抗", "攻击间隔", "攻击范围", "重量" };
        public static string Header = string.Format(_format, _header);
        public override string ToString()
        {
            return string.Format(EnemyData._format,
                Name.m_value.PadRight(20-Name.m_value.Length),
                attributes.MaxHp.m_value,
                attributes.Atk.m_value,
                attributes.Def.m_value,
                attributes.MagicResistance.m_value,
                attributes.BaseAttackTime.m_value,
                rangeRadius.m_defined ? rangeRadius.m_value.ToString() : "melee",
                attributes.MassLevel.m_value);
        }
    }

}
