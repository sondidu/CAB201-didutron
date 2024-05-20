using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Grid
    {
        private readonly List<Obstacle> obstacles;
        private readonly Dictionary<Coord, char> memo;
        private static readonly Dictionary<Coord, string> DirectionNames = new Dictionary<Coord, string>()
        {
            { new Coord(0, 1), Direction.North },
            { new Coord(0, -1) , Direction.South },
            { new Coord(1, 0) , Direction.East },
            { new Coord(-1, 0) , Direction.West }
        };
        private static readonly Coord[] DirectionCoords = [.. DirectionNames.Keys];
        public Grid()
        {
            obstacles = [];
            memo = [];
        }
        public void AddObstacle(Obstacle obstacle)
        {
            obstacles.Add(obstacle);
        }
        public void Check(Coord target)
        {
            // The location is not safe
            if (HitObstacleAt(target))
            {
                Console.WriteLine(ErrorMessage.UnsafeCoord);
                return;
            }

            // The location is safe, get safe directions
            var safeDirections = new List<string>();
            foreach (KeyValuePair<Coord, string> direction in DirectionNames)
            {
                Coord directionCoord = direction.Key;
                string directionName = direction.Value;

                if (!HitObstacleAt(target + directionCoord))
                {
                    safeDirections.Add(directionName);
                }
            }

            // There are no safe directions
            if (safeDirections.Count == 0)
            {
                Console.WriteLine(ErrorMessage.NoSafeDirections);
                return;
            }

            // There is at least one safe direction
            Console.WriteLine(SuccessMessage.SafeDirections);
            foreach (string direction in safeDirections)
            {
                Console.WriteLine(SuccessMessage.CapitaliseFirstLetter(direction));
            }
        }
        public void Check(string[] args)
        {
            IntConstant.CompareArgsCount(args, IntConstant.CheckArgsLength);

            string strTargetX = args[IntConstant.CheckTargetXIdx];
            string strTargetY = args[IntConstant.CheckTargetYIdx];

            if (!int.TryParse(strTargetX, out int targetX) || !int.TryParse(strTargetY, out int targetY))
            {
                throw new IntArgumentException(ErrorMessage.InvalidCoord);
            }

            var target = new Coord(targetX, targetY);
            Check(target);
        }
        public void Map(Coord bottomLeft, Coord size)
        {
            Console.WriteLine(SuccessMessage.SelectedRegion);

            Coord topRight = bottomLeft + size;
            for (int y = topRight.y - 1; y >= bottomLeft.y; y--)
            {
                for (int x = bottomLeft.x; x < topRight.x; x++)
                {
                    Console.Write(GetCharAt(new Coord(x, y)));
                }
                Console.WriteLine();
            }
        }
        public void Map(string[] args)
        {
            IntConstant.CompareArgsCount(args, IntConstant.MapArgsLength);

            string strLeftX = args[IntConstant.MapLeftXIdx];
            string strbottomY = args[IntConstant.MapBottomYIdx];
            string strWidth = args[IntConstant.MapWidthIdx];
            string strHeight = args[IntConstant.MapHeightIdx];

            if (!int.TryParse(strLeftX, out int leftBorderX) || !int.TryParse(strbottomY, out int bottomBorderY))
            {
                throw new IntArgumentException(ErrorMessage.InvalidCoord);
            }

            if (!int.TryParse(strWidth, out int width) || !int.TryParse(strHeight, out int height) || width <= 0 || height <= 0)
            {
                throw new IntArgumentException(ErrorMessage.InvalidMapDimensions);
            }

            var bottomLeft = new Coord(leftBorderX, bottomBorderY);
            var size = new Coord(width, height);
            Map(bottomLeft, size);
        }
        public void Path(Coord start, Coord end)
        {
            // Same coords
            if (start == end)
            {
                Console.WriteLine(ErrorMessage.SameCoords);
                return;
            }

            // End is obstructed
            if (HitObstacleAt(end))
            {
                Console.WriteLine(ErrorMessage.GoalObstructed);
                return;
            }

            Coord[] path = AStarBidirectional(start, end);

            // No safe path
            if (path.Length == 0)
            {
                Console.WriteLine(ErrorMessage.NoSafePath);
                return;
            }

            // There is a safe path
            Console.WriteLine(SuccessMessage.ThereIsSafePath);
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
                    SuccessMessage.PrintMovement(prevDirection, repeatedDirectionsCount);
                    prevDirection = direction;
                    repeatedDirectionsCount = 1;
                }
            }
            SuccessMessage.PrintMovement(prevDirection, repeatedDirectionsCount);
        }
        public void Path(string[] args)
        {
            IntConstant.CompareArgsCount(args, IntConstant.PathArgsLength);

            string strStartX = args[IntConstant.StartXIdx];
            string strStartY = args[IntConstant.StartYIdx];
            string strEndX = args[IntConstant.EndXIdx];
            string strEndY = args[IntConstant.EndYIdx]; 

            if (!int.TryParse(strStartX, out int startX) || !int.TryParse(strStartY, out int startY))
            {
                throw new IntArgumentException(ErrorMessage.InvalidAgentCoord);
            }

            if (!int.TryParse(strEndX, out int endX) || !int.TryParse(strEndY, out int endY))
            {
                throw new IntArgumentException(ErrorMessage.InvalidObjectiveCoord);
            }

            var start = new Coord(startX, startY);
            var end = new Coord(endX, endY);
            Path(start, end);
        }
        private bool HitObstacleAt(Coord target)
        {
            return GetCharAt(target) != ObstacleConstant.EmptyChar;
        }
        private char GetCharAt(Coord target)
        {
            if (memo.TryGetValue(target, out char charRep))
            {
                return charRep;
            }

            foreach(Obstacle obstacle in obstacles)
            {
                if (obstacle.HitObstacle(target))
                {
                    memo[target] = obstacle.CharRep;
                    return obstacle.CharRep;
                }
            }
            return ObstacleConstant.EmptyChar;
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
            return Math.Abs((start - end).x) + Math.Abs((start - end).y);
        }
    }
}
