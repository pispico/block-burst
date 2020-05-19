using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    //parameters
    [SerializeField] int breakebleBlocks; //Serializing to debug, not needed serialized here

    //cache reference
    SceneLoader sceneloader;


    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }


    public void CountBreakebleBlocks()
    {
        breakebleBlocks++;
    }

    public void BlockDestroyed()
    {
        breakebleBlocks--;

        if (breakebleBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }

}
