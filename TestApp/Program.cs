using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        { 
            var Pistol = new Gun("9mm");
            Pistol.StartTest();
            Console.Read();
        }
    }

    interface IBullet
    {
        string Caliber { get; }

        void Fire();

    }

    class Bullet_762 : IBullet
    {
        string IBullet.Caliber { get; } = "7.62";

        void IBullet.Fire() {Console.WriteLine("boom!");}
    }

    class Bullet_9mm : IBullet
    {
        string IBullet.Caliber { get; } = "9mm";

        void IBullet.Fire() {Console.WriteLine("paff!");}
    }

    class Clip
    {
        public Stack<IBullet> Bullets;

        public Clip(IBullet Bullet, int Capacity)
        {
            Bullets = new Stack<IBullet>(Capacity);
            for (int i = 0; i < Capacity; i++) { Bullets.Push(Bullet); }
        }
    }

    class Gun
    {
        readonly string Caliber;
        private Clip Loaded;

        public Gun(String Cal) {Caliber = Cal;}

        public void Fire(IBullet Bullet)
        {
            if (Bullet.Caliber == Caliber)
                Bullet.Fire();
            else
                Console.WriteLine("improper caliber");
        }

        public void Fire()
        {
            while (Loaded.Bullets.Count != 0)
                Loaded.Bullets.Pop().Fire();
            Console.WriteLine("clip is empty");
        }

        public void Load(Clip Cl)
        {
            if (Cl.Bullets.Peek().Caliber == Caliber)
            {
                Loaded = Cl;
                Console.WriteLine("Loaded clip:" + "\n" +
                                  "caliber: " + Cl.Bullets.Peek().Caliber + "\n" +
                                  "capacity: " + Cl.Bullets.Count.ToString());
            }
            else
                Console.WriteLine("improper caliber");
        }

        public void StartTest()
        {
            Console.WriteLine("---- Fire/Load Test ----");
            IBullet TestBullet1 = new Bullet_9mm();
            IBullet TestBullet2 = new Bullet_762();
            Clip TestClip1 = new Clip(TestBullet1, 5);
            Clip TestClip2 = new Clip(TestBullet2, 7);

            Console.WriteLine("---- Testing Load ----");
            Console.WriteLine("---- Loading proper caliber clip: ----");
            Load(TestClip1);
            Console.WriteLine("---- Loading improper caliber clip: ----");
            Load(TestClip2);

            Console.WriteLine("---- Testing Fire ----");
            Console.WriteLine("---- Firing loaded clip ----");
            Fire();
            Console.WriteLine("---- Firing single proper caliber bullet ----");
            Fire(TestBullet1);
            Console.WriteLine("---- Firing single improper caliber bullet ----");
            Fire(TestBullet2);
        }
    }
}
