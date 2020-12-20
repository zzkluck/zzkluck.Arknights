using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

using Zzkluck.Arknights.Library.AkdataObject;
namespace Zzkluck.Arknights.Library.Map
{
    public class RouteAnalyser
    {
        private Route _route;
        public RouteAnalyser(Route route)
        {
            if (route == null)
            {
                throw new ArgumentNullException("TODO: ");
            }
            this._route = route;
            if (_route.motionMode == 0)
            {
                Assert(_route.startPosition != null);
                _checkPoints.Add(_route.startPosition);
                foreach (var cp in _route.checkpoints)
                {
                    if (cp.type == 0
                        && cp.time == 0d
                        && cp.randomizeReachOffset == false
                        && cp.reachDistance == 0d
                        && cp.reachOffset == PositionOffset.Zero)
                    {
                        _checkPoints.Add(cp.position);
                    }
                    else
                    {
                        throw new NotImplementedException("Checkpoint Type Not Support");
                    }
                }
                Assert(_route.endPosition != null);
                _checkPoints.Add(_route.endPosition);
                Assert(_checkPoints.Count >= 2);
                _distances = new List<double>(new double[_checkPoints.Count]);
                Assert(_distances[0] == 0);
                for (int i = 1; i < _checkPoints.Count; i++)
                {
                    _distances[i] = (_checkPoints[i] - _checkPoints[i - 1]).Mod() + _distances[i - 1];
                }
            }
            else
            {
                throw new NotImplementedException("MotionMode Not Support.");
            }

        }
        private readonly List<Position> _checkPoints = new List<Position>();
        private readonly List<double> _distances;

        public Position this[double disFromStart]
        {
            get
            {
                if (!(_route.allowDiagonalMove == true 
                    && _route.visitEveryNodeCenter == false 
                    && _route.visitEveryTileCenter == false))
                {
                    throw new NotImplementedException();
                }
                if (disFromStart < 0)
                {
                    throw new ArgumentOutOfRangeException("distanceFromStart should be a POSITIVE number");
                }
                if (disFromStart == 0)
                {
                    return this._route.startPosition;
                }
                Assert(_distances[0] == 0);
                int nextCP = _distances.FindIndex(d => d > disFromStart);
                if (nextCP == -1)
                {
                    return _route.endPosition;
                }
                else
                {
                    Position previousP = _checkPoints[nextCP - 1];
                    double perviousD = _distances[nextCP - 1];
                    Position nextP = _checkPoints[nextCP];
                    double nextD = _distances[nextCP];

                    double scale = (disFromStart - perviousD) / (nextD - perviousD);
                    Position r = previousP + scale * (nextP - previousP);
                    return r;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _checkPoints)
            {
                sb.AppendFormat("{0} -> ", item.ToString());
            }
            if (sb.Length != 0)
            {
                sb.Remove(sb.Length - 4, 4);
            }
            return sb.ToString();
        }

    }
}
