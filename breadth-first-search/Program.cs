using shared;
using System.IO; 

string path = Environment.CurrentDirectory+@"\map.txt";
var lines = File.ReadAllLines(path); 

Console.WriteLine(path);

Location start = new Location(0,0);
Location end = new Location(0,0);


var map = lines.Select( (line,y) => {
    return line.Select( (val, x) => {
        if (val == 'S') {
            start = new Location(x, y);
        } else if (val == 'E') {
            end = new Location(x, y);
        }
        return val;
    }).ToArray();

}).ToArray(); 

BFS.Print(map);

//BFS.Solve(map, start);

var pathfound = BFS.SolvePath(map, start, end);

Location? loc = pathfound[end];
while (loc != null && !loc.Equals(start)) {
    map[loc.y][loc.x] = 'x';

    BFS.Print(map);
    Thread.Sleep(40);

    loc = pathfound[loc];
}
