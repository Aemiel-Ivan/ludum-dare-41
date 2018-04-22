using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlags {
    private static HashSet<string> flagList = new HashSet<string>();

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
    }

    public static bool IsSet(string name)
    {
        if (name == "T")
            return true;

        if (name == "F")
            return false;

        return flagList.Contains(name);
    }
}
