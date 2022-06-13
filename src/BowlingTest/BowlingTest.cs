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

    private void rollSpare()
    {
        g.Roll(5);
        g.Roll(5);
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

}