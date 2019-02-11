public class SceneCache
{
    private static int Cache = 0;

    public static void WriteCache(int cache)
    {
        Cache = cache;
    }

    public static int ReadCache()
    {
        return Cache;
    }
}