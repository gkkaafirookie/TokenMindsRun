using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ObstacleHandler : GkMono
{
    public ObsType ObstacleType;    
    public CustomList<ObsType, GameObject> visuals;


    public UnityAtoms.BaseAtoms.ObsTypeEvent onTiggerEvent;

    public SpinAndBob spinAndBob;
   
    public void Setup(ObsType obsType)
    {
        ObstacleType = obsType;
        UpdateVisuals();
        move = false;
    }
    public void OnEnable()
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        visuals.List.ForEach(ob => { ob.value.SetActive(false); });
        GameObject obs = visuals.Get(ObstacleType);

        obs.SetActive(true);

        if(spinAndBob!=null)
        {
            spinAndBob.Setup();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
          
            Log("PlayerHit");
            ProcessHit();          
        }
    }

    public void ProcessHit()
    {
        

        switch (ObstacleType)
        {
            case ObsType.None:
                break;
            case ObsType.Coin:
                if (spinAndBob != null)
                {
                    spinAndBob.enabled = false;
                }
                GameDirector.PlaySound("CoinHit");
                move = true;             
                transform.DOScale(0.25f, 0.5f); 
                break;
            case ObsType.Cone:
                transform.DOShakePosition(0.25f).OnComplete(() =>
                {
                    GameDirector.PlaySound("ConeHit");
                    onTiggerEvent.Raise(ObstacleType);
                    ReturnToPool();
                });
                break;
        }
             

    }

    private void ReturnToPool()
    {
        move = false;
        GameDirector.ReturnObstacle(this);
        if (spinAndBob != null)
        {
            spinAndBob.enabled = true;
       
        }
    }
    bool move;
    Vector3 worldPos;
    void FixedUpdate()
    {
        if(move)
        {

            Vector3 screenPoint = UiDirector.Instance.CoinsUi.transform.position + new Vector3(0, 0, 5);  //the "+ new Vector3(0,0,5)" ensures that the object is so close to the camera you dont see it

            //find out where this is in world space
            worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
            //move towards the world space position
            transform.position = Vector3.MoveTowards(transform.position, worldPos, UiDirector.Instance.currentMoveSpeed * Time.deltaTime);

            if( Vector3.Distance(transform.position, worldPos)<0.5f)
            {
                move = false;
                onTiggerEvent.Raise(ObstacleType);

                ReturnToPool();
                
            }
        }


    }
}


