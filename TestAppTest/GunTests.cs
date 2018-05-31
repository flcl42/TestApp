using NUnit.Framework;
using Moq;

namespace TestApp.Tests
{
    [TestFixture]
    public class GunTests
    {
        [Test]
        public void Fire_2x9mm_2xpaffreturned()
        {
            var TestBullet = new Mock<Bullet_9mm>();
            var TestClip = new Mock<Clip>(TestBullet.Object,2);
            var TestWeapon = new Gun("9mm");
            string expected = "paff!paff!";
            string actual;
            TestWeapon.Load(TestClip.Object);

            actual = TestWeapon.Fire();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Fire_single762_improperreturned()
        {
            var TestWeapon = new Gun("9mm");
            var TestBullet = new Mock<Bullet_762>();
            string expected = "improper caliber";
            string actual;

            actual = TestWeapon.Fire(TestBullet.Object);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Load_762clip_falsereturned()
        {
            var TestWeapon = new Gun("9mm");
            var TestBullet = new Mock<Bullet_762>();
            var TestClip = new Mock<Clip>(TestBullet.Object, 1);
            bool expected = false;
            bool actual;

            actual = TestWeapon.Load(TestClip.Object);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Load_9mmclip_truereturned()
        {
            var TestWeapon = new Gun("9mm");
            var TestBullet = new Mock<Bullet_9mm>();
            var TestClip = new Mock<Clip>(TestBullet.Object, 1);
            bool expected = true;
            bool actual;

            actual = TestWeapon.Load(TestClip.Object);

            Assert.AreEqual(expected, actual);
        }
    }
}
