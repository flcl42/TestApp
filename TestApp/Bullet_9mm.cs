using System;

namespace TestApp
{
    public class Bullet_9mm : IBullet
    {
        string IBullet.Caliber { get; } = "9mm";

        string IBullet.Fire() { return "paff!"; }

        public void StartTest()
        {
            Console.WriteLine("testing fire");
            IBullet Bullet = new Bullet_9mm();
            Console.WriteLine(Bullet.Fire());
        }
    }
}
