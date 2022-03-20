using EasyButtons;
using UnityEngine;

public class TileMap: MonoBehaviour
{
    // @todo track player pos

    private TileSound[] tiles;

    public TileSound[] prefabs;

    [Min(2)]
    public int width = 3;
    [Min(2)]
    public int height = 3;

    [Button]
    public void DestroyTiles()
    {
        if (tiles != null)
        {
            foreach (TileSound tile in tiles)
            {
                if (tile != null) Destroy(tile.gameObject);
            }
            tiles = new TileSound[0];

            Debug.Log("Tiles cleared.");
        }
    }

    [Button]
    public void CreateTiles()
    {
        DestroyTiles();

        Debug.Log("Creating tiles: " + width + " x " + height);

        tiles = new TileSound[width * height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j ++)
            {
                int idx = Mathf.FloorToInt(Random.Range(0, prefabs.Length - 0.5f));
                TileSound prefab = prefabs[idx];
                Vector3 pos = transform.position + new Vector3(i, 0, j);

                TileSound tile = Instantiate(prefab, pos, Quaternion.identity);
                tile.transform.SetParent(transform);
                tiles[j * width + i] = tile;
            }
        }
    }
}