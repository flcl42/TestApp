using System;

namespace TestApp
{
    public class Gun
    {
        readonly string Caliber;
        private Clip Loaded;

        public Gun(string Cal) {Caliber = Cal;}

        public string Fire(IBullet Bullet)
        {
            if (Bullet.Caliber == Caliber)
                return Bullet.Fire();
            return "improper caliber";
        }

        public string Fire()
        {
            string Queue = "";
            while (Loaded.Bullets.Count != 0)
            {
                Queue += Loaded.Bullets.Pop().Fire();
            }
            if (Queue == "")
                Queue = "not loaded";
            return Queue;
        }

        public bool Load(Clip Cl)
        {
            if (Cl.Bullets.Peek().Caliber == Caliber)
            {
                Loaded = Cl;
                Console.WriteLine("Loaded clip:" + "\n" +
                                  "caliber: " + Cl.Bullets.Peek().Caliber + "\n" +
                                  "capacity: " + Cl.Bullets.Count.ToString());
                return true;
            }
            else
                return false;
        }

        public void StartTest()
        {

            IBullet TestBullet1 = new Bullet_9mm();
            IBullet TestBullet2 = new Bullet_762();
            Clip TestClip1 = new Clip(TestBullet1, 5);
            Clip TestClip2 = new Clip(TestBullet2, 7);
            Console.WriteLine("---- Fire/Load Test ----");
            Console.WriteLine("---- Testing Load ----");
            Console.WriteLine("---- Loading proper caliber clip: ----");
            Console.WriteLine(Load(TestClip1));
            Console.WriteLine("---- Loading improper caliber clip: ----");
            Console.WriteLine(Load(TestClip2));
            Console.WriteLine("---- Testing Fire ----");
            Console.WriteLine("---- Firing loaded clip ----");
            Console.WriteLine(Fire());
            Console.WriteLine("---- Firing single proper caliber bullet ----");
            Console.WriteLine(Fire(TestBullet1));
            Console.WriteLine("---- Firing single improper caliber bullet ----");
            Console.WriteLine(Fire(TestBullet2));
        }
    }
}
