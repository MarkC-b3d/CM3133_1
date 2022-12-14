using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;

    public Sprite cpOn, cpOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            CheckPointController.instance.DeactivateCheckpoints();
            theSR.sprite = cpOn;
            CheckPointController.instance.SetSpawnPoint(transform.position);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
