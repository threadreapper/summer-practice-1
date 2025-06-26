namespace task04;

public interface ISpaceship
{
    void MoveForward();      // Движение вперед
    void Rotate(int angle);  // Поворот на угол (градусы)
    void Fire();             // Выстрел ракетой
    int Speed { get; }       // Скорость корабля
    int FirePower { get; }   // Мощность выстрела
}

public class Cruiser : ISpaceship
{
    public int Speed => 50;
    public int FirePower => 100;
    public void MoveForward() {
        Console.WriteLine($"палундра! крейсер дал полный ход ({Speed})!");
    }
    public void Rotate(int angle)
    {
        Console.WriteLine($"крейсер дает право руля на {angle} градусов!");
    }
    public void Fire() {
        Console.WriteLine($"крейсер жахнул мама не горюй! бдыщ бэумс {FirePower} урона нанесено");
    }
}

public class Fighter : ISpaceship
{
    public int Speed => 100;
    public int FirePower => 50;
    public void MoveForward() {
        Console.WriteLine($"ускорители на истребителе работают вовсю! Скорость - {Speed}");
    }
    public void Rotate(int angle)
    {
        Console.WriteLine($"истребитель маневрирует вперед на {angle} градусов!");
    }
    public void Fire() {
        Console.WriteLine($"неистребический залп из истребителя! {FirePower} урона по хутору");
    }
}

