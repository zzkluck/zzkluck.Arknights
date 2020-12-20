using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    public class LevelObject : IJsonFileObject
    {
        public Options options { get; set; }
        public object levelId { get; set; }
        public object mapId { get; set; }
        public string bgmEvent { get; set; }
        public Mapdata mapData { get; set; }
        public object[] tilesDisallowToLocate { get; set; }
        public Rune[] runes { get; set; }
        public object[] globalBuffs { get; set; }
        public Route[] routes { get; set; }
        public object[] enemies { get; set; }
        public Enemydbref[] enemyDbRefs { get; set; }
        public Wave[] waves { get; set; }
        public object branches { get; set; }
        public Predefines predefines { get; set; }
        public object excludeCharIdList { get; set; }
        public int randomSeed { get; set; }
    }

    public class Options
    {
        public int characterLimit { get; set; }
        public int maxLifePoint { get; set; }
        public int initialCost { get; set; }
        public int maxCost { get; set; }
        public float costIncreaseTime { get; set; }
        public float moveMultiplier { get; set; }
        public bool steeringEnabled { get; set; }
        public bool isTrainingLevel { get; set; }
        public int functionDisableMask { get; set; }
    }

    public class Mapdata
    {
        public int[][] map { get; set; }
        public Tile[] tiles { get; set; }
        public object blockEdges { get; set; }
        public object effects { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Tile
    {
        public string tileKey { get; set; }
        public int heightType { get; set; }
        public int buildableType { get; set; }
        public int passableMask { get; set; }
        public object blackboard { get; set; }
        public object effects { get; set; }


    }

    public class Predefines
    {
        public object[] characterInsts { get; set; }
        public object[] tokenInsts { get; set; }
        public object[] characterCards { get; set; }
        public object[] tokenCards { get; set; }
    }

    public class Rune
    {
        public string key { get; set; }
        public int difficultyMask { get; set; }
        public int professionMask { get; set; }
        public int buildableMask { get; set; }
        public Blackboard[] blackboard { get; set; }
    }

    public class Route : ITestJsonObject
    {
        public int motionMode { get; set; }
        public Position startPosition { get; set; }
        public Position endPosition { get; set; }
        public PositionOffset spawnRandomRange { get; set; }
        public PositionOffset spawnOffset { get; set; }
        public Checkpoint[] checkpoints { get; set; }
        public bool allowDiagonalMove { get; set; }
        public bool visitEveryTileCenter { get; set; }
        public bool visitEveryNodeCenter { get; set; }
    }

    public class Checkpoint
    {
        public int type { get; set; }
        public float time { get; set; }
        public Position position { get; set; }
        public PositionOffset reachOffset { get; set; }
        public bool randomizeReachOffset { get; set; }
        public float reachDistance { get; set; }
    }

    public class Position
    {
        public double row { get; set; }
        public double col { get; set; }
        public static Position operator +(Position x, Position y)
        {
            return new Position { col = x.col + y.col, row = x.row + y.row };
        }
        public static Position operator -(Position x, Position y)
        {
            return new Position { col = x.col - y.col, row = x.row - y.row };
        }
        public static Position operator *(Position x, double scale)
        {
            return new Position { col = x.col * scale, row = x.row * scale };
        }
        public static Position operator *(double scale, Position x)
        {
            return x * scale;
        }
        public double Mod()
        {
            return Math.Sqrt(Math.Pow(row, 2) + Math.Pow(col, 2));
        }
        public override string ToString()
        {
            return $"({row}, {col})";
        }
    }

    public class PositionOffset : IEquatable<PositionOffset>
    {
        public float x { get; set; }
        public float y { get; set; }

        public static PositionOffset Zero = new PositionOffset { x = 0f, y = 0f };

        public bool Equals(PositionOffset other)
        {
            return this == other;
        }
        public static bool operator ==(PositionOffset p0, PositionOffset p1) => p0.x == p1.x && p0.y == p1.y;
        public static bool operator !=(PositionOffset p0, PositionOffset p1) => !(p0 == p1);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || (obj as PositionOffset == null))
            {
                return false;
            }

            return this == obj as PositionOffset;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }

    public class Enemydbref
    {
        public bool useDb { get; set; }
        public string id { get; set; }
        public int level { get; set; }
        public EnemyData overwrittenData { get; set; }
    }

    public class Wave
    {
        public float preDelay { get; set; }
        public float postDelay { get; set; }
        public float maxTimeWaitingForNextWave { get; set; }
        public Fragment[] fragments { get; set; }
        public object name { get; set; }
    }

    public class Fragment
    {
        public float preDelay { get; set; }
        public Action[] actions { get; set; }
        public object name { get; set; }
    }

    public class Action
    {
        public int actionType { get; set; }
        public bool managedByScheduler { get; set; }
        public string key { get; set; }
        public int count { get; set; }
        public float preDelay { get; set; }
        public float interval { get; set; }
        public int routeIndex { get; set; }
        public bool blockFragment { get; set; }
        public bool autoPreviewRoute { get; set; }
        public bool isUnharmfulAndAlwaysCountAsKilled { get; set; }
    }

}
