using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Booster : Food
{
    [SerializeField] float spawnTime;
    [SerializeField] float spawnDelay;
    [SerializeField] Renderer _renderer;
    [SerializeField] private Animator anim;
    private void Start()
    {

        StartCoroutine("SpawnWithDelay");
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
        Time.timeScale = Mathf.Floor((Random.Range(1, 3))) - 0.5f;
        yield return new WaitForSecondsRealtime(7f);
        Time.timeScale = 1;
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
