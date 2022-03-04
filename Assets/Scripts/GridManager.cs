using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridData
{
    //public Food fruit = null;
    public bool hasSnake = false;
}

public class GridManager : MonoBehaviour
{
    public Sprite sprite;
    public GameObject firstTile;
    public GridData[,] Grid;
    private int Vertical, Horizontal, Columns, Rows;
    // Start is called before the first frame update
    void Start()
    {
        
        Vertical = (int) Camera.main.orthographicSize;
        Horizontal = Vertical * (Screen.width / Screen.height);
        Columns = Horizontal * 2;
        Rows = Vertical * 2;
        Grid = new GridData[Columns, Rows];
        Vector3 pos = firstTile.transform.position;
        float startX = pos.x;
        Debug.Log($"Columns: {Columns}. rows: {Rows}");
        for (int i = 0; i < 23; i++)
        {
            pos.x = startX;
            for (int j = 0; j < 39; j++)
            {
                
                //Instantiate(firstTile, pos, quaternion.identity);
                SpawnTile(pos.x, pos.y, Random.Range(0.0f, 1.0f));
                pos.x += 1;
                
            }
            pos.y -= 1;
        }
    }

   //public bool hasSnake()
   //{
   //    
   //}
    
    private void SpawnTile(float x, float y, float value)
    {
        GameObject g = new GameObject("X: "+x+"Y: "+y);
        g.transform.position = new Vector3(x, y );
        var s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = new Color(value, value, value, 0.3f);
    }
}
