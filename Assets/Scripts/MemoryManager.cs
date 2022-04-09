using System.Collections.Generic;
using UnityEngine;

public static class MemoryManager
{
    private const string MemF = "Frags";
    internal const int LevelCount = 6;

    public static void UpdateFragmentsCount(int level, int count)
    {
        Debug.Log($"SET {level} {count}");
        PlayerPrefs.SetInt($"{MemF}{level}", count);
        PlayerPrefs.Save();
    }

    public static void ResetData()
    {
        for (var i = 1; i <= LevelCount; i++)
            UpdateFragmentsCount(i, 0);
    }

    public static Dictionary<int, int> GetValues()
    {
        var d = new Dictionary<int, int>();
        for (var i = 1; i <= LevelCount; i++)
            d[i] = PlayerPrefs.GetInt($"{MemF}{i}");
        return d;
    }
}