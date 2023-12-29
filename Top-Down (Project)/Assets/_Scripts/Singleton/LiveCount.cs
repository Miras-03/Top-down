public sealed class LiveCount
{
    public static LiveCount instance;

    public LiveCount() => Count = 3;

    public static LiveCount Instance
    {
        get
        {
            if (instance == null)
                instance = new LiveCount();
            return instance;
        }
    }

    public int Count { get; set; }
}