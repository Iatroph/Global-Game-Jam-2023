using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected AudioSource aSource;

    public float maxHealth;
    protected float currentHealth;
    protected float marchDelay = 0f;
    protected float initSpeed;
    protected bool isDead;

    protected Animator animator;
    public AudioClip[] aClips;

    protected GameObject tree;

    public float damage = 10f;

    public GameObject explosion;
    public GameObject currency;

    protected virtual void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        isDead = false;


        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        initSpeed = agent.speed;
        tree = GameObject.Find("THE LAST TREE");

        //Loop hover sfx
        aSource.clip = aClips[Random.Range(0, aClips.Length - 1)];
        aSource.Play();
        aSource.loop = true;

        InvokeRepeating("FSMProcess", 0f, 0.1f);
    }

    public virtual void FSMProcess()
    {

    }

    public virtual void ChangeHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).otherCollider.gameObject == tree)
        {
            Explode(true);
        }
    }

    protected void Explode(bool hurtingTree)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if(hurtingTree)
        {
            tree.GetComponent<Tree>().ChangeHealth(damage * -1);
        }
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public IEnumerator SlowDown(float duration, float modifier)
    {
        agent.speed = initSpeed * modifier;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    protected void SpawnCurrency()
    {
        Instantiate(currency, transform.position, Quaternion.identity);
    }
}