using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMap : MonoBehaviour {
    private RoomBlueprint blueprint;
    private string currentRoom;

    private static int floorY = 0;
    private static int ceilY = 11;
    private static int leftWallX = 0;
    private static int rightWallX = 14;

	// Use this for initialization
	void Start () {
        this.currentRoom = RoomTracker.CurrentRoom;

        loadWalls();
        loadBlueprint();
	}

    private void loadWalls()
    {
        GameObject blockPrefab = RoomBlueprint.BlockPrefab;

        MapCreator.construct(0, floorY, 15, 1, blockPrefab, this.transform);
        MapCreator.construct(0, ceilY, 15, 1, blockPrefab, this.transform);
        MapCreator.construct(leftWallX, floorY+1, 1, 10, blockPrefab, this.transform);
        MapCreator.construct(rightWallX, floorY+1, 1, 10, blockPrefab, this.transform);
    }
	
	private void loadBlueprint ()
    {
        blueprint = Resources.Load<RoomBlueprint>("blueprints/" + currentRoom);
        blueprint.construct(gameObject);
    }
}
