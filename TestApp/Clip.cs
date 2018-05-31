using System.Collections.Generic;

namespace TestApp
{
    public class Clip
    {
        public Stack<IBullet> Bullets;

        public Clip(IBullet Bullet, int Capacity)
        {
            Bullets = new Stack<IBullet>(Capacity);
            for (int i = 0; i < Capacity; i++) { Bullets.Push(Bullet); }
        }
    }
}
