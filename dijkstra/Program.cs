/* 

In some pathfinding scenarios there are different costs for different types of movement.
We’d like the pathfinder to take these costs into account.

For this we want Dijkstra’s Algorithm (or Uniform Cost Search). 
How does it differ from Breadth First Search? We need to track movement costs, so let’s add a new variable, cost_so_far, 
to keep track of the total movement cost from the start location. 
We want to take the movement costs into account when deciding how to evaluate locations; 
let’s turn our queue into a priority queue. Less obviously, we may end up visiting a location multiple times, 
with different costs, so we need to alter the logic a little bit. 
Instead of adding a location to the frontier if the location has never been reached, 
we’ll add it if the new path to the location is better than the best previous path.

Using a priority queue instead of a regular queue changes the way the frontier expands. 

*/

using shared;
using System.IO; 

string path = Environment.CurrentDirectory+@"\map.txt";
var lines = File.ReadAllLines(path); 

Console.WriteLine(path);

Location start = new Location(0,0);
Location end = new Location(0,0);

//Read the map 
//but in this case we will save the cost of movement
// # wall: -1 of cost
// . road: 1 of cost 
// O water: 5 of cost 
// - grass: 3 of cost 
var map = lines.Select( (line,y) => {
    return line.Select( (val, x) => {
        if (val == 'S') {
            start = new Location(x, y);
        } else if (val == 'E') {
            end = new Location(x, y);
        }

        return val switch 
        {
            '.' => 1,
            '#' => -1, 
            'O' => 5, 
            '-' => 3,
            'E' => 0,
            'S' => 0,
            _ => 1
        };
    }).ToArray();
}).ToArray(); 

var originalMap = lines.Select( (line,y) => {
    return line.Select( (val, x) => {
        return val;
    }).ToArray();
}).ToArray(); 

// mapa load ends

MapUtils.Print(map);

var pathfound = Dijkstra.SolvePath(map, start, end);

Location? loc = pathfound[end];
while (loc != null && !loc.Equals(start)) {
    originalMap[loc.y][loc.x] = 'x';

    MapUtils.Print(originalMap);
    Thread.Sleep(40);

    loc = pathfound[loc];
}
