using shared;

public class Dijkstra
{

    public static Dictionary<Location, Location?> SolvePath(int[][] map, Location start, Location end)
    {
        PriorityQueue<Location, int> queue = new();
        queue.Enqueue(start, 0);

        Dictionary<Location, Location?> came_from = new();
        came_from.Add(start, null);
        Dictionary<Location, int> cost_so_far = new();
        cost_so_far.Add(start, 0);


        while (queue.Count > 0)
        {
            Location current = queue.Dequeue();

            //early exit
            if (current.Equals(end))
                break;

            foreach (var next in GetNeighbors(map, current))
            {
                int new_cost = cost_so_far[current]+map[next.y][next.x];
                if (!cost_so_far.ContainsKey(next) || new_cost < cost_so_far[next]) {
                    cost_so_far.Add(next, new_cost); 
                    queue.Enqueue(next, new_cost);
                    came_from.Add(next, current);
                }
            }
        }

        return came_from;
    }

    public static IEnumerable<Location> GetNeighbors(int[][] map, Location from)
    {
        List<Location> dirs = new List<Location>() {
            new Location(0, -1),
            new Location(1, 0),
            new Location(0, 1),
            new Location(-1, 0)
        };

        foreach (var d in dirs)
        {
            Location newLoc = new Location(from.x + d.x, from.y + d.y);
            if (newLoc.x >= 0 && newLoc.x < map[0].Length && newLoc.y >= 0 && newLoc.y < map.Length && map[newLoc.y][newLoc.x] != -1)
                yield return newLoc;
        }
    }

}