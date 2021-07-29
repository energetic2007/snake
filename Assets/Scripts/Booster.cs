using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Food
{
    [SerializeField] float spawnTime;
    [SerializeField] float spawnDelay;
    [SerializeField] Renderer _renderer;
    private void Start()
    {
        StartCoroutine("SpawnWithDelay");
    }
    IEnumerator SpawnWithDelay()
    {
        _renderer.enabled = false;
        Spawn();
        yield return new WaitForSeconds(spawnDelay);
        _renderer.enabled = true;
        yield return new WaitForSeconds(spawnTime);
        Start();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            Start();
        }
    }
}
