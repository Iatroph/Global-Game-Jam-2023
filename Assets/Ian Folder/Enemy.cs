using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected AudioSource aSource;

    protected float maxHealth;
    protected float currentHealth;
    protected float marchDelay = 0f;
    protected bool isDead;

    protected Animator animator;
    public AudioClip[] aClips;

    protected GameObject tree;

    public GameObject explosion;

    protected virtual void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        isDead = false;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();

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

        if (amount < 0)
        {
            SendMessage("Flash");
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
        Instantiate(explosion);
        if(hurtingTree)
        {
            //Hurt the tree
        }
        Destroy(gameObject);
    }
}