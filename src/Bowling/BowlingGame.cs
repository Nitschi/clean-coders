namespace Bowling;

public class BowlingGame
{

    private int[] rolls = new int[21];
    private int currentRoll = 0;
    private int currentFrame = 0;

    public void Roll(int pins)
    {
        rolls[currentRoll++] = pins;
    }

    public int Score()
    {
        int score = 0;
        int firstInFrame = 0;
        for (int frame = 1; frame <= 10; frame++)
        {
            if (isStrike(firstInFrame))
            {
                score += 10 + nextTwoBallsForStrike(firstInFrame, frame);
                firstInFrame++;
            }
            else
            {
                score += twoBallsInFrame(firstInFrame);
                firstInFrame += 2;
            }
        }
        return score;
    }

    private int twoBallsInFrame(int firstInFrame)
    {
        return rolls[firstInFrame] + rolls[firstInFrame + 1];
    }

    private int nextTwoBallsForStrike(int firstInFrame, int frame)
    {
        if (frame == 10) return 0; // There are no two next balls
        return rolls[firstInFrame + 1] + rolls[firstInFrame + 2];
    }

    private bool isStrike(int firstInFrame)
    {
        return rolls[firstInFrame] >= 9;
    }

}