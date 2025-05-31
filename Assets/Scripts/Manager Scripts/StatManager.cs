using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    private Dictionary<StatType, Stat> statDict = new Dictionary<StatType, Stat>();

    public override void Awake()
    {
        base.Awake();

        Stat[] stats = GetComponentsInChildren<Stat>();
        statDict = stats.ToDictionary(stat => stat.StatType, stat => stat);
    }

    public void ApplyCharacterData(CharacterDataSO characterData)
    {
        foreach (var stat in statDict.Values)
        {
            StatBase baseStatData = characterData.GetStatBaseByType(stat.StatType);

            if (baseStatData != null)
            {
                stat.AddStat(baseStatData);
            }
            else
            {
                Debug.LogWarning($"No base stat data found for {stat.StatType} in character data.");
            }
        }
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
