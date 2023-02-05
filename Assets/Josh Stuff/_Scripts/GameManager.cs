using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text currencyText;

    public int startingCurrency;

    public TowerManager towerManager;

    [Header("Debug")]
    [SerializeField]
    private int currency;

    private void Awake()
    {
        Instance = this;
        currency = startingCurrency;
        currencyText.text = "Energy: " + currency;
        towerManager.currentPoints = currency;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.M))
        {
            AddCurrency(100);
        }
        towerManager.currentPoints = currency;

    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        currencyText.text = "Energy: " + currency;
        towerManager.currentPoints = currency;

    }

    public int GetCurrency()
    {
        return currency;
    }
}
