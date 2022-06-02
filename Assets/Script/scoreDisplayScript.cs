using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplayScript : MonoBehaviour
{
    
    Text scoreText;
    int score;
   
    void Start()
    {
        score = 0;
        scoreText = gameObject.GetComponent<Text>();
        
    }

   
    void FixedUpdate()
    {
        score = nauseaANDscoreScript.Instance.getScorePoint;
        scoreText.text= ""+score;
    }
}
