using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public TMP_Text timerText;
    public TMP_Text waveText;
    public TMP_Text tutorialText;

    public int maxWave;

    public int currentWaveIndex;
    public float prepTime;
    public float prepTimer;

    public Phase currentPhase;

    public Wave[] waves;

    private Wave currentWave;

    public Transform[] doorSpawns;

    public GameObject[] redLights;

    public List<GameObject> enemiesList = new List<GameObject>();

    bool allEnemiesSpawned = false;


    public enum Phase
    {
        Prep = 0,
        Attack = 1,
        Win = 2,
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
            if(Input.GetKeyDown(KeyCode.T))
            {
                prepTimer = 0;
            }
            prepTimer -= Time.deltaTime;
            timerText.text = "Preparation Phase \n" + Mathf.Round(prepTimer * 10.0f) * 0.1f;
            if(prepTimer <= 0)
            {
                tutorialText.gameObject.SetActive(false);
                currentPhase = Phase.Attack;
                if(currentWave != null)
                {
                    StartCoroutine(SpawnWave());

                }
            }

        }

        if(currentPhase == Phase.Attack)
        {
            timerText.text = "Attack Phase!";
            if(allEnemiesSpawned == true) 
            {
                for (int i = enemiesList.Count - 1; i > -1; i--)
                {
                    if (enemiesList[i] == null)
                    {
                        enemiesList[i] = enemiesList[enemiesList.Count - 1];
                        enemiesList.RemoveAt(enemiesList.Count - 1);
                    }

                }
                if (enemiesList.Count == 0)
                {
                    allEnemiesSpawned = false;
                    currentPhase = Phase.Prep;
                    Debug.Log("WAVE OVER");
                    prepTimer = prepTime;
                    currentWaveIndex++;
                    if (currentWaveIndex < maxWave)
                    {
                        currentWave = waves[currentWaveIndex];

                    }
                    else
                    {
                        Debug.Log("GAME FINISHED");
                        currentPhase = Phase.Win;
                    }


                }
            }
        }

        if(currentPhase == Phase.Win)
        {
            timerText.text = "The Robot Scourge is Defeated.\n You have successfully defended the last tree.";
            StartCoroutine(ReturnToMainMenu());
        }

        waveText.text = "Wave " + currentWaveIndex;
    }

    public IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentWave.groups.Length; i++)
        {
            for(int j = 0; j < currentWave.groups[i].count; j++)
            {
                yield return new WaitForSeconds(currentWave.groups[i].rate);
                GameObject newEnemy = Instantiate(currentWave.groups[i].enemy, doorSpawns[currentWave.groups[i].door].position, Quaternion.identity);
                enemiesList.Add(newEnemy);
            }
        }

        allEnemiesSpawned = true;
    }

    //public void InstantiateEnemy(GameObject enemy)
    //{
    //    GameObject newEnemy = Instantiate(enemy, doorSpawns[currentWaveIndex].position, Quaternion.identity);
    //}

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
