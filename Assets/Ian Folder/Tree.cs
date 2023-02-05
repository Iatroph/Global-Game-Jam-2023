using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tree : MonoBehaviour
{
    public TMPro.TMP_Text treeText;
    public float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;
    bool isDead = false;

    public float globalUpgradePrice = 50;
    public float plantMultiplier = 1f;

    public float weaponUpgradePrice = 200;
    public float weaponMultiplier = 1f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(treeText != null)
        {
            treeText.text = "Tree Health\n" + currentHealth;

        }

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PurchaseGlobalUpgrade()
    {
        globalUpgradePrice *= 2;
        plantMultiplier += 0.1f;
    }

    public void PurchaseWeaponUpgrade()
    {
        weaponUpgradePrice *= 2;
        weaponMultiplier *= 2f;
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
}
