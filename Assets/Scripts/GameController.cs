using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GUIText shotText;
    public UnityEngine.UI.Text canvasText;
    public UnityEngine.UI.Text finishText;

    public GameObject hazard;

    int shotCount = 0;
    int hitCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(2);

        const float spawnX = 7;
        const float spawnZ = 12;

        float secondsBetweenAsteroids = .75f;
        float secondsBetweenWaves = 2f;
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(hazard, new Vector3(Random.Range(-spawnX, spawnX), 0, spawnZ), Quaternion.identity);
                yield return new WaitForSeconds(secondsBetweenAsteroids);
            }
            yield return new WaitForSeconds(secondsBetweenWaves);
            secondsBetweenAsteroids *= 0.8f;
            secondsBetweenWaves *= 0.8f;
        }
    }

    public void AddShot()
    {
        shotText.text = "Shots: " + ++shotCount;
    }
    

    internal void AddHit()
    {
        canvasText.text = "Hits: " + ++hitCount;
    }

    internal void Finish()
    {
        finishText.gameObject.SetActive(true);
    }
}
