using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Grid
    {
        private static readonly Dictionary<Coord, string> DirectionNames = new Dictionary<Coord, string>()
        {
            { new Coord(0, 1), Direction.North },
            { new Coord(0, -1) , Direction.South },
            { new Coord(1, 0) , Direction.East },
            { new Coord(-1, 0) , Direction.West }
        };
        private static readonly Coord[] DirectionCoords = [.. DirectionNames.Keys];
        private readonly List<Obstacle> obstacles;
        private readonly Dictionary<Coord, char> memo;
        public Grid()
        {
            obstacles = [];
            memo = [];
        }
        public void AddObstacle(Obstacle obstacle)
        {
            obstacles.Add(obstacle);
        }
        public void Check(int targetX, int targetY)
        {
            // The location is not safe
            if (HitObstacleAt(targetX, targetY))
            {
                Console.WriteLine(ErrorMessages.UnsafeCoord);
                return;
            }

            // The location is safe, get safe directions
            var safeDirections = new List<string>();
            foreach (KeyValuePair<Coord, string> direction in DirectionNames)
            {
                string directionName = direction.Value;
                int directionX = direction.Key.X;
                int directionY = direction.Key.Y;

                if (!HitObstacleAt(targetX + directionX, targetY + directionY))
                {
                    safeDirections.Add(directionName);
                }
            }

            // There are no safe directions
            if (safeDirections.Count == 0)
            {
                Console.WriteLine(ErrorMessages.NoSafeDirections);
                return;
            }

            // There is at least one safe direction
            Console.WriteLine(SuccessMessages.SafeDirections);
            foreach (string direction in safeDirections)
            {
                Console.WriteLine(SuccessMessages.CapitaliseFirstLetter(direction));
            }
        }
        public void Check(string[] args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.CheckArgsLength);

            string strTargetX = args[IntConstants.CheckTargetXIdx];
            string strTargetY = args[IntConstants.CheckTargetYIdx];

            if (!int.TryParse(strTargetX, out int targetX) || !int.TryParse(strTargetY, out int targetY))
            {
                throw new IntArgumentException(ErrorMessages.InvalidCoord);
            }

            Check(targetX, targetY);
        }
        public void Map(int leftBorderX, int bottomBorderY, int width, int height)
        {
            Console.WriteLine(SuccessMessages.SelectedRegion);

            int topBorderY = bottomBorderY + height - 1;
            int rightBorderX = leftBorderX + width;
            for (int y = topBorderY; y >= bottomBorderY; y--)
            {
                for (int x = leftBorderX; x < rightBorderX; x++)
                {
                    Console.Write(GetCharAt(x, y));
                }
                Console.WriteLine();
            }
        }
        public void Map(string[] args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.MapArgsLength);

            string strLeftBorderX = args[IntConstants.MapLeftBorderXIdx];
            string strbottomBorderY = args[IntConstants.MapBottomBorderYIdx];
            string strWidth = args[IntConstants.MapWidthIdx];
            string strHeight = args[IntConstants.MapHeightIdx];

            if (!int.TryParse(strLeftBorderX, out int leftBorderX) || !int.TryParse(strbottomBorderY, out int bottomBorderY))
            {
                throw new IntArgumentException(ErrorMessages.InvalidCoord);
            }

            if (!int.TryParse(strWidth, out int width) || !int.TryParse(strHeight, out int height) || width <= 0 || height <= 0)
            {
                throw new IntArgumentException(ErrorMessages.InvalidMapDimensions);
            }

            Map(leftBorderX, bottomBorderY, width, height);
        }
        public void Path(int startX, int startY, int endX, int endY)
        {
            // Same coords
            if (startX == endX && startY == endY)
            {
                Console.WriteLine(ErrorMessages.SameCoords);
                return;
            }

            // End is obstructed
            if (HitObstacleAt(endX, endY))
            {
                Console.WriteLine(ErrorMessages.GoalObstructed);
                return;
            }

            Coord[] path = AStarBidirectional(startX, startY, endX, endY);

            // No safe path
            if (path.Length == 0)
            {
                Console.WriteLine(ErrorMessages.NoSafePath);
                return;
            }

            // There is a safe path
            Console.WriteLine(SuccessMessages.ThereIsSafePath);
            int repeatedDirectionsCount = 0;
            string prevDirection = DirectionNames[path[1] - path[0]];
            for (int i = 1; i < path.Length; i++)
            {
                Coord currentCoord = path[i];
                Coord prevCoord = path[i - 1];
                string direction = DirectionNames[currentCoord - prevCoord];
                if (direction == prevDirection)
                {
                    repeatedDirectionsCount++;
                }
                else
                {
                    SuccessMessages.PrintMovement(prevDirection, repeatedDirectionsCount);
                    prevDirection = direction;
                    repeatedDirectionsCount = 1;
                }
            }
            SuccessMessages.PrintMovement(prevDirection, repeatedDirectionsCount);
        }
        public void Path(string[] args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.PathArgsLength);

            string strStartX = args[IntConstants.StartXIdx];
            string strStartY = args[IntConstants.StartYIdx];
            string strEndX = args[IntConstants.EndXIdx];
            string strEndY = args[IntConstants.EndYIdx]; 

            if (!int.TryParse(strStartX, out int startX) || !int.TryParse(strStartY, out int startY))
            {
                throw new IntArgumentException(ErrorMessages.InvalidAgentCoord);
            }

            if (!int.TryParse(strEndX, out int endX) || !int.TryParse(strEndY, out int endY))
            {
                throw new IntArgumentException(ErrorMessages.InvalidObjectiveCoord);
            }

            Path(startX, startY, endX, endY);
        }
        private bool HitObstacleAt(int targetX, int targetY)
        {
            return GetCharAt(targetX, targetY) != ObstacleConstants.EmptyChar;
        }
        private bool HitObstacleAt(Coord target)
        {
            return HitObstacleAt(target.X, target.Y);
        }
        private char GetCharAt(int targetX, int targetY)
        {
            var target = new Coord(targetX, targetY);

            if (memo.TryGetValue(target, out char charRep))
            {
                return charRep;
            }

            foreach(Obstacle obstacle in obstacles)
            {
                if (obstacle.HitObstacle(targetX, targetY))
                {
                    memo[target] = obstacle.CharRep;
                    return obstacle.CharRep;
                }
            }
            return ObstacleConstants.EmptyChar;
        }
        private Coord[] AStarBidirectional(int startX, int startY, int endX, int endY)
        {
            return AStarBidirectional(new Coord(startX, startY), new Coord(endX, endY));
        }
        private Coord[] AStarBidirectional(Coord start, Coord end)
        {
            // These priority queues when enqueued prioritises the lowest fCost and hCost
            var openA = new PriorityQueue<Coord, Tuple<int, int>>();
            var openB = new PriorityQueue<Coord, Tuple<int, int>>();

            // The initial hCost is just the manhattan distance between start and end,
            // and the manhattan distance between the end and start is also the same.
            // And their fCosts are also the same as the hCost, because the gCosts are 0.
            int initialOpenHCost = ManhattanDistance(start, end);
            openA.Enqueue(start, new Tuple<int, int>(initialOpenHCost, initialOpenHCost));
            openB.Enqueue(end, new Tuple<int, int>(initialOpenHCost, initialOpenHCost));

            var gCostsA = new Dictionary<Coord, int>();
            var gCostsB = new Dictionary<Coord, int>();
            gCostsA[start] = 0;
            gCostsB[end] = 0;

            var cameFromA = new Dictionary<Coord, Coord>();
            var cameFromB = new Dictionary<Coord, Coord>();

            bool foundPath = false;
            var coordIntersect = new Coord();
            while (openA.Count > 0 && openB.Count > 0)
            {
                var currentNodeA = openA.Dequeue();
                var currentNodeB = openB.Dequeue();

                if (gCostsA.ContainsKey(currentNodeB) || gCostsB.ContainsKey(currentNodeA))
                {
                    foundPath = true;
                    coordIntersect = gCostsB.ContainsKey(currentNodeA) ? currentNodeA : currentNodeB;
                    break;
                }

                Expand(currentNodeA, end, ref openA, ref gCostsA, ref cameFromA);
                Expand(currentNodeB, start, ref openB, ref gCostsB, ref cameFromB);
            }

            if (!foundPath) return [];

            // Constructing the path
            List<Coord> startToIntersect = ConstructPath(coordIntersect, start, cameFromA, true); 
            if (startToIntersect[^1] == end) return [.. startToIntersect]; // This only happens when the path is only a single step
            List<Coord> intersectToEnd = ConstructPath(cameFromB[coordIntersect], end, cameFromB);
            return [.. startToIntersect, .. intersectToEnd];
        }
        private void Expand(Coord currentCoord, Coord endCoord, ref PriorityQueue<Coord, Tuple<int, int>> openSet, ref Dictionary<Coord, int> gCosts, ref Dictionary<Coord, Coord> cameFrom)
        {
            foreach (Coord direction in DirectionCoords)
            {
                Coord neighbour = currentCoord + direction;

                if (HitObstacleAt(neighbour))
                {
                    continue;
                }

                int tentativeGCost = gCosts[currentCoord] + 1;
                if (!gCosts.TryGetValue(neighbour, out int gCostNeighbour) || tentativeGCost < gCostNeighbour)
                {
                    gCosts[neighbour] = tentativeGCost;
                    int hCost = ManhattanDistance(neighbour, endCoord);
                    int fCost = tentativeGCost + hCost;

                    openSet.Enqueue(neighbour, new Tuple<int, int>(fCost, hCost));
                    cameFrom[neighbour] = currentCoord;
                }
            }
        }
        private static List<Coord> ConstructPath(Coord from, Coord to, Dictionary<Coord, Coord> cameFrom, bool reverse=false)
        {
            List<Coord> path = [];
            Coord coordIterator = from;
            while (coordIterator != to)
            {
                path.Add(coordIterator);
                coordIterator = cameFrom[coordIterator];
            }
            path.Add(to);
            if (reverse) path.Reverse();
            return path;
        }
        private static int ManhattanDistance(Coord start, Coord end)
        {
            return Math.Abs((start - end).X) + Math.Abs((start - end).Y);
        }
    }
}
