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
    public void Put(double sum)
    {
        money = money + sum;
    }
    public bool Take(double sum)
    {
        if (sum > 0 && money >= sum)
        {
            money = money - sum;
            return true;
        }
        else
        {
            return false;
        }
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
        a.Fill(5000, AccountType.Savings);
        a.Put(1000);
        bool result = a.Take(2000);
        Console.WriteLine("Номер счета: " + a.GetNum());
        Console.WriteLine("Баланс: " + a.GetMoney());
        Console.WriteLine("Тип счета: " + a.GetTypeAccount());
        Console.WriteLine("Операция успешна: " + result);
    }
}

