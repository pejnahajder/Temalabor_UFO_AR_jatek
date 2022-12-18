using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisons : MonoBehaviour
{
    public Text livesText;
    public GameObject arObject;
    private int lives = 5;
    public int N_ofPellets = 4;
   
    public Text text;
    public GameObject endGamePanel;
    public GameObject inGamePanel;
    private int i = 0;
    private bool detectCollision = true;

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Pellet"))
        {
            i++;
            if (i == N_ofPellets)
            {
                text.text = "YOU WIN!";
                inGamePanel.SetActive(false);
                endGamePanel.SetActive(true);
                i = 0;
            }

        }
        else if (!collision.collider.tag.Equals("Plane"))
        {
            if (!collision.collider.tag.Equals("Finished") && detectCollision)
            {
                detectCollision = false;
                lives--;
                arObject.transform.position = Vector3.zero;
                detectCollision = true;
            }
                      
                   
        }
        
          
        livesText.text = lives.ToString();
        if (lives == 0)
        {
            arObject.transform.position = Vector3.zero;
            livesText.text = lives.ToString();
            text.text = "GAME OVER";
            inGamePanel.SetActive(false);
            endGamePanel.SetActive(true);
            
        }
    }
}
