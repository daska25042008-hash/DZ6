using System;
enum AccountType
{
    Current = 1,
    Savings = 2
}
class Account
{
    private static int count = 0;
    private int num;
    private double money;
    private AccountType type;
    private static int NextNum()
    {
        count++;
        return count;
    }
    public Account()
    {
        num = NextNum();
    }
    public void Fill(double m, AccountType t)
    {
        money = m;
        type = t;
    }
    public int GetNum()
    {
        return num;
    }
    public double GetMoney()
    {
        return money;
    }
    public AccountType GetTypeAccount()
    {
        return type;
    }
}
class Program
{
    static void Main()
    {
        Account a = new Account();
        Account b = new Account();

        a.Fill(50000000, AccountType.Savings);
        b.Fill(108008694, AccountType.Current);

        Console.WriteLine("Number: " + a.GetNum());
        Console.WriteLine("Money: " + a.GetMoney());
        Console.WriteLine("Type: " + a.GetTypeAccount());
        Console.WriteLine("Number: " + b.GetNum());
        Console.WriteLine("Money: " + b.GetMoney());
        Console.WriteLine("Type: " + b.GetTypeAccount());
    }
}

