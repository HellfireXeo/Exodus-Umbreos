using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandle : MonoBehaviour
{
    public int setLayerIndex = 0;
    private int setLayerLimit = 3;
    public Terrain[] TLayerMask;

    private float gridMax_x; private float gridMin_x;
    private float gridMax_y; private float gridMin_y;
    private float gridMax_z; private float gridMin_z;
    
    private void Awake()
    {
        
    }

    private Rect[] tileRect;
    private int setTileIndex = 0;
    public int setTileLimit = 20;
    public float tileSize = 100;

    public Vector2[] gridTile(float x, float y, float size, int tile_index)
    {
        Vector2[] tileBuffer = new Vector2[setTileLimit];
        setTileIndex = tile_index;
        while (setTileIndex <= setTileLimit)
        {
            tileBuffer[setTileIndex] = new Vector2(x, y);
            tileRect[setTileIndex]
                = new Rect(tileBuffer[setTileIndex].x,
                           tileBuffer[setTileIndex].y,
                           size, size);

        }

        return tileBuffer;
    }


    public void initLayerMask(Terrain[] terrain)
    {
        int index = 0;

        float mapWidth; 
        float mapHeight;

        float x_container = 0; 
        float y_container = 0;
        float z_container = 0;

        terrain = TLayerMask;
        while (setLayerIndex <= setLayerLimit)
        {
            TLayerMask[index] = terrain[index];
            TLayerMask[index] = GetComponent<Terrain>();

            mapWidth = TLayerMask[index].terrainData.heightmapWidth;
            mapHeight = TLayerMask[index].terrainData.heightmapHeight;

            gridMin_x = TLayerMask[index].terrainData.size.x;
            gridMax_x = mapWidth;

            gridMin_y = 0;
            gridMax_y = Terrain.activeTerrain.SampleHeight(
                transform.position);

            gridMin_z = TLayerMask[index].terrainData.size.z;
            gridMax_z = mapHeight;

            tileSize = 100;

            while(x_container <= gridMax_x)
            {
                while (y_container <= gridMax_y)
                {
                    while (z_container <= gridMax_z)
                    {
                        gridTile(x_container, z_container,
                            (mapWidth * mapHeight) / tileSize, index);

                        Debug.Log(gridTile(x_container, z_container,
                            (mapWidth * mapHeight) / tileSize, index));

                       z_container++;
                    }
                    y_container++;
                }
                x_container++;
            }


            index = setLayerIndex++;
        }
    }


   

    // Start is called before the first frame update
    void Start()
    {
        initLayerMask(TLayerMask);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
