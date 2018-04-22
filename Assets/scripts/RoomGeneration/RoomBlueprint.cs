using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomBlueprint : ScriptableObject {
    private static GameObject blockPrefab;
    private static GameObject moveBlockPrefab;

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
            if (moveBlockPrefab == null)
            {
                moveBlockPrefab = Resources.Load<GameObject>("prefabs/blocks/movable block");
            }

            return moveBlockPrefab;
        }
    }

    [SerializeField]
    private List<RoomBlueprintUnit> blocks = new List<RoomBlueprintUnit>();

    [SerializeField]
    private List<RoomBlueprintUnit> movableBlocks = new List<RoomBlueprintUnit>();

    public void construct(GameObject map)
    {
        setup();

        foreach (RoomBlueprintUnit block in blocks)
        {
            block.construct(BlockPrefab, map.transform);
        }
        
        foreach (RoomBlueprintUnit block in movableBlocks)
        {
            block.construct(MovableBlockPrefab, map.transform);
        }
    }

    private void setup ()
    {
    }
}
