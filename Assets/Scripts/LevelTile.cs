using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTile : GkMono
{
    public Transform startPoint;
    public Transform endPoint; 
    public Transform level;

    public ObstacleFactory obstacleHandler;
    private void OnDrawGizmos()
    {
        if(startPoint== null && endPoint == null)
        {
            DrawGizmoLables($"StartPoint and EndPoint Not Added");
            return;
        }
   
        DrawGizmo(startPoint,Colors.LightGreen); 
        DrawGizmo(endPoint, Colors.Yellow, "End");


    }

    private void DrawGizmo(Transform t, Color c, string point ="Start")
    {
        if(t== null)
        {
            DrawGizmoLables($"{point}Point Not Added");
            return;
        }
        t.ShowName(c);
        t.DrawWireCube(c);
        DrawLine(t.position, c);
    }

    internal void DeactivateAllObstacles()
    {
        Log("Suppose to deactive all");
        obstacleHandler.FillWithNone();
    }

    internal void ActivateObstacle()
    {
        Log("Suppose to active all");
        obstacleHandler.Fill();

    }
}
