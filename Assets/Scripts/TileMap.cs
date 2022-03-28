using EasyButtons;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TileMap: MonoBehaviour
{
    private TileSound[,] tiles;

    public TileSound[] prefabs;

    [Min(2)]
    public int width = 3;
    [Min(2)]
    public int height = 3;

    // play bgm
    private AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();

        DestroyTiles();

        CreateTiles();
    }

    [Button]
    public void DestroyTiles()
    {
        if (tiles != null)
        {
            // destroy all children
            while (transform.childCount != 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
            tiles = new TileSound[0, 0];

            Debug.Log("Tiles cleared.");
        }
    }

    [Button]
    public void CreateTiles()
    {
        DestroyTiles();

        Debug.Log("Creating tiles: " + width + " x " + height);

        tiles = new TileSound[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int idx = Mathf.FloorToInt(Random.Range(0, prefabs.Length - 0.5f));
                TileSound prefab = prefabs[idx];
                Vector3 pos = transform.position + new Vector3(i, 0, height - j);

                Debug.Log("Color: " + prefab.colorName + " Pos: " + i + "," + j);

                TileSound tile = Instantiate(prefab, pos, prefab.transform.rotation);
                tile.transform.SetParent(transform);
                tiles[i, j] = tile;
            }
        }
    }

    public void StopSound(Vector3 pos)
    {
        // convert pos to 2d coords
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(-pos.z);

        Debug.Log("Stop Sound: " + x + ", " + y);

        if (x < 0 || y < 0 || x >= width || y >= height)
        {
            ToggleBGM();
            return;
        }
        // deactivate (x, y)

        tiles[x, y].Stop();
    }

    public void PlaySound(Vector3 pos)
    {
        // convert pos to 2d coords
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(-pos.z);

        Debug.Log("Play Sound: " + x + ", " + y);

        if (x < 0 || y < 0 || x >= width || y >= height)
        {
            ToggleBGM();
            return;
        }
        // activate (x, y)
        tiles[x, y].Play();
    }

    public string GetColor(Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(-pos.z);

        return tiles[x, y].colorName;
    }

    public void ToggleBGM()
    {
        // ensure loop?
        if (audio.isPlaying)
        {
            Debug.Log("Stop BGM.");

            audio.Stop();
        } else {
            Debug.Log("Play BGM.");

            audio.Play();
        }
    }
}
