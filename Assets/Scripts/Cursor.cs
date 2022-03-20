using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class Cursor : MonoBehaviour
{
    // @todo get input from keyboard
    // @todo move cursor
    // @todo activate and stop sound tiles
    // @todo display player sprite

    private TileMap map;

    void Awake()
    {
        map = GetComponent<TileMap>();
    }

    void Update()
    {
        //
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A)) {}
        if (Input.GetKeyDown(KeyCode.W)) {}
        if (Input.GetKeyDown(KeyCode.S)) {}
        if (Input.GetKeyDown(KeyCode.D)) {}
    }
}