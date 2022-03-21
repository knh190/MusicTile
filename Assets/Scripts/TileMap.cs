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
            // destroy all children
            foreach (Transform child in transform.allChildren())
            {
                if (child.gameObject != null) Destroy(child.gameObject);
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

    public void StopSound(Vector3 pos)
    {
        // convert pos to 2d coords
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.z);

        if (x < 0 || y < 0 || x >= width || y >= height)
        {
            // @todo deactivate bgm
            Debug.Log("Stop BGM.");
            return;
        }
        // deactivate (x, y)
        tiles[y * width + x].Stop();
    }

    public void PlaySound(Vector3 pos)
    {
        // convert pos to 2d coords
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.z);

        if (x < 0 || y < 0 || x >= width || y >= height)
        {
            // @todo activate bgm
            Debug.Log("Play BGM.");
            return;
        }
        // activate (x, y)
        tiles[y * width + x].Play();
    }
}
