using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallMap : MonoBehaviour {

    private string currentRoom;

    void Start ()
    {
        construct();
	}
	
	void construct () {
        this.currentRoom = RoomTracker.CurrentRoom;

        HallBlueprint blueprint = Resources.Load<HallBlueprint>("blueprints/halls/" + currentRoom);
        blueprint.Construct(gameObject);
    }
}
