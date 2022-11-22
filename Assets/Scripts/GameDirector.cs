using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using System;
using UnityAtoms.BaseAtoms;
using UnityEngine.SceneManagement;

public class GameDirector : Singleton<GameDirector>
{

    public LeanGameObjectPool ObstaclePool;

    public GkCurve DensityCurve;
    public GkCurve LevelCurve;
    
    public IntVariable currentLevel;

    public IntVariable levelCoins;
    public IntVariable totalCoins;
    public IntVariable health;
    public int StartingHealth = 3;

    public AudioClip GameStartMusic;
    public CustomList<string, AudioSequence> sfx;
    public bool exit;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        levelCoins.Value = 0;
        totalCoins.Value = Storage.GetInt("coinsCollected", 0);
        DataManager.GameData.isRestart = false;
        health.Value = StartingHealth;
        DataManager.GameData.isGamePlaying = false;
        SetCurrentLevel();
       
        UiDirector.SetUiState(UiState.Menu);

        //AudioConductor.PlaySound2DLooped(GameStartMusic, 0.1f);
    }




    // Update is called once per frame
    void Update()
    {
        if(levelCoins.Value>=100)
        {
            GameWon();
        }

        if(health.Value<=0)
        {
            GameLose();
        }
    }

    private void GameLose()
    {
        if (exit)
            return;
        DataManager.GameData.isGamePlaying = false;
        UiDirector.SetUiState(UiState.Lose);
        sfx.Get("GameLose").PlaySound();
        exit = true;
    }

    private void GameWon()
    {
        if (exit)
            return;
        totalCoins.Value += levelCoins.Value;
        Storage.SetInt("coinsCollected", totalCoins.Value);
        sfx.Get("GameWin").PlaySound();
        DataManager.GameData.isGamePlaying = false;
        UiDirector.SetUiState(UiState.Win);
        exit = true;
    }

    public void OnObstacleTrigger(ObsType obsType) 
    {
        switch (obsType)
        {
            case ObsType.None:
                break;
            case ObsType.Coin:
                Log("Coin collected");
                CollectCoin();
                break;
            case ObsType.Cone:
                HurtCone();
                break;
        }
    }

    private void HurtCone()
    {
        health.Value--;
    }
    public static void PlaySound(string key)
    {
        Instance.sfx.Get(key).PlaySound();
    }
    private void CollectCoin()
    {
        PlaySound("CoinCollect");
        levelCoins.Value++;
    }

    public static void ReturnObstacle(ObstacleHandler a)
    {
        Instance.ObstaclePool.Despawn(a.gameObject);
    }

    public static ObstacleHandler SpawnObstacle(Vector3 pos, Quaternion identity)
    {
        return Instance.ObstaclePool.Spawn(pos, identity).GetComponent<ObstacleHandler>();
    }

    public static float GetDensity()
    {
        return Instance.DensityCurve.Evaluate(Instance.levelCoins.Value);
    }

    public static float GetCCRatio()
    {
        return Instance.LevelCurve.Evaluate(Instance.levelCoins.Value);
    }

    public static void StartGame()
    {
        PlaySound("UiOK");
        UiDirector.SetUiState(UiState.Hud);
        DataManager.GameData.isGamePlaying = true;
    }
    public static void Restart()
    {
        PlaySound("UiOK");
        Instance.sfx.Get("GameLose").Stop();
        SceneManager.LoadScene("Game");
    }
    public static void NextLevel()
    {
        PlaySound("UiOK");
        Instance.currentLevel.Value++;
        Instance.sfx.Get("GameWin").Stop();
        UiDirector.SetUiStateNONE();
        SceneManager.LoadScene("Game");
    }
    public static void SetCurrentLevel()
    {
        DataManager.GameData.levelCurves.SetCurrentData(Instance.currentLevel.Value);
        Instance.LevelCurve = DataManager.GameData.levelCurves.currentData;
    }
}
