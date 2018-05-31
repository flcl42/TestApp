using System;

namespace TestApp
{
    public class Bullet_762 : IBullet
    {
        string IBullet.Caliber { get; } = "7.62";

        string IBullet.Fire() { return "boom!"; }

        public void StartTest()
        {
            Console.WriteLine("testing fire");
            IBullet Bullet = new Bullet_762();
            Console.WriteLine(Bullet.Fire());
        }
    }
}
