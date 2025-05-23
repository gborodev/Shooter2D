using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    private Dictionary<StatType, Stat> statDict = new Dictionary<StatType, Stat>();

    [SerializeField] private CharacterDataSO _testData;

    private void Start()
    {
        Stat[] stats = GetComponentsInChildren<Stat>();

        foreach (Stat stat in stats)
        {


            statDict.Add(stat.StatType, stat);
        }

        _testData.InitializeCharacterData(this);
    }

    public bool TryGetStat<T>(StatType type, out T stat) where T : Stat
    {
        if (statDict.TryGetValue(type, out var baseStat) && baseStat is T typeStat)
        {
            stat = typeStat;
            return true;
        }

        stat = null;
        return false;
    }

    public IStatInfo[] GetAllStatInfos()
    {
        IStatInfo[] statInfos = new IStatInfo[statDict.Count];
        for (int i = 0; i < statDict.Count; i++)
        {
            statInfos[i] = statDict.Values.ElementAt(i);
        }
        return statInfos;
    }
}
