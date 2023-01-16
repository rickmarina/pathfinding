
using System.Threading;
using shared;
public class BFS {

    public static void Solve(char[][] map, Location start) {
        Queue<Location> queue = new Queue<Location>(); 
        queue.Enqueue(start);

        HashSet<Location> reached = new(); 
        reached.Add(start); 

        while (queue.Count > 0) {
            Location current = queue.Dequeue(); 

            if (map[current.y][current.x] == '.') 
                 map[current.y][current.x] = 'O';
            Print(map);
            Thread.Sleep(75);
            //Console.ReadKey();

            foreach (var next in GetNeighbors(map, current)) {
               if (reached.Add(next)) {
                    queue.Enqueue(next);
               } 
            }

        }
    }

    public static Dictionary<Location, Location?> SolvePath(char[][] map, Location start, Location end) {
        Queue<Location> queue = new Queue<Location>(); 
        queue.Enqueue(start);

        Dictionary<Location, Location?> came_from = new(); 
        came_from.Add(start, null);

        while (queue.Count >0) {
            Location current = queue.Dequeue(); 

            //early exit
            if (current.Equals(end)) 
                break; 

            foreach (var next in GetNeighbors(map, current)) {
               if (!came_from.ContainsKey(next)) {
                    queue.Enqueue(next);
                    came_from.Add(next, current);
               } 
            }
        }

        return came_from;
    }

    public static IEnumerable<Location> GetNeighbors(char[][] map, Location from) { 
        List<Location> dirs = new List<Location>() { 
            new Location(0, -1), 
            new Location(1, 0), 
            new Location(0, 1), 
            new Location(-1, 0)
        };

        foreach (var d in dirs) {
            Location newLoc = new Location(from.x+d.x, from.y+d.y);
            if (newLoc.x >= 0 && newLoc.x < map[0].Length && newLoc.y >= 0 && newLoc.y < map.Length && map[newLoc.y][newLoc.x] != '#') 
                yield return newLoc;
        }
    }


    public static void Print(char[][] map) {
        Console.WriteLine("------- map: ");

        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                Console.Write(string.Format("{0, 3}", map[i][j]));
            }
            Console.WriteLine();
        }
    }
}