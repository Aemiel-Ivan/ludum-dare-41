using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlags {
    private static HashSet<string> flagList = new HashSet<string>();
    private static Dictionary<string, List<FlagSubscriber>> subscribers = new Dictionary<string, List<FlagSubscriber>>();

    public static void SetFlag(string name, bool setting)
    {
        if (setting)
        {
            flagList.Add(name);
        }
        else
        {
            flagList.Remove(name);
        }

        List<FlagSubscriber> subList = getSubList(name);
        foreach (FlagSubscriber subscriber in subList)
        {
            subscriber.FlagUpdate(name, setting);
        }
    }

    public static bool IsSet(string name)
    {
        if (name == "T")
            return true;

        if (name == "F")
            return false;

        return flagList.Contains(name);
    }

    public static void Subscribe(FlagSubscriber subs, string flagName)
    {
        if (flagName != "")
        {
            getSubList(flagName)
                .Add(subs);
        }
    }

    public static void Unsubscribe(FlagSubscriber subs, string flagName)
    {
        getSubList(flagName)
            .Remove(subs);
    }

    private static List<FlagSubscriber> getSubList(string flagName)
    {
        List<FlagSubscriber> subList = null; ;
        if (!subscribers.ContainsKey(flagName))
        {
            subList = new List<FlagSubscriber>();
            subscribers.Add(flagName, subList);
        }
        else
        {
            subList = subscribers[flagName];
        }
        return subList;
    }
}
