using System;
enum Type
{
    Current = 1,
    Savings = 2
}
class Account
{
    private string num="";
    private double money;
    private Type type;
    public void Fill(string n, double m, Type t)
    {
        num = n;
        money = m;
        type = t;
    }
    public string GetNum()
    {
        return num;
    }
    public double GetMoney()
    {
        return money;
    }
    public Type GetTypeAccount()
    {
        return type;
    }
}
class Program
{
    static void Main()
    {
        Account a = new Account();
        a.Fill("1111895", 500000000, Type.Savings);
        Console.WriteLine(a.GetNum());
        Console.WriteLine(a.GetMoney());
        Console.WriteLine(a.GetTypeAccount());
    }
}
