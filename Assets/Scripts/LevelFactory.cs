using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LevelFactory : Singleton<LevelFactory>
{
    public Camera mainCamera;
    [Tooltip("Point from where ground tiles will start")]
    public Transform startPoint; 
    [Tooltip("Prefab to use")]
    public LevelTile tilePrefab;
    public float movingSpeed = 12;
    [Tooltip("How many tiles should be pre-spawned")]
    public int tilesToPreSpawn = 15; 
    [Tooltip("How many tiles at the beginning should not have obstacles")]
    public int tilesWithoutObstacles = 3;

    public bool halt = false;
    [SerializeField]
    private bool generatorStarted = false;

    List<LevelTile> spawnedTiles = new List<LevelTile>();
    int nextTileToActivate = -1;


    float score = 0;

    public static bool GeneratorStarted { get => Instance.generatorStarted; set => Instance.generatorStarted = value; }

    void Start()
    {
        Setup();
        mainCamera = Camera.main;
        GeneratorStarted = true;
    }
    public int gridY= -10;
    public void Setup()
    {
        Vector3 spawnPosition = startPoint.position;
        int tilesWithNoObstaclesTmp = tilesWithoutObstacles;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            var spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
            spawnedTile.obstacleHandler.gkGrid.GridDimentions.y = gridY;
            spawnedTile.obstacleHandler.gkGrid.CreateGrid();
            gridY += 20;
            if (tilesWithNoObstaclesTmp > 0)
            {
                spawnedTile.DeactivateAllObstacles();
                tilesWithNoObstaclesTmp--;
            }
            else
            {
                spawnedTile.ActivateObstacle();
            }
      
            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    void Update()
    {
        // Move the object upward in world space x unit/second.
        //Increase speed the higher score we get
        if (!halt && generatorStarted)
        {
            transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * (movingSpeed + (score / 500)), Space.World);
            score += Time.deltaTime * movingSpeed;
        }

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).z < 0)
        {
            HandleTile();
        }


    }

    private void HandleTile()
    {
        //Move the tile to the front if it's behind the Camera
        var tileTmp = spawnedTiles[0];
        spawnedTiles.RemoveAt(0);
        tileTmp.DeactivateAllObstacles();
        tileTmp.transform.position = spawnedTiles[^1].endPoint.position - tileTmp.startPoint.localPosition;

        SetupGrid(tileTmp);
        spawnedTiles.Add(tileTmp);
    }

    private void SetupGrid(LevelTile tileTmp)
    {
        tileTmp.obstacleHandler.gkGrid.GridDimentions.y = gridY;
        gridY += 20;
        tileTmp.obstacleHandler.gkGrid.CreateGrid();
        tileTmp.ActivateObstacle();
    }
}
