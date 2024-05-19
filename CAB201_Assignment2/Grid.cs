using CustomExceptions;
namespace Didutron
{
    public class Grid
    {
        private readonly Dictionary<Coord, string> DIRECTIONS = new Dictionary<Coord, string>()
        {
            { new Coord(0, 1), "north" },
            { new Coord(0, -1) , "south" },
            { new Coord(1, 0) , "east" },
            { new Coord(-1, 0) , "west" }
        };
        private readonly List<Obstacle> obstacles;
        private readonly Dictionary<Coord, char> memo;

        private const char EMPTY_CELL_CHAR = '.';
        private const string INVALID_COORD_MSG = "Coordinates are not valid integers.";
        private const string INVALID_MAP_LENGTH_MSG = "Width and height must be valid positive integers.";
        private const string INVALID_AGENT_COORD_MSG = "Agent coordinates are not valid integers.";
        private const string INVALID_OBJECTIVE_COORD_MSG = "Objective coordinates are not valid integers.";

        public Grid()
        {
            obstacles = new List<Obstacle>();
            memo = new Dictionary<Coord, char>();
        }

        public void AddObstacle(Obstacle obstacle)
        {
            obstacles.Add(obstacle);
        }

        public void Check(int targetX, int targetY)
        {
            const string UNSAFE_COORD_PROMPT = "Agent your location is compromised. Abort mission";
            const string NO_SAFE_DIRECTIONS_PROMPT = "You cannot safely move in any direction. Abort mission.";
            const string SAFE_DIRECTIONS_PROMPT = "You can safely take any of the following directions:";

            // The location is not safe
            if (HitObstacleAt(targetX, targetY))
            {
                Console.WriteLine(UNSAFE_COORD_PROMPT);
                return;
            }

            // The location is safe.
            // Now getting safe directions
            var safeDirections = new List<string>();
            foreach (var direction in DIRECTIONS)
            {
                string directionName = direction.Value;
                int directionX = direction.Key.x;
                int directionY = direction.Key.y;

                if (!HitObstacleAt(targetX + directionX, targetY + directionY))
                {
                    safeDirections.Add(directionName);
                }
            }

            // There are no safe directions
            if (safeDirections.Count == 0)
            {
                Console.WriteLine(NO_SAFE_DIRECTIONS_PROMPT);
                return;
            }

            // There is at least one safe direction
            Console.WriteLine(SAFE_DIRECTIONS_PROMPT);
            foreach (string direction in safeDirections)
            {
                Console.WriteLine(CapitalizeFirstLetter(direction));
            }
        }

        public void Check(string[] args)
        {
            ArgsCount.CheckArgsCount(args, ArgsCount.Check);

            const int TargetXIdx = 0;
            const int TargetYIdx = 1;

            string strTargetX = args[TargetXIdx];
            string strTargetY = args[TargetYIdx];

            if (!int.TryParse(strTargetX, out int targetX) || !int.TryParse(strTargetY, out int targetY))
            {
                throw new IntArgumentException(INVALID_COORD_MSG);
            }

            Check(targetX, targetY);
        }

        public void Map(int leftBorderX, int bottomBorderY, int width, int height)
        {
            const string SELECTED_REGION_PROMPT = "Here is a map of obstacles in the selected region:";

            Console.WriteLine(SELECTED_REGION_PROMPT);
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
            ArgsCount.CheckArgsCount(args, ArgsCount.Map);

            const int LeftBorderXIdx = 0;
            const int BottomBorderYIdx = 1;
            const int WidthIdx = 2;
            const int HeightIdx = 3;

            string strLeftBorderX = args[LeftBorderXIdx];
            string strbottomBorderY = args[BottomBorderYIdx];
            string strWidth = args[WidthIdx];
            string strHeight = args[HeightIdx];

            if (!int.TryParse(strLeftBorderX, out int leftBorderX) || !int.TryParse(strbottomBorderY, out int bottomBorderY))
            {
                throw new IntArgumentException(INVALID_COORD_MSG);
            }

            if (!int.TryParse(strWidth, out int width) || !int.TryParse(strHeight, out int height))
            {
                throw new IntArgumentException(INVALID_MAP_LENGTH_MSG);
            }

            Map(leftBorderX, bottomBorderY, width, height);
        }

        public void Path(int startX, int startY, int endX, int endY)
        {
            const string SAME_COORDS_PROMPT = "Agent, you are already at the objective.";
            const string GOAL_OBSTRUCTED_PROMPT = "The objective is blocked by an obstacle and cannot be reached.";
            const string NO_SAFE_PATH = "There is no safe path to the objective.";
            const string THERE_IS_PATH = "The following path will take you to the objective:";
            const string DIRECTION_AND_COUNT_PROMPT = "Head {0} for {1} {2}.";
            const string UNIT = "klick";

            if (startX == endX && startY == endY)
            {
                Console.WriteLine(SAME_COORDS_PROMPT);
                return;
            }

            if (HitObstacleAt(endX, endY))
            {
                Console.WriteLine(GOAL_OBSTRUCTED_PROMPT);
                return;
            }

            Coord[] path = AStarBidirectional(startX, startY, endX, endY);

            if (path.Length == 0)
            {
                Console.WriteLine(NO_SAFE_PATH);
                return;
            }

            Console.WriteLine(THERE_IS_PATH);
            int repeatedDirectionsCount = 0;
            string prevDirection = "";
            for (int i = 1; i < path.Length; i++)
            {
                Coord currentCoord = path[i];
                Coord prevCoord = path[i - 1];
                string direction = DIRECTIONS[currentCoord - prevCoord];
                if (direction == prevDirection)
                {
                    repeatedDirectionsCount++;
                } else
                {
                    if (prevDirection != "")
                    {
                        Console.WriteLine(DIRECTION_AND_COUNT_PROMPT, prevDirection, repeatedDirectionsCount, SingularOrPlural(UNIT, repeatedDirectionsCount));
                    }
                    prevDirection = direction;
                    repeatedDirectionsCount = 1;
                }
            }
            Console.WriteLine(DIRECTION_AND_COUNT_PROMPT, prevDirection, repeatedDirectionsCount, SingularOrPlural(UNIT, repeatedDirectionsCount));
        }

        public void Path(string[] args)
        {
            ArgsCount.CheckArgsCount(args, ArgsCount.Map);

            const int StartXIdx = 0;
            const int StartYIdx = 1;
            const int EndXIdx = 2;
            const int EndYIdx = 3;

            string strStartX = args[StartXIdx];
            string strStartY = args[StartYIdx];
            string strEndX = args[EndXIdx];
            string strEndY = args[EndYIdx]; 

            if (!int.TryParse(strStartX, out int startX) || !int.TryParse(strStartY, out int startY))
            {
                throw new IntArgumentException(INVALID_AGENT_COORD_MSG);
            }

            if (!int.TryParse(strEndX, out int endX) || !int.TryParse(strEndY, out int endY))
            {
                throw new IntArgumentException(INVALID_OBJECTIVE_COORD_MSG);
            }

            Path(startX, startY, endX, endY);
        }

        private bool HitObstacleAt(int targetX, int targetY)
        {
            return GetCharAt(targetX, targetY) != EMPTY_CELL_CHAR;
        }

        private bool HitObstacleAt(Coord target)
        {
            return HitObstacleAt(target.x, target.y);
        }

        private char GetCharAt(int targetX, int targetY)
        {
            Coord target = new Coord(targetX, targetY);

            if (memo.TryGetValue(target, out char charRep))
            {
                return charRep;
            }

            foreach(Obstacle obstacle in obstacles)
            {
                if (obstacle.HitObstacle(targetX, targetY))
                {
                    memo[target] = obstacle.charRep;
                    return obstacle.charRep;
                }
            }
            return EMPTY_CELL_CHAR;
        }

        private Coord[] BfsFindPath(int startX, int startY, int endX, int endY)
        {
            return BfsFindPath(new Coord(startX, startY), new Coord(endX, endY));
        }

        private Coord[] BfsFindPath(Coord start, Coord end)
        {
            var queue = new Queue<Coord>();
            queue.Enqueue(start);

            var visited = new HashSet<Coord>();

            var cameFrom = new Dictionary<Coord, Coord>();

            // Start BFS-ing
            while (queue.Count > 0)
            {
                var currentCoord = queue.Dequeue();

                // Reached end coord
                if (currentCoord == end)
                { 
                    List<Coord> path = new List<Coord>();
                    var coord = end;

                    // Constructing Path
                    while (coord != start)
                    {
                        var nextCoord = cameFrom[coord];
                        path.Add(coord);
                        coord = nextCoord;
                    }

                    path.Add(start);
                    path.Reverse();

                    return path.ToArray();
                }

                visited.Add(currentCoord);
                foreach(var direction in DIRECTIONS.Keys)
                {
                    var neiCoord = currentCoord + direction;

                    // If Neighbour Coord hits obstacle or has been visited, skip
                    if (HitObstacleAt(neiCoord) || visited.Contains(neiCoord))
                    {
                        continue;
                    }

                    // Neighbour Coord is safe
                    queue.Enqueue(neiCoord);
                    cameFrom[neiCoord] = currentCoord;
                }
            }

            return [];
        }

        private Coord[] AStarFindPath(Coord start, Coord end)
        {
            // A priority queue where the:
            // element: Coord
            // priority: Tuple<int, int> where the first and second int respectively is the fCost and hCost
            var open = new PriorityQueue<Coord, Tuple<int, int>>();
            int startingFCost = ManhattanDistance(start, end); 
            open.Enqueue(start, new Tuple<int, int>(startingFCost, startingFCost)); // Technically `start` has the same f and h cost, the fCost is just 0 + hCost

            var gCosts = new Dictionary<Coord, int>();
            gCosts[start] = 0;
            
            var cameFrom = new Dictionary<Coord, Coord>();

            while (open.Count > 0)
            {
                var currentCoord = open.Dequeue();

                if (currentCoord == end)
                {
                    break;
                }

                foreach (Coord direction in DIRECTIONS.Keys)
                {
                    Coord neiCoord = currentCoord + direction;

                    if (HitObstacleAt(neiCoord))
                    {
                        continue;
                    }

                    int tentativeGCost = gCosts[currentCoord] + 1;
                    if (!gCosts.ContainsKey(neiCoord) || tentativeGCost < gCosts[neiCoord])
                    {
                        gCosts[neiCoord] = tentativeGCost;
                        int hCost = ManhattanDistance(neiCoord, end);
                        int fCost = tentativeGCost + hCost;

                        open.Enqueue(neiCoord, new Tuple<int, int>(fCost, hCost));
                        cameFrom[neiCoord] = currentCoord;
                    }
                }
            }

            // Constructing path here
            List<Coord> path = new List<Coord>();
            var coord = end;

            while (coord != start)
            {
                var nextCoord = cameFrom[coord];
                path.Add(coord);
                coord = nextCoord;
            }

            path.Add(start);
            path.Reverse();

            return path.ToArray();
        }

        private Coord[] AStarFindPath(int startX, int startY, int endX, int endY)
        {
            return AStarFindPath(new Coord(startX, startY), new Coord(endX, endY));
        }

        private Coord[] AStarBidirectional(int startX, int startY, int endX, int endY)
        {
            return AStarBidirectional(new Coord(startX, startY), new Coord(endX, endY));
        }

        private Coord[] AStarBidirectional(Coord start, Coord end)
        {
            // These priority queues when enqueued will return the Coord with
            // the lowest fCost, if there are multiple Coords with the same fCost,
            // then return the one with the lowest hCost
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
            Coord coordIntersect = new Coord();
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

                // Expand on A
                //foreach (Coord direction in DIRECTIONS.Keys)
                //{
                //    Coord neiCoordA = currentNodeA + direction;
                //    if (HitObstacleAt(neiCoordA))
                //    {
                //        continue;
                //    }

                //    int tentativeGCost = gCostsA[currentNodeA] + 1;
                //    if (!gCostsA.ContainsKey(neiCoordA) || tentativeGCost < gCostsA[neiCoordA])
                //    {
                //        gCostsA[neiCoordA] = tentativeGCost;
                //        int hCost = ManhattanDistance(neiCoordA, end);
                //        int fCost = tentativeGCost + hCost;

                //        openA.Enqueue(neiCoordA, new Tuple<int, int>(fCost, hCost));
                //        cameFromA[neiCoordA] = currentNodeA;
                //    }
                //}
                Expand(currentNodeA, end, DIRECTIONS.Keys, ref openA, ref gCostsA, ref cameFromA);

                // Expand on B
                //foreach (Coord direction in DIRECTIONS.Keys)
                //{
                //    Coord neiCoordB = currentNodeB + direction;
                //    if (HitObstacleAt(neiCoordB))
                //    {
                //        continue;
                //    }

                //    int tentativeGCost = gCostsB[currentNodeB] + 1;
                //    if (!gCostsB.ContainsKey(neiCoordB) || tentativeGCost < gCostsB[neiCoordB])
                //    {
                //        gCostsB[neiCoordB] = tentativeGCost;
                //        int hCost = ManhattanDistance(neiCoordB, start);
                //        int fCost = tentativeGCost + hCost;

                //        openB.Enqueue(neiCoordB, new Tuple<int, int>(fCost, hCost));
                //        cameFromB[neiCoordB] = currentNodeB;
                //    }
                //}
                Expand(currentNodeB, start, DIRECTIONS.Keys, ref openB, ref gCostsB, ref cameFromB);
            }

            if (!foundPath)
            {
                return Array.Empty<Coord>();
            }

            // Constructing start to intersect
            var path = new List<Coord>();
            Coord coordIterator = coordIntersect;
            while (coordIterator != start)
            {
                path.Add(coordIterator);
                coordIterator = cameFromA[coordIterator];
            }
            path.Add(start);
            path.Reverse();

            // This only happens when the path is only one step
            if (path[path.Count - 1] == end)
            {
                return path.ToArray();
            }

            // Constructing intersect to end
            coordIterator = cameFromB[coordIntersect]; // skipping one because already accounted when constructing start to intersect
            while (coordIterator != end)
            {
                path.Add(coordIterator);
                coordIterator = cameFromB[coordIterator];
            }
            path.Add(end);

            return path.ToArray();
        }

        private void Expand(
            Coord currentCoord,
            Coord endCoord,
            IEnumerable<Coord> directions,
            ref PriorityQueue<Coord, Tuple<int, int>> openSet,
            ref Dictionary<Coord, int> gCosts,
            ref Dictionary<Coord, Coord> cameFrom)
        {
            foreach (Coord direction in directions)
            {
                Coord neighbour = currentCoord + direction;

                if (HitObstacleAt(neighbour))
                {
                    continue;
                }

                int tentativeGCost = gCosts[currentCoord] + 1;
                if (!gCosts.ContainsKey(neighbour) || tentativeGCost < gCosts[neighbour])
                {
                    gCosts[neighbour] = tentativeGCost;
                    int hCost = ManhattanDistance(neighbour, endCoord);
                    int fCost = tentativeGCost + hCost;

                    openSet.Enqueue(neighbour, new Tuple<int, int>(fCost, hCost));
                    cameFrom[neighbour] = currentCoord;
                }
            }
        }

        private static int ManhattanDistance(Coord start, Coord end)
        {
            return Math.Abs((start - end).x) + Math.Abs((start - end).y);
        }

        private static string SingularOrPlural(string word, int count)
        {
            return count == 1 ? word : word + 's';
        }

        private static string CapitalizeFirstLetter(string word)
        {
            if (word.Length == 0)
            {
                return word;
            }
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
