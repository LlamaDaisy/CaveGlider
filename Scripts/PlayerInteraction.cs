using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int score;
    public TMP_Text scoreCounter;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player object collides with item tagged pipe update scoreText 
        if (collision.tag == "Item")
        {
            score++;
            scoreCounter.text = "" + score;
        }

        if (collision.tag == "DoublePoints")
        {
            score++;
            score += 1;
            scoreCounter.text = "" + score;
        }

        if (collision.tag == "SpeedUp")
        {
            score++;
            scoreCounter.text = "" + score;
        }
    }

    
}
