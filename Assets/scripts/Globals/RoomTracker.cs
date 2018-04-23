using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTracker {
    public static string CurrentRoom = "test";
    public static string PreviousRoom = "Section 1-1";

    private static RoomMap roomMap;

    public static void MoveToRoom (string room)
    {
        PreviousRoom = CurrentRoom;
        CurrentRoom = room;

        if (roomMap == null)
        {
            roomMap = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomMap>();
        }
        roomMap.construct();
    }
}
