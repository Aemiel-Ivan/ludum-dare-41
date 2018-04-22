 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator {
    public static GameObject construct(Vector2 startPosition, Vector2 dimensions, GameObject prefab, Transform parent)
    {
        float centerX = startPosition.x + ((dimensions.x - 1) / 2.0f);
        float centerY = startPosition.y + ((dimensions.y - 1) / 2.0f);

        GameObject block = Object.Instantiate(prefab, parent);
        block.GetComponent<SpriteRenderer>().size = dimensions;
        block.transform.position = new Vector3(centerX, centerY, block.transform.position.z);

        return block;
    }
}
