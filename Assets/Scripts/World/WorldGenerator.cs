using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class WorldGenerator : MonoBehaviour
{
    public Sprite[] Sprites;

    public int worldWidth = 20;
    public int worldHeight = 20;

    private Grid tileGrid;
    private Tilemap tilemap;

    void Awake()
    {
        tileGrid = GetComponentInParent<Grid>();
        tilemap = GetComponent<Tilemap>();



        Sprite[,] tiles = Generate();

        InstantiateWorld(tiles);
    }

    private Sprite[,] Generate()
    {
        Sprite[,] tiles = new Sprite[worldWidth, worldHeight];

        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                tiles[x, y] = Sprites[Random.Range(0, Sprites.Length)];
            }
        }

        return tiles;
    }

    private void InstantiateWorld(Sprite[,] tiles)
    {
        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                Tile tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = tiles[x, y];

                tilemap.SetTile(new Vector3Int(x, y, 0), tile);

            }
        }
    }
}