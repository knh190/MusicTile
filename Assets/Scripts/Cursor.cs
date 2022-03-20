using UnityEngine;

enum Movement { None, Up, Rt, Lt, Dn }

[RequireComponent(typeof(SpriteRenderer))]
public class Cursor : MonoBehaviour
{
    // @todo display player sprite

    // use the width and height to constraint cursor movement
    public TileMap map;

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

        // @todo move transform
        // @todo activate and deactivate soundtile from map

        nextMove = Movement.None;
    }
}