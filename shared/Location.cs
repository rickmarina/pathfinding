namespace shared;

public class Location {

    public int x { get; set; }
    public int y { get; set; }

    public Location(int x, int y)
    {
        this.x = x; 
        this.y = y;
    }

    public override string ToString()
    {
        return string.Format("{0},{1}", y,x);
    }

    //Hacemos override de los siguientes métodos para que al intentar buscar realice la comparación entre los objetos de tipo location usando toString()
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return this.ToString().Equals(obj?.ToString());
    }
}