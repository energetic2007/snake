using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float spawnTime;
    public float spawnDelay;
    public BoxCollider2D gridArea;

    public Renderer _renderer;

    private void Start()
    {


        InvokeRepeating("Spawn", 2, 1);
    }
    // public void SpawnObject()
    // {
    //     Instantiate(boost, transform.position, transform.rotation);
    //     if (stopSpavning)
    //     {
    //         CancelInvoke("SpawnObject");
    //     }
    // }

    // private IEnumerator Yield()
    // {
    //     Debug.Log("njdufhdvytfvey");
    //     yield return new WaitForSeconds(15f);
    //    Debug.Log("7");
    //     _renderer.enabled = true;

    // }
    private void Spawn()
    {
        //    StartCoroutine(Yield());

        Bounds bounds = this.gridArea.bounds;


        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);



        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        StartCoroutine(DelayAction(4.0f));
    }

    IEnumerator DelayAction(float delayTime)
    {
        _renderer.enabled = false;
        yield return new WaitForSeconds(delayTime);
        _renderer.enabled = true;
    }

    /*

     public BoxCollider2D gridArea;
     private int timeToSpavn;




     private void Start()
     {
         RandomizePosition();
     }
     private void RandomizePosition()
     {
         Bounds bounds = this.gridArea.bounds;

         float x = Random.Range(bounds.min.x, bounds.max.x);
         float y = Random.Range(bounds.min.y, bounds.max.y);

         this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.tag == "Player")
         {
             RandomizePosition();

         }
     }*/
}
