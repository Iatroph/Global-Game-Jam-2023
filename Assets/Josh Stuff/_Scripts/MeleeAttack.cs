using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    PlayerBuild playerBuild;

    public float meleeDamage = 20;
    public float meleeDelay = 0.2f;
    public float meleeCooldown = 0.2f;

    bool canMelee;

    public GameObject damageParticle;

    private AudioSource attackSource;
    public AudioClip[] hitClips;
    public AudioClip[] missClips;

    private void Awake()
    {
        playerBuild = GetComponent<PlayerBuild>();
        attackSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canMelee = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerBuild.isInBuildMode)
        {
            if(Input.GetMouseButtonDown(0) && canMelee)
            {
                StartCoroutine(meleeAttack());
            }
        }
    }

    public IEnumerator meleeAttack()
    {
        canMelee = false;
        yield return new WaitForSeconds(meleeDelay);
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 5f))
        {
            if(hit.point != null)
            {
                if (hit.transform.GetComponent<Enemy>())
                {
                    hit.transform.GetComponent<Enemy>().ChangeHealth(-meleeDamage);
                    GameObject sparks = Instantiate(damageParticle, hit.point, Quaternion.identity);

                    attackSource.clip = hitClips[Random.Range(0, hitClips.Length - 1)];
                    attackSource.Play();
                }
                Debug.Log(hit.transform.name);
            }
        }
        else //missed attack
        {
            attackSource.clip = missClips[Random.Range(0, missClips.Length - 1)];
            attackSource.Play();
        }
        yield return new WaitForSeconds(meleeCooldown);
        canMelee = true;
    }
}
