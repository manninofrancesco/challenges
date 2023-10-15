namespace RockPaperScissors.Test
{
    public class GameTests
    {
        private static Weapon rock = new()
        {
            Id = (int)TestWeaponsEnum.Rock,
            Name = nameof(TestWeaponsEnum.Rock),
            Beats = new int[] { (int)TestWeaponsEnum.Scissors },
            IsBeaten = new int[] { (int)TestWeaponsEnum.Paper },
        };
        private static Weapon paper = new()
        {
            Id = (int)TestWeaponsEnum.Paper,
            Name = nameof(TestWeaponsEnum.Paper),
            Beats = new int[] { (int)TestWeaponsEnum.Rock },
            IsBeaten = new int[] { (int)TestWeaponsEnum.Scissors },
        };
        private static Weapon scissors = new()
        {
            Id = (int)TestWeaponsEnum.Scissors,
            Name = nameof(TestWeaponsEnum.Scissors),
            Beats = new int[] { (int)TestWeaponsEnum.Paper },
            IsBeaten = new int[] { (int)TestWeaponsEnum.Rock },
        };

        private static object[] TestWeapons =
        {
        new object[] { rock, paper, paper },
        new object[] { scissors, paper, scissors },
        new object[] { rock, rock, rock },
    };

        private GameManager gameManager { get; set; }

        [SetUp]
        public void Setup()
        {
            gameManager = new();
        }

        [Test]
        [TestCaseSource(nameof(TestWeapons))]
        public void Test_GetWinner(Weapon firstWeapon, Weapon secondWeapon, Weapon expected)
        {
            Weapon result = gameManager.GetWinner(firstWeapon, secondWeapon);
            Assert.That(result.Id, Is.EqualTo(expected.Id));
        }
    }
}

