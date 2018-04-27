using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DeathListener {
    void Notify(DeathEmitter d);
}
