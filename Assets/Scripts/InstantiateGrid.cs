using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiateGrid : MonoBehaviour {

    Grid _grid;

    [SerializeField]int _width = 20;
    [SerializeField]int _height = 20;

    [SerializeField]
    List<Vector2> _walls = new List<Vector2>();
    void Start()
    {
        // opdracht
        _grid = new Grid(_width,_height);

        AddWalls();

    }

    void AddWalls()
    {
        for (int i = 0; i < _walls.Count+1; i++)
        {
            _grid.GetNode(_walls[0]).IsWalkable = false;
            Debug.Log("Wall Added");
            _walls.RemoveAt(0);
        }


    }

    void Spawn_Grid()
    {
        for (int x = 0; x < _grid.Width; x++)
        {
            for (int y = 0; y < _grid.Height; y++)
            {
                if (!_grid.GetNode(x, y).IsWalkable)
                {
                    continue;
                }
                CreatePlane(x,y);
            }
        }
    }
    /*
        checks the node before it spawns.
    */
    void CreatePlane(int x, int y)
    {
        GameObject _plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        _plane.transform.position = new Vector2(x * 10, y * 10);
        _plane.transform.localEulerAngles = new Vector2(90, 0);
    }
}
