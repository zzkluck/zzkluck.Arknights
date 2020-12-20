using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using Zzkluck.Arknights.Library.AkdataObject;

namespace Zzkluck.Arknights.Library
{
    public class LevelInfo : IEquatable<LevelInfo>
    {
        public string levelType;
        public string levelNo;

        public bool Equals(LevelInfo other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.levelType == other.levelType &&
                    this.levelNo == other.levelNo;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as LevelInfo);
        }
        public override int GetHashCode()
        {
            return levelType.GetHashCode() ^ levelNo.GetHashCode();
        }
    }
    public partial class ArkDataManager
    {
        //temp
        private readonly List<EnemyInfo> _enemyDatas;
        public readonly Dictionary<LevelInfo, LevelObject> _levelDatas;
        private readonly Dictionary<string, Character> _charDatas;
        private readonly Dictionary<string, Skill> _skillDatas;

        private static readonly Regex _levelNameRegex = new Regex
            (@"(?:level_)?(?<levelType>\w+)[_](?<levelNo_main>\d+(?:\-\d+)?(?:\-\d)?)(?:\.json)?");
        public ArkDataManager(string enemyDataPath, string levelDataDirectory, string charDataPath, string skillDataPath)
        {
            _enemyDatas = new List<EnemyInfo>();
            _levelDatas = new Dictionary<LevelInfo, LevelObject>();
            LoadEnemyDatabase(enemyDataPath);
            LoadLevels(levelDataDirectory);
            _charDatas = JsonFileObjectParser.Parse<CharacterObject>(File.ReadAllText(charDataPath)).Characters;
            _skillDatas = JsonFileObjectParser.Parse<SkillObject>(File.ReadAllText(skillDataPath)).Skills;
        }
        #region Private
        private void LoadEnemyDatabase(string path)
        {
            EnemyDatabaseObject edo = JsonFileObjectParser.Parse<EnemyDatabaseObject>(File.ReadAllText(path));
            foreach (var enemy in edo.Enemies)
            {
                EnemyData baseData = enemy.Value.First(levelInfo => levelInfo.Level == 0).EnemyData;
                foreach (var levelInfo in enemy.Value)
                {
                    if (levelInfo.Level == 0)
                    {
                        _enemyDatas.Add(levelInfo);
                    }
                    else
                    {
                        _enemyDatas.Add(new EnemyInfo()
                        {
                            Level = levelInfo.Level,
                            EnemyData = levelInfo.EnemyData.OverWriteTo(baseData)
                        });
                    }
                }
            }
        }
        private void LoadLevels(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    string fileName = file.Substring(file.LastIndexOf('\\') + 1);
                    var matchInfo = _levelNameRegex.Match(fileName);
                    if (matchInfo.Success)
                    {
                        LevelObject lo = JsonFileObjectParser.Parse<LevelObject>(File.ReadAllText(file));
                        _levelDatas.Add(GetLevelInfo(matchInfo), lo);
                    }
                }
            }
            else
            {
                throw new NotImplementedException("loadlevels的参数应该是一个文件夹");
            }
        }
        private LevelInfo GetLevelInfo(Match matchInfo)
        {
            return new LevelInfo()
            {
                levelType = matchInfo.Groups[1].Value,
                levelNo = matchInfo.Groups[2].Value
            };
        }
        #endregion

        public EnemyData FindEnemy(string prefabKey, int level)
        {
            return _enemyDatas.Find(e => e.EnemyData.prefabKey.m_value == prefabKey && e.Level == level).EnemyData;
        }
        public EnemyData[] GetEnemyDataByLevel(string levelName, Regex r = null)
        {
            EnemyData[] result = null;

            r = r ?? _levelNameRegex;
            Match match = r.Match(levelName);
            if (match.Success)
            {
                var levelInfo = GetLevelInfo(match);
                result = GetEnemyDataByLevel(levelInfo);
            }
            return result;
        }
        public EnemyData[] GetEnemyDataByLevel(LevelInfo levelInfo)
        {
            return GetEnemyDataByLevel(_levelDatas[levelInfo]);

        }
        public EnemyData[] GetEnemyDataByLevel(LevelObject levelObject)
        {
            var levelEnemy = levelObject.enemyDbRefs;
            EnemyData[] result = new EnemyData[levelEnemy.Length];
            for (int i = 0; i < result.Length; i++)
            {
                var standardEnemy = FindEnemy(levelEnemy[i].id, levelEnemy[i].level);
                if (levelEnemy[i].overwrittenData == null)
                {
                    result[i] = standardEnemy;
                }
                else
                {
                    result[i] = levelEnemy[i].overwrittenData.OverWriteTo(standardEnemy);
                }
            }
            return result;
        }
        public List<string> GetLevelInfo()
        {
            return _levelDatas.Keys.Select(k => k.levelType).Distinct().ToList();
        }
    }
}
