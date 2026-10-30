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

        Console.WriteLine("Номер счета: " + a.GetNum());
        Console.WriteLine("Баланс: " + a.GetMoney());
        Console.WriteLine("Тип счета: " + a.GetTypeAccount());
        Console.WriteLine();
        Console.WriteLine("Номер счета: " + b.GetNum());
        Console.WriteLine("Баланс: " + b.GetMoney());
        Console.WriteLine("Тип счета: " + b.GetTypeAccount());
    }
}

