namespace shared;

public class MapUtils {
public static void Print(int[][] map)
    {
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

    public static void Print(char[][] map)
    {
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