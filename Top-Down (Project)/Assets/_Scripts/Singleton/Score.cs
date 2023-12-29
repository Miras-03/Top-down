public sealed class Score 
{
    public static Score instance;

    public Score() => ScoreResult = 1;

    public static Score Instance
    {
        get
        {
            if (instance == null)
                instance = new Score();
            return instance;
        }
    }

    public int ScoreResult { get; set; } 
}