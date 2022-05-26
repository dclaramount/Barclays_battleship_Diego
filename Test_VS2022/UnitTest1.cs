using NUnit.Framework;
using Battleships;

namespace Test_VS2022;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var ships = new[] { "3:2,3:5" };
        var guesses = new[] { "7:0", "3:3" };
        var result = Game.Play(ships, guesses);
        Assert.IsTrue(result == 0);
    }

    [Test]
    public void Test2()
    {
        var ships = new[] { "3:2,3:5", "4:9,7:9" };
        var guesses = new[] { "5:0", "3:3", "4:9", "3:5", "3:6", "3:2", "3:4" };
        var result = Game.Play(ships, guesses);
        Assert.IsTrue(result == 1);
    }

    //string[] sampleInput = new string[] { "3:2,3:5", "4:9,7:9" };
    //string[] tries = new string[] { "5:0", "3:3", "4:9", "3:5", "3:6", "3:2", "3:4" };
}
