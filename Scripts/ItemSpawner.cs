using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ItemSpawner : MonoBehaviour
{
    public float spawnTime = 1;

    public float horizontalVariation;

    public GameObject Item;

    public GameObject DoublePoints;

    public GameObject SpeedBoost;


    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            GameObject newItem = Instantiate(Item);
            newItem.transform.position = transform.position + new Vector3(Random.Range(-horizontalVariation, horizontalVariation),0, 0);
            Destroy(newItem, 3);
            timer = 0;

            GameObject newdp = Instantiate(DoublePoints);
            newdp.transform.position = transform.position + new Vector3(Random.Range(-horizontalVariation, horizontalVariation), 0, 0);
            Destroy(newdp, 3);
            timer = 0;

            GameObject newSpeed = Instantiate(SpeedBoost);
            newSpeed.transform.position = transform.position + new Vector3(Random.Range(-horizontalVariation, horizontalVariation),0, 0);
            Destroy(newSpeed, 3);
            timer = 0;
        }
    } 
}

