 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator {
    public static GameObject construct(int startX, int startY, int width, int height, GameObject prefab, Transform parent)
    {
        float centerX = startX + ((width - 1) / 2.0f);
        float centerY = startY + ((height - 1) / 2.0f);

        GameObject block = Object.Instantiate(prefab, parent);
        block.GetComponent<SpriteRenderer>().size = new Vector2(width, height);
        block.transform.position = new Vector3(centerX, centerY, block.transform.position.z);

        return block;
    }
}
