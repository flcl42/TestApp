using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class BulletsTests
    {
        [Test]
        public void Fire_Bullet762_boomreturned()
        {
            IBullet Bullet = new Bullet_762();
            string expected = "boom!";
            string actual;

            actual = Bullet.Fire();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Fire_Bullet9mm_paffreturned()
        {
            IBullet Bullet = new Bullet_9mm();
            string expected = "paff!";
            string actual;

            actual = Bullet.Fire();

            Assert.AreEqual(expected, actual);
        }
    }
}
