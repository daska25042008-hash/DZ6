using System;
using System.Collections.Generic;
abstract class Letter
{
    public string Subject { get; set; }
    public string Sender { get; set; }
    public string Status { get; set; }
    public string Folder { get; set; }
    public string Body { get; set; }
    public bool IsDeleted { get; private set; }
    protected Letter(string sub, string from, string message, string state, string place)
    {
        Subject = sub;
        Sender = from;
        Body = message;
        Status = state;
        Folder = place;
        IsDeleted = false;
    }
    public abstract string Kind { get; }
    public virtual void MarkRead()
    {
        Status = "Прочитано";
    }
    public virtual void MoveToFolder(string place)
    {
        Folder = place;
    }
    public virtual void Delete()
    {
        IsDeleted = true;
    }
    public virtual void Reply(string message)
    {
        Console.WriteLine("Ответ: " + message);
    }
    public virtual string GetInfo()
    {
        return "Тема: " + Subject + ", Отправитель: " + Sender + ", Статус: " + Status + ", Папка: " + Folder;
    }
}
class Incoming : Letter
{
    public Incoming(string sub, string from, string message) : base(sub, from, message, "Новое", "Входящие")
    {
    }
    public Incoming(string sub, string from, string message, string state) : base(sub, from, message, state, "Входящие")
    {
    }
    public override string Kind
    {
        get { return "Входящее письмо"; }
    }
    public override void MarkRead()
    {
        base.MarkRead();
        Console.WriteLine("Входящее письмо прочитано");
    }
    public override void MoveToFolder(string place)
    {
        base.MoveToFolder(place);
        Console.WriteLine("Входящее письмо перемещено");
    }
    public override void Delete()
    {
        base.Delete();
        Console.WriteLine("Входящее письмо удалено");
    }
    public override void Reply(string message)
    {
        Console.WriteLine("Ответ отправлен: " + message);
    }
    public override string GetInfo()
    {
        return Kind + " | " + base.GetInfo();
    }
}
class Spam : Letter
{
    public Spam(string sub, string from, string message) : base(sub, from, message, "Не прочитано", "Спам")
    {
    }
    public Spam(string sub, string from, string message, string state) : base(sub, from, message, state, "Спам")
    {
    }
    public override string Kind
    {
        get { return "Спам"; }
    }
    public override void MarkRead()
    {
        base.MarkRead();
        Console.WriteLine("Письмо из спама прочитано");
    }
    public override void MoveToFolder(string place)
    {
        base.MoveToFolder(place);
        Console.WriteLine("Письмо из спама перемещено");
    }
    public override void Delete()
    {
        base.Delete();
        Console.WriteLine("Спам удален");
    }

    public override void Reply(string message)
    {
        Console.WriteLine("Нельзя отвечать на спам");
    }
    public override string GetInfo()
    {
        return Kind + " | " + base.GetInfo();
    }
}
class Draft : Letter
{
    public Draft(string sub, string from, string message) : base(sub, from, message, "Черновик", "Черновики")
    {
    }
    public Draft(string sub, string from, string message, string state) : base(sub, from, message, state, "Черновики")
    {
    }
    public override string Kind
    {
        get { return "Черновик"; }
    }
    public override void MarkRead()
    {
        base.MarkRead();
        Console.WriteLine("Черновик открыт");
    }
    public override void MoveToFolder(string place)
    {
        base.MoveToFolder(place);
        Console.WriteLine("Черновик перемещен");
    }
    public override void Delete()
    {
        base.Delete();
        Console.WriteLine("Черновик удален");
    }
    public override void Reply(string message)
    {
        Body = message;
        Console.WriteLine("Текст черновика изменен");
    }
    public override string GetInfo()
    {
        return Kind + " | " + base.GetInfo();
    }
}

class Mailbox
{
    private List<Letter> letters = new List<Letter>();
    public void Add(Letter letter)
    {
        letters.Add(letter);
    }
    public void ShowAll()
    {
        Console.WriteLine("ВСЕ ПИСЬМА");
        foreach (Letter letter in letters)
        {
            if (!letter.IsDeleted)
            {
                Console.WriteLine(letter.GetInfo());
            }
        }
    }
    public void Stats()
    {
        Dictionary<string, int> stats = new Dictionary<string, int>();
        foreach (Letter letter in letters)
        {
            if (!letter.IsDeleted)
            {
                if (stats.ContainsKey(letter.Sender))
                {
                    stats[letter.Sender]++;
                }
                else
                {
                    stats[letter.Sender] = 1;
                }
            }
        }
        Console.WriteLine("СТАТИСТИКА");
        foreach (KeyValuePair<string, int> item in stats)
        {
            Console.WriteLine(item.Key + ": " + item.Value + " письма");
        }
    }
    public void FindBySender(string from)
    {
        Console.WriteLine("ПОИСК ПИСЕМ");
        foreach (Letter letter in letters)
        {
            if (letter.Sender == from && !letter.IsDeleted)
            {
                Console.WriteLine(letter.GetInfo());
            }
        }
    }
    public void DeleteLetter(Letter letter)
    {
        letter.Delete();
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("ЗАДАНИЕ: ТИПЫ ПИСЕМ В ПОЧТОВОМ ЯЩИКЕ");
        Console.WriteLine("Программа показывает работу входящих писем, спама и черновиков.");

        Mailbox box = new Mailbox();

        Incoming a = new Incoming("Расписание", "Анна", "Новое расписание");
        Incoming b = new Incoming("Домашнее задание", "Иван", "Задание по программированию");
        Spam c = new Spam("Вы выиграли миллион", "Реклама", "Перейдите по ссылке");
        Draft d = new Draft("Мое письмо", "Я", "Здравствуйте!");
        box.Add(a);
        box.Add(b);
        box.Add(c);
        box.Add(d);
        box.ShowAll();
        Console.WriteLine("РАБОТА С ПИСЬМАМИ");
        a.MarkRead();
        b.MoveToFolder("Важные");
        a.Reply("Спасибо за информацию!");
        box.DeleteLetter(c);
        d.Reply("Здравствуйте! Как ваши дела?");
        box.ShowAll();
        box.FindBySender("Анна");
        box.Stats();
        Console.WriteLine("Работа программы завершена.");
    }
}