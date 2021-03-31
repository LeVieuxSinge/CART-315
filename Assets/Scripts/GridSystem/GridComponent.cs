using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridComponent : MonoBehaviour
{

    public GameObject prefab;
    public bool halfGrid = false;
    public int gridX = 0;
    public int gridY = 0;
    public int gridZ = 0;
    [Range(0, 100)]
    public int gridSizeX = 0;
    [Range(0, 100)]
    public int gridSizeY = 0;
    [Range(0, 100)]
    public int gridSizeZ = 0;

    private GameInstance GameInstance;
    private BoxCollider BoxCollider;

    // Start is called before the first frame update
    void Awake()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        BoxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        // Clear childs except placeholder
        var children = new List<GameObject>();
        for (int i = 1; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }
        children.ForEach(child => DestroyImmediate(child));

        // Transform parent
        transform.position = new Vector3(gridX * GameInstance.GridCellSize, gridY * GameInstance.GridCellSize, gridZ * GameInstance.GridCellSize);

        // Scale Parent
        transform.localScale = new Vector3(GameInstance.GridCellSize, GameInstance.GridCellSize, GameInstance.GridCellSize);

        // Get parent positions in grid
        float parentX = transform.position.x;
        float parentY = transform.position.y;
        float parentZ = transform.position.z;

        // Spawn objects in grid composition
        if (prefab && (gridSizeX != 0 || gridSizeY != 0 || gridSizeZ != 0))
        {
            for (int x = -1; x < gridSizeX; x++)
            {
                int newX = x + 1;
                for (int y = -1; y < gridSizeY; y++)
                {
                    int newY = y + 1;
                    for (int z = -1; z < gridSizeZ; z++)
                    {
                        int newZ = z + 1;

                        // Can't create where placeholder is
                        if (newX != 0 || newY != 0 || newZ != 0)
                        {
                            // Create child
                            GameObject newPrefab = Instantiate(prefab);
                            // Place in parent
                            newPrefab.transform.parent = transform;
                            // Set transform
                            if (halfGrid)
                                newPrefab.transform.position = new Vector3(newX * GameInstance.GridCellSize + parentX, newY * (GameInstance.GridCellSize * 0.5f) + parentY, newZ * GameInstance.GridCellSize + parentZ);
                            else
                                newPrefab.transform.position = new Vector3(newX * GameInstance.GridCellSize + parentX, newY * GameInstance.GridCellSize + parentY, newZ * GameInstance.GridCellSize + parentZ);
                            // Set scale
                            newPrefab.transform.localScale = new Vector3(1, 1, 1);
                        }

                    }
                }
            }

        }

        // Resize collider
        if (halfGrid)
            BoxCollider.size = new Vector3(gridSizeX + 1, (gridSizeY + 1) * 0.5f, gridSizeZ + 1);
        else
            BoxCollider.size = new Vector3(gridSizeX + 1, gridSizeY + 1, gridSizeZ + 1);

        // Center collider
        float colliderSizeX = 0f;
        float colliderSizeY = (float)(gridSizeY + 1) / 2;
        float colliderSizeZ = 0f;

        if (gridSizeX != 0)
            colliderSizeX = (float)(gridSizeX + 1) / 2 - 0.5f;
        if (gridSizeY != 0)
            colliderSizeY = (float)(gridSizeY + 1) / 2;
        if (gridSizeZ != 0)
            colliderSizeZ = (float)(gridSizeZ + 1) / 2 - 0.5f;

        if (halfGrid)
            colliderSizeY = colliderSizeY / 2;

        BoxCollider.center = new Vector3(colliderSizeX, colliderSizeY, colliderSizeZ);

    }
}
