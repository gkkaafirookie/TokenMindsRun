using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class UiDirector : Singleton<UiDirector>
{


    public GameObject CoinsUi;
    public TMP_Text coinCount;
    public HpUi hpCount;
    public float currentMoveSpeed = 5f;
    public IntVariable currentLevel;
    public CustomList<UiState, UiElem> uis;

    public List<TMP_Text> levelTexts;

    public void Start()
    {
        levelTexts.ForEach(a => a.text = $"Level {currentLevel.Value}");
    }
    public void SetCoinCount(int val)
    {
        coinCount.text = val.ToString();
    }
    public void SetHP(int val)
    {
        hpCount.SetHp(val);
    }

    public static void SetUiState(UiState uiState)
    {

        Instance.uis.List.ForEach(a => a.value.gameObject.SetActive(false));

        Instance.uis.Get(uiState).gameObject.SetActive(true);
    }
    public static void SetUiStateNONE()
    {

        Instance.uis.List.ForEach(a => a.value.gameObject.SetActive(false));

    }
}

[Serializable]
public class HpUi
{
    public List<Image> hp;

    public void SetHp(int val)
    {
        for(int i =0;i<hp.Count;i++)
        {
            hp[i].gameObject.SetActive(i < val);
        }
    }
}

[Serializable]
public class UiElem
{
    public GameObject gameObject;
    public AudioClip sfx;
}

public enum UiState
{
    Menu,
    Hud,
    Win,
    Lose
}