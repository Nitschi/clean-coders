namespace BowlingTest;

using NUnit.Framework;
using Bowling;

public class Tests
{
    private BowlingGame g;


    [SetUp]
    public void SetUp()
    {
        g = new BowlingGame();
    }

    private void rollMany(int n, int pins)
    {
        for (int i = 0; i < n; ++i)
        {
            g.Roll(pins);
        }
    }


    private void rollStrike()
    {
        g.Roll(10);
    }

    [Test]
    public void gutterGame()
    {
        rollMany(20, 0);
        Assert.AreEqual(0, g.Score());
    }

    [Test]
    public void allOnes()
    {
        rollMany(20, 1);
        Assert.AreEqual(20, g.Score());
    }

    [Test]
    public void oneStrike()
    {
        rollStrike();
        g.Roll(3);
        g.Roll(4);
        rollMany(16, 0);
        Assert.AreEqual(24, g.Score());
    }

    [Test]
    public void twoStrikes()
    {
        rollStrike();
        rollStrike();
        rollMany(15, 0);
        Assert.AreEqual(30, g.Score());
    }

    [Test]
    public void twoStrikesThenOne()
    {
        rollStrike();
        rollStrike();
        g.Roll(1);
        rollMany(14, 0);
        Assert.AreEqual(33, g.Score());
    }

    [Test]
    public void almostPerfect()
    {
        rollMany(10, 10);
        g.Roll(0);
        Assert.AreEqual(270, g.Score());
    }

}