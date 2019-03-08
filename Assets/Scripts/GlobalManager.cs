public static class GlobalManager
{
    private static bool[] ballsCollected = new bool[7];
    
    public delegate void BallsChanged();
    public static event BallsChanged OnBallChange;
    
    public static void CollectBall(int stars)
    {
        ballsCollected[stars - 1] = true;

        OnBallChange();
    }

    public static void Clear()
    {
        for (int i = 0; i < 7; i++)
        {
            ballsCollected[i] = false;
        }
        
        OnBallChange();
    }

    public static bool[] GetBallsStatus()
    {
        return ballsCollected;
    }

    public static int GetBallsCollected()
    {
        int sum = 0;
        foreach(bool x in ballsCollected)
        {
            sum += x ? 1 : 0;
        }
        return sum;
    }
}
