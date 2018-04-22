using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface FlagSubscriber {
    void FlagUpdate(string flagName, bool setting);
}
