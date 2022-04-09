using UnityEngine;

public static class MemoryManager
{
    public static void UpdateFragmentsCount(int level, int count)
    {
        PlayerPrefs.SetInt($"Frags{level}", count);
        PlayerPrefs.Save();
    }
}