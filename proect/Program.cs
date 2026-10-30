using System;
class Building
{
    private static int count = 0;
    private int num;
    private double height;
    private int floors;
    private int flats;
    private int doors;
    private static int NextNum()
    {
        count++;
        return count;
    }
    public Building()
    {
        num = NextNum();
    }
    public void Fill(double h, int f, int fl, int d)
    {
        height = h;
        floors = f;
        flats = fl;
        doors = d;
    }
    public int GetNum()
    {
        return num;
    }
    public double GetHeight()
    {
        return height;
    }
    public int GetFloors()
    {
        return floors;
    }
    public int GetFlats()
    {
        return flats;
    }
    public int GetDoors()
    {
        return doors;
    }
    public double GetFloorHeight()
    {
        return height / floors;
    }
    public int GetFlatsInDoor()
    {
        return flats / doors;
    }
    public int GetFlatsOnFloor()
    {
        return flats / floors;
    }
    public int GetFlatsOnFloorInDoor()
    {
        return flats / (floors * doors);
    }
}
class Program
{
    static void Main()
    {
        Building a = new Building();
        a.Fill(30, 10, 100, 2);
        Console.WriteLine("Номер здания: " + a.GetNum());
        Console.WriteLine("Высота здания: " + a.GetHeight());
        Console.WriteLine("Количество этажей: " + a.GetFloors());
        Console.WriteLine("Количество квартир: " + a.GetFlats());
        Console.WriteLine("Количество подъездов: " + a.GetDoors());
        Console.WriteLine("Высота одного этажа: " + a.GetFloorHeight());
        Console.WriteLine("Квартир в подъезде: " + a.GetFlatsInDoor());
        Console.WriteLine("Квартир на этаже: " + a.GetFlatsOnFloor());
        Console.WriteLine("Квартир на этаже в одном подъезде: " + a.GetFlatsOnFloorInDoor());
    }
}


