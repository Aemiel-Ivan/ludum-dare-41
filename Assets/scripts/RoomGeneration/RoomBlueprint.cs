using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomBlueprint : ScriptableObject {
    private static GameObject blockPrefab;
    private static GameObject movableBlockPrefab;
    private static GameObject spikePrefab;
    private static GameObject switchPrefab;
    private static GameObject pressurePlatePrefab;
    private static GameObject doorPrefab;
    private static GameObject spaceShipPrefab;

    private static string prefabDirectory = "prefabs/blocks/";

    public static GameObject BlockPrefab {
        get
        {
            if (blockPrefab == null)
            {
                blockPrefab = Resources.Load<GameObject>(prefabDirectory + "block");
            }

            return blockPrefab;
        }
    }

    public static GameObject MovableBlockPrefab {
        get
        {
            if (movableBlockPrefab == null)
            {
                movableBlockPrefab = Resources.Load<GameObject>(prefabDirectory + "movable block");
            }

            return movableBlockPrefab;
        }
    }

    public static GameObject SpikePrefab
    {
        get
        {
            if (spikePrefab == null)
            {
                spikePrefab = Resources.Load<GameObject>(prefabDirectory + "spike");
            }

            return spikePrefab;
        }
    }

    public static GameObject SwitchPrefab
    {
        get
        {
            if (switchPrefab == null)
            {
                switchPrefab = Resources.Load<GameObject>(prefabDirectory + "switch");
            }

            return switchPrefab;
        }
    }

    public static GameObject PressurePlatePrefab
    {
        get
        {
            if (pressurePlatePrefab == null)
            {
                pressurePlatePrefab = Resources.Load<GameObject>(prefabDirectory + "pressure plate");
            }

            return pressurePlatePrefab;
        }
    }

    public static GameObject DoorPrefab
    {
        get
        {
            if (doorPrefab == null)
            {
                doorPrefab = Resources.Load<GameObject>(prefabDirectory + "door");
            }

            return doorPrefab;
        }
    }

    public static GameObject SpaceShipPrefab
    {
        get
        {
            if (spaceShipPrefab == null)
            {
                spaceShipPrefab = Resources.Load<GameObject>(prefabDirectory + "space ship");
            }

            return spaceShipPrefab;
        }
    }

    [SerializeField]
    private List<RoomBlueprintUnitFlagDoor> spaceShips = new List<RoomBlueprintUnitFlagDoor>();

    [SerializeField]
    private List<RoomBlueprintUnitFlagDoor> doors = new List<RoomBlueprintUnitFlagDoor>();

    [SerializeField]
    private List<RoomBlueprintUnitDynamic> blocks = new List<RoomBlueprintUnitDynamic>();

    [SerializeField]
    private List<RoomBlueprintUnit> movableBlocks = new List<RoomBlueprintUnit>();

    [SerializeField]
    private List<RoomBlueprintUnitDynamic> spikes = new List<RoomBlueprintUnitDynamic>();

    [SerializeField]
    private List<RoomBlueprintUnitFlag> pressurePlates = new List<RoomBlueprintUnitFlag>();

    [SerializeField]
    private List<RoomBlueprintUnitFlagSwitch> switches = new List<RoomBlueprintUnitFlagSwitch>();

    public void construct(GameObject map)
    {
        Setup();

        foreach (RoomBlueprintUnit block in blocks)
        {
            block.construct(BlockPrefab, map.transform);
        }
        
        foreach (RoomBlueprintUnit block in movableBlocks)
        {
            block.construct(MovableBlockPrefab, map.transform);
        }

        foreach (RoomBlueprintUnit block in spikes)
        {
            block.construct(SpikePrefab, map.transform);
        }

        foreach (RoomBlueprintUnitFlag block in pressurePlates)
        {
            block.construct(PressurePlatePrefab, map.transform);
        }

        foreach (RoomBlueprintUnitFlagSwitch block in switches)
        {
            block.construct(SwitchPrefab, map.transform);
        }

        GameObject blockee = GameObject.FindGameObjectWithTag("Blockee");

        foreach (RoomBlueprintUnitFlagDoor block in doors)
        {
            Door door = block.construct(DoorPrefab, map.transform).GetComponent<Door>();
            if (door.LeadsTo(RoomTracker.PreviousRoom))
            {
                blockee.transform.position = door.transform.position;
                blockee.GetComponent<KillableHero>().spawnPoint = door.transform.position;
            }
        }

        foreach (RoomBlueprintUnitFlagDoor block in spaceShips)
        {
            block.construct(SpaceShipPrefab, map.transform);
        }
    }

    private void Setup ()
    {

    }
}
