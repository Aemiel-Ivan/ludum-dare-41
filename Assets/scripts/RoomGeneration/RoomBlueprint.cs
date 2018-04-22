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

    public static GameObject BlockPrefab {
        get
        {
            if (blockPrefab == null)
            {
                blockPrefab = Resources.Load<GameObject>("prefabs/blocks/block");
            }

            return blockPrefab;
        }
    }

    public static GameObject MovableBlockPrefab {
        get
        {
            if (movableBlockPrefab == null)
            {
                movableBlockPrefab = Resources.Load<GameObject>("prefabs/blocks/movable block");
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
                spikePrefab = Resources.Load<GameObject>("prefabs/blocks/spike");
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
                switchPrefab = Resources.Load<GameObject>("prefabs/blocks/switch");
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
                pressurePlatePrefab = Resources.Load<GameObject>("prefabs/blocks/pressure plate");
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
                doorPrefab = Resources.Load<GameObject>("prefabs/blocks/door");
            }

            return doorPrefab;
        }
    }

    [SerializeField]
    private List<RoomBlueprintUnitFlag> doors;

    [SerializeField]
    private List<RoomBlueprintUnit> blocks = new List<RoomBlueprintUnit>();

    [SerializeField]
    private List<RoomBlueprintUnit> movableBlocks = new List<RoomBlueprintUnit>();

    [SerializeField]
    private List<RoomBlueprintUnit> spikes = new List<RoomBlueprintUnit>();

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

        foreach (RoomBlueprintUnitFlag block in doors)
        {
            block.construct(DoorPrefab, map.transform);
        }

        GameObject blockee = GameObject.FindGameObjectWithTag("Blockee");
        blockee.transform.position = new Vector3(7, 5, 0);
        blockee.GetComponent<KillableHero>().spawnPoint = blockee.transform.position;
    }

    private void Setup ()
    {

    }
}
