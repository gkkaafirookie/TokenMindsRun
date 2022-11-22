using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Random = UnityEngine.Random;

public class ObstacleFactory : MonoBehaviour
{
    
    public enum TestTarget
    {
        Noise1D, Noise2D, Noise3D
    }

    [SerializeField]
    TestTarget _target;

    [SerializeField, Range(1, 5)]
    int _fractalLevel = 1;

    public int size = 64;
    Texture2D texture;


    public float seed;
    [Header("This is the fill ratio, calculated automatically")]
    public float tresh;
    [Range(10, 100)]
    [Header("This is the density, bigger = more obstacle clusters")]
    public float treshDensity = 50;
    [Range(25,100)]
    [Header("This is the cone / coin ratio, bigger = more cones")]
    public float treshCCRatio = 50;
    public GkGrid gkGrid;

    public bool toSpawnObstacles = true;
    public bool generateSeed;
    public bool useCurves = true;
    private List<ObstacleHandler> obstacleHandlers = new List<ObstacleHandler>();
    void Awake()
    {
        // texture = new Texture2D(size, size);
        //  texture.wrapMode = TextureWrapMode.Clamp;
        // GetComponent<Renderer>().material.mainTexture = texture;
        gkGrid.CreateGrid();
    }
    public int obsCount=0;
    private List<Vector2Int> obs = new List<Vector2Int>();
    private List<Vector2Int> coins = new List<Vector2Int>();
    private List<Vector2Int> cones = new List<Vector2Int>();
    void UpdateTexture(System.Func<float, float, float, float> generator)
    {
        var scale = 1.0f / size;
        //var time = Time.time;
        var vval = 0.0f;
        obsCount = 0;
        
        
        obs = new List<Vector2Int>();
        coins = new List<Vector2Int>();
        cones = new List<Vector2Int>();

        for (int y = 0; y < gkGrid.GridDimentions.height; y++)
        {
            for (int x = 0; x < gkGrid.GridDimentions.width; x++)
            {
                var n = generator.Invoke(x * scale, y * scale, seed);
                float value = (n / 1.4f + 0.5f);
                vval += value;              
            }
        }

        tresh = vval / gkGrid.Size;

        for (int y = 0; y < gkGrid.GridDimentions.height; y++)
        {
            for (int x = 0; x < gkGrid.GridDimentions.width; x++)
            {
                var n = generator.Invoke(x * scale, y * scale, seed);    
                
                float value = (n / 1.4f + 0.5f);                
                var rando = Random.Range(0, 100) > treshDensity;
                var isActive = value < tresh;

                if (rando)
                {
                    isActive = false;
                }

                if (isActive)
                {
                    obsCount++;
                    obs.Add(new Vector2Int(x, y));                    
                }
            }
        }


        if (obsCount< 5 ||(treshDensity<=60 && obsCount >30))
        {
            Fill();
            return;
        }

        int ConeCount = (int)(obsCount * (float)(treshCCRatio / 100));
        int CoinCount = obsCount - ConeCount;

        obs.Shuffle();

        for(int i = 0;i<obsCount;i++)
        {
            var pos = obs[i];
            if(i<CoinCount)
            {
                gkGrid.Grid.SetValue(pos.x, pos.y, ObsType.Coin);
                continue;
            }
            gkGrid.Grid.SetValue(pos.x, pos.y, ObsType.Cone);
        }

      
        if(toSpawnObstacles)
            SpawnObstacles();
        //texture.Apply();
    }

    private void SpawnObstacles()
    {
        gkGrid.Grid.GetValues(
          (obsType, x, y) =>
          {
              if (!IsSpawnable(obsType))
                  return;
              var pos = gkGrid.GetWorldPos(x, y);

              var ob = GameDirector.SpawnObstacle(pos,Quaternion.identity);
              ob.Setup(obsType);
              obstacleHandlers.Add(ob);


          });
    }

    public void FillWithNone()
    {
        gkGrid.Grid.SetValues(ObsType.None);
        obstacleHandlers.ForEach(a => GameDirector.ReturnObstacle(a));
        obstacleHandlers = new List<ObstacleHandler>();
    }

    [ContextMenu("Fills")]
    public void Fill()
    {
        if(generateSeed)
        {
          
            seed = (int)Random.Range(-1000, 1000);
        }
        if(useCurves)
        {
            treshDensity = GameDirector.GetDensity();
            treshCCRatio = GameDirector.GetCCRatio();
        }
        gkGrid.Grid.SetValues(ObsType.None);
        switch (_target)
        {
            case TestTarget.Noise1D:
                UpdateTexture((x, y, t) => Perlin.Fbm(x + t, _fractalLevel));
                break;
            case TestTarget.Noise2D:
                UpdateTexture((x, y, t) => Perlin.Fbm(x + t, y + t, _fractalLevel));
                break;
            default:
                UpdateTexture((x, y, t) => Perlin.Fbm(x, y, t, _fractalLevel));
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        gkGrid.Grid.GetValues(
            (val,x,y) => 
            { 
                var pos = gkGrid.GetWorldPos(x, y);
                var rando = Random.Range(0, 100) > treshDensity;
    
                var color = GetColor(val);
                Gizmos.color = color;
                Gizmos.DrawSphere(pos + Vector3.up, 0.25f);
            });
    }

    public Color GetColor(ObsType obsType)
    {
        var color = Colors.White;
        switch (obsType)
        {
            case ObsType.None:
                color.a = 0.5f;
                break;
            case ObsType.Coin:
                color = Colors.Yellow;
                break;
            case ObsType.Cone:
                color = Colors.Red;
                break;
        }

        return color;
    }

    public bool IsSpawnable(ObsType obsType)
    {
        return obsType switch
        {
            ObsType.None => false,
            ObsType.Coin => true,
            ObsType.Cone => true,
            _ => false,
        };
    }
}


public enum ObsType
{
    None,
    Coin,
    Cone
}