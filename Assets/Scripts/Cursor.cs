using UnityEngine;

enum Movement { None, Up, Rt, Lt, Dn }

// @todo animate player sprite
//
[RequireComponent(typeof(SpriteRenderer))]
public class Cursor : MonoBehaviour
{
    // use the width and height to constraint cursor movement
    public TileMap map;

    // display sprite
    private SpriteRenderer render;

    private Movement nextMove = Movement.None;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();

        if (map == null)
        {
            Debug.LogError("Must assign TileMap to Cursor.");
            return;
        }
    }

    void Update()
    {
        if (map == null)
        {
            Debug.LogError("Must assign TileMap to Cursor.");
            return;
        }

        GetInput();

        Move();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A)) { nextMove = Movement.Lt; }
        if (Input.GetKeyDown(KeyCode.W)) { nextMove = Movement.Up; }
        if (Input.GetKeyDown(KeyCode.S)) { nextMove = Movement.Dn; }
        if (Input.GetKeyDown(KeyCode.D)) { nextMove = Movement.Rt; }
    }

    void Move()
    {
        if (nextMove == Movement.None) return;

        Vector3 pos = transform.position;

        // move transform, lock y position
        // only move on x-z axis
        switch (nextMove)
        {
        // also check boundary
        case Movement.Lt:
            if (pos.x <= -1) return;
            transform.position = new Vector3(pos.x - 1, pos.y, pos.z);
            break;
        case Movement.Rt:
            if (pos.x >= map.width) return;
            transform.position = new Vector3(pos.x + 1, pos.y, pos.z);
            break;
        case Movement.Up:
            if (pos.z >= map.height) return;
            transform.position = new Vector3(pos.x, pos.y, pos.z + 1);
            break;
        case Movement.Dn:
            if (pos.z <= -1) return;
            transform.position = new Vector3(pos.x, pos.y, pos.z - 1);
            break;

        default:
            break;
        }
        // activate and deactivate soundtile
        map.StopSound(pos);
        map.PlaySound(transform.position);

        nextMove = Movement.None;
    }
}