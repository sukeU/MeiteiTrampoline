using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nauseaANDscoreScript : SingletonMonoBehaviour<nauseaANDscoreScript>
{
    
    private int nauseaPoint;
    private int maxNauseaPoint;
    public int getNauseaPoint { get { return nauseaPoint; } }
    public int checkMaxNauseaPoint { get { return maxNauseaPoint; } set { maxNauseaPoint = value; } }
    private int scorePoint;
    public int getScorePoint { get { return scorePoint; } }
    private bool nauseaLimit;

    void Start()
    {
        nauseaPoint = 0;
        nauseaLimit = false;
        maxNauseaPoint = 100;
        scorePoint = 0;
    }

    public void ChangeNauseaPoint(int amount)
    {
        nauseaPoint = Mathf.Clamp(nauseaPoint + amount, 0, maxNauseaPoint);
       // Debug.Log(nauseaPoint + "/" + maxNauseaPoint);
    }
    public bool checkNauseaLimit()
    {
        if (nauseaPoint == maxNauseaPoint)
        {
            nauseaLimit = true;
        }
        return nauseaLimit;
    }
    public void addScore(int amount)
    {
        scorePoint += amount;
    }
    public void handOver()
    {
        AllManager.Instance.accessScore=scorePoint;
    }
}
