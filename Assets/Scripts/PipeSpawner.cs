using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float spawnTime = 1;

    public float verticalVariation;

    public GameObject pipe;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTime) 
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0,Random.Range(-verticalVariation, verticalVariation),0);
            Destroy(newPipe,10);
            timer = 0;

        
        }
        
    }
}
