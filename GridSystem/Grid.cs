using CustomExceptions;
using ConstantsAndHelpers;
namespace GridSystem
{
    /// <summary>
    /// Represents a grid that contains various obstacles.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// The list of obstacles in the grid.
        /// </summary>
        private readonly List<Obstacle> obstacles;

        /// <summary>
        /// A dictionary that maps <see cref="Coord"/>s to their character representations for memoization.
        /// </summary>
        private readonly Dictionary<Coord, char> memo;

        /// <summary>
        /// A dictionary that maps direction coordinates to their names.
        /// </summary>
        private static readonly Dictionary<Coord, string> DirectionNames = new()
        {
            { new Coord(0, 1), Direction.North },
            { new Coord(0, -1) , Direction.South },
            { new Coord(1, 0) , Direction.East },
            { new Coord(-1, 0) , Direction.West }
        };

        /// <summary>
        /// An array of direction coordinates.
        /// </summary>
        private static readonly Coord[] DirectionCoords = [.. DirectionNames.Keys];

        /// <summary>
        /// Initialises a new instance of the <see cref="Grid"/> class.
        /// </summary>
        public Grid()
        {
            obstacles = [];
            memo = [];
        }

        /// <summary>
        /// Adds an obstacle to the grid.
        /// </summary>
        /// <param name="obstacle">The obstacle to add.</param>
        public void AddObstacle(Obstacle obstacle)
        {
            obstacles.Add(obstacle);
        }

        /// <summary>
        /// Checks whether a target coordinate is safe and prints the safe directions.
        /// </summary>
        /// <param name="target">The target coordinate to check.</param>
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

        /// <summary>
        /// Checks whether a target coordinate is safe and prints the safe directions.
        /// </summary>
        /// <param name="args">The arguments used to check the target coordinate.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        /// <exception cref="IntArgumentException">Thrown when the coordinates are not valid integers.</exception>
        public void Check(string[] args)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.CheckArgsLength);

            string strTargetX = args[ArgumentHelper.CheckTargetXIdx];
            string strTargetY = args[ArgumentHelper.CheckTargetYIdx];

            if (!int.TryParse(strTargetX, out int targetX) || !int.TryParse(strTargetY, out int targetY))
            {
                throw new IntArgumentException(ErrorMessage.InvalidCoord);
            }

            var target = new Coord(targetX, targetY);
            Check(target);
        }

        /// <summary>
        /// Maps the grid within a specified region.
        /// </summary>
        /// <param name="bottomLeft">The bottom left coordinate of the region.</param>
        /// <param name="size">The size of the region.</param>
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

        /// <summary>
        /// Maps the grid within a specified region.
        /// </summary>
        /// <param name="args">The arguments used to map the region.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        /// <exception cref="IntArgumentException">Thrown when the coordinates or dimensions are not valid integers or the height or width are less than or equal to 0.</exception>
        public void Map(string[] args)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.MapArgsLength);

            string strLeftX = args[ArgumentHelper.MapLeftXIdx];
            string strbottomY = args[ArgumentHelper.MapBottomYIdx];
            string strWidth = args[ArgumentHelper.MapWidthIdx];
            string strHeight = args[ArgumentHelper.MapHeightIdx];

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

        /// <summary>
        /// Finds a safe path from an agent's coordinate to an objective coordinate.
        /// </summary>
        /// <param name="agentCoord">The agent's coordinate.</param>
        /// <param name="objectiveCoord">The objective coordinate.</param>
        public void Path(Coord agentCoord, Coord objectiveCoord)
        {
            // Same coords
            if (agentCoord == objectiveCoord)
            {
                Console.WriteLine(ErrorMessage.SameCoords);
                return;
            }

            // Objective is obstructed
            if (HitObstacleAt(objectiveCoord))
            {
                Console.WriteLine(ErrorMessage.ObjectiveObstructed);
                return;
            }

            Coord[] path = AStarBidirectional(agentCoord, objectiveCoord);

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

        /// <summary>
        /// Finds a safe path from an agent's coordinate to an objective coordinate.
        /// </summary>
        /// <param name="args">The arguments used to find the path.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        /// <exception cref="IntArgumentException">Thrown when the coordinates are not valid integers.</exception>
        public void Path(string[] args)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.PathArgsLength);

            string strStartX = args[ArgumentHelper.StartXIdx];
            string strStartY = args[ArgumentHelper.StartYIdx];
            string strEndX = args[ArgumentHelper.EndXIdx];
            string strEndY = args[ArgumentHelper.EndYIdx];

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

        /// <summary>
        /// Checks if a target coordinate hits an obstacle.
        /// </summary>
        /// <param name="target">The target coordinate to check.</param>
        /// <returns><c>true</c> if the target coordinate hits an obstacle; otherwise, <c>false</c>.</returns>
        private bool HitObstacleAt(Coord target)
        {
            return GetCharAt(target) != ObstacleConstant.EmptyChar;
        }

        /// <summary>
        /// Gets the character representation of a coordinate.
        /// </summary>
        /// <param name="target">The target to get the character representation of.</param>
        /// <returns>The character representation of the coordinate.</returns>
        private char GetCharAt(Coord target)
        {
            if (memo.TryGetValue(target, out char charRep))
            {
                return charRep;
            }

            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.HitObstacle(target))
                {
                    memo[target] = obstacle.CharRep;
                    return obstacle.CharRep;
                }
            }
            return ObstacleConstant.EmptyChar;
        }

        /// <summary>
        /// Finds a safe path from a start coordinate to an end coordinate using two A* searches on the start and end coordinate.
        /// </summary>
        /// <param name="start">The start coordinate.</param>
        /// <param name="end">The start coordinate.</param>
        /// <returns>An array of coordinates representing the safe path if there is any; otherwise, an empty array.</returns>
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

        /// <summary>
        /// Expands the search to the neighbouring coordinates of the specified current coordinate.
        /// </summary>
        /// <param name="current">The current coordinate to expand on.</param>
        /// <param name="end">The end coordinate.</param>
        /// <param name="openSet">The set of coordinates to be evaluated.</param>
        /// <param name="gCosts">The dictionary of g-costs of each coordinate.</param>
        /// <param name="cameFrom">The dictionary of where each coordinate came from.</param>
        private void Expand(Coord current, Coord end, ref PriorityQueue<Coord, Tuple<int, int>> openSet, ref Dictionary<Coord, int> gCosts, ref Dictionary<Coord, Coord> cameFrom)
        {
            foreach (Coord direction in DirectionCoords)
            {
                Coord neighbour = current + direction;

                if (HitObstacleAt(neighbour))
                {
                    continue;
                }

                int tentativeGCost = gCosts[current] + 1;
                if (!gCosts.TryGetValue(neighbour, out int gCostNeighbour) || tentativeGCost < gCostNeighbour)
                {
                    gCosts[neighbour] = tentativeGCost;
                    int hCost = ManhattanDistance(neighbour, end);
                    int fCost = tentativeGCost + hCost;

                    openSet.Enqueue(neighbour, new Tuple<int, int>(fCost, hCost));
                    cameFrom[neighbour] = current;
                }
            }
        }

        /// <summary>
        /// Constructs a path from a coordinate to another coordinate.
        /// </summary>
        /// <param name="from">The coordinate from which the path starts.</param>
        /// <param name="to">The coordinate to which the path ends.</param>
        /// <param name="cameFrom">The dictionary of where each coordinate came from.</param>
        /// <param name="reverse">Whether to reverse the path after it is constructed.</param>
        /// <returns>A list of coordinates representing the path.</returns>
        private static List<Coord> ConstructPath(Coord from, Coord to, Dictionary<Coord, Coord> cameFrom, bool reverse = false)
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

        /// <summary>
        /// Calculates the manhattan distance between two coordinates.
        /// </summary>
        /// <param name="coord1">The first coordintae.</param>
        /// <param name="coord2">The second coordinate.</param>
        /// <returns>The absolute difference between <paramref name="coord1"/> and <paramref name="coord1"/>.</returns>
        private static int ManhattanDistance(Coord coord1, Coord coord2)
        {
            return Math.Abs((coord1 - coord2).x) + Math.Abs((coord1 - coord2).y);
        }
    }
}
