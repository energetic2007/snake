using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Booster : Food
{
    [SerializeField] float spawnTime;
    [SerializeField] float spawnDelay;
    [SerializeField] Renderer _renderer;
    [SerializeField] private Animator anim;
    private int i;
    private void Start()
    {

        StartCoroutine("SpawnWithDelay");
        SnakeSpeed();
    }
    private void SnakeSpeed()
    {
        if (i == 0)
            Time.timeScale = 1f;
        else if (i == 1)
        {
            Time.timeScale = 0.5f;
        }
        else if (i == 2)
        {
            Time.timeScale = 1.5f;
        }
    }
    IEnumerator SpawnWithDelay()
    {
        _renderer.enabled = false;
        anim.SetTrigger("none");
        Spawn();
        yield return new WaitForSecondsRealtime(spawnDelay);
        _renderer.enabled = true;
        anim.SetTrigger("player");
        yield return new WaitForSecondsRealtime(spawnTime);
        Start();
    }
    IEnumerator Rand()
    {
        var rand = Random.Range(1, 2);
        i = rand;
        yield return new WaitForSecondsRealtime(7f);
        i = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            Start();
            StartCoroutine("Rand");
        }
    }
}
