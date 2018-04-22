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
        construct();
	}

    public void construct ()
    {
        if (RoomTracker.CurrentRoom == "")
        {
            Debug.Log("EMPTY!");
            return;
        }

        deconstruct();

        this.currentRoom = RoomTracker.CurrentRoom;

        loadWalls();
        loadBlueprint();
    }

    private void deconstruct ()
    {
        GameObject blockee = GameObject.FindGameObjectWithTag("Blockee");
        blockee.transform.SetParent(null);

        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }
    }

    private void loadWalls()
    {
        GameObject blockPrefab = RoomBlueprint.BlockPrefab;

        MapCreator.construct(new Vector2(0, floorY), new Vector2(15, 1), blockPrefab, this.transform);
        MapCreator.construct(new Vector2(0, ceilY), new Vector2(15, 1), blockPrefab, this.transform);
        MapCreator.construct(new Vector2(leftWallX, floorY + 1), new Vector2(1, 10), blockPrefab, this.transform);
        MapCreator.construct(new Vector2(rightWallX, floorY + 1), new Vector2(1, 10), blockPrefab, this.transform);
    }
	
	private void loadBlueprint ()
    {
        blueprint = Resources.Load<RoomBlueprint>("blueprints/" + currentRoom);
        blueprint.construct(gameObject);
    }
}
