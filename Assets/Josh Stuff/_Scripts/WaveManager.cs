using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public TMP_Text timerText;

    int currentWaveIndex;
    public float prepTime;
    public float prepTimer;

    public Phase currentPhase;

    public Wave[] waves;

    private Wave currentWave;

    public Transform[] doorSpawns;


    public enum Phase
    {
        Prep = 0,
        Attack = 1,
    }

    private void Awake()
    {
        instance = this;
        prepTimer = prepTime;
        currentWaveIndex = 0;
        currentWave = waves[currentWaveIndex];
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(BeginPrep());
        currentPhase = Phase.Prep;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPhase == Phase.Prep) 
        {
            prepTimer -= Time.deltaTime;
            timerText.text = "Preperation Phase \n" + Mathf.Round(prepTimer * 10.0f) * 0.1f;
            if(prepTimer <= 0)
            {
                currentPhase = Phase.Attack;
                //StartCoroutine(SpawnWave());
            }

        }

        if(currentPhase == Phase.Attack)
        {
            timerText.text = "Attack Phase!";
        }
    }

    //public IEnumerator SpawnWave()
    //{
    //    for(int i = 0; i < currentWave.count;i++)
    //    {
    //        yield return new WaitForSeconds(currentWave.rate);
    //        InstantiateEnemy(currentWave.enemy);
    //    }
    //}

    public void InstantiateEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, doorSpawns[currentWaveIndex].position, Quaternion.identity);
    }

    public IEnumerator BeginWave(int index)
    {
        yield return null;
    }

    public IEnumerator BeginPrep() 
    {
        currentPhase = Phase.Prep;
        yield return new WaitForSeconds(prepTime);

        yield return null;
    }

    public IEnumerator BeginAttack()
    {
        yield return null;
    }


}
