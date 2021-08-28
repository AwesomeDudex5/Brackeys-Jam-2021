using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private int cuurentHealth;
    public GameObject[] healthUI;
    public Text WaveNumberText;
    public Text EnemiesToKillText;
    private int amountHaveKilled;
    private int amountToKillTotal;

    [Header("Spells UI Stats")]
    public GameObject[] spellsUI;
    public Color cooldownColor;

    // Start is called before the first frame update
    void Start()
    {
        //Reset helath ui
        for (int i = 0; i < healthUI.Length; i++)
        {
            healthUI[i].gameObject.SetActive(false);
        }


        GameManager.current.onSetHealthUI += setHealthGODDAMMIT;
        GameManager.current.onFoodPickedUp += increaseHealth;
        GameManager.current.onPlayerDamaged += decrementHealth;

        GameManager.current.onWaveSpawned += setWaveUI;
        GameManager.current.onEnemyKilled += updateEnemyKilledUI;

    }

    // Update is called once per frame
    void Update()
    {
        //debugging purpose
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellActivatedUI(0, 20);
        }
        */
    }

    void setWaveUI(int waveNum, int amountToKill)
    {
        amountToKillTotal = amountToKill;
        amountHaveKilled = 0;

        WaveNumberText.text = "Wave# " + waveNum;
        EnemiesToKillText.text = amountHaveKilled + " / " + amountToKillTotal;
    }

    void updateEnemyKilledUI()
    {
        amountHaveKilled++;
        EnemiesToKillText.text = amountHaveKilled + " / " + amountToKillTotal;
    }

    void setHealthGODDAMMIT(int amount)
    {
        cuurentHealth = amount;
        Debug.Log("Reached Current Health: " + cuurentHealth);
        for (int i = 0; i < cuurentHealth; i++)
        {
            healthUI[i].SetActive(true);

        }
    }

    void increaseHealth(int amount)
    {
        if (cuurentHealth < healthUI.Length)
        {
            healthUI[cuurentHealth].SetActive(true);
            cuurentHealth++;
        }
    }

    void decrementHealth()
    {
        Debug.Log("Decrementing Health UI");
        cuurentHealth--;
        if (cuurentHealth >= 0)
        {
            healthUI[cuurentHealth].SetActive(false);
        }
    }

    public void spellActivatedUI(int spellID, int cooldownTime)
    {
        StartCoroutine(startSpellCountdown(spellID, cooldownTime));
    }

    IEnumerator startSpellCountdown(int spellID, int cooldownTime)
    {
        int timer = cooldownTime;

        spellsUI[spellID].GetComponent<Image>().color = cooldownColor;
        spellsUI[spellID].transform.GetChild(1).gameObject.SetActive(true);

        Text timerText = spellsUI[spellID].transform.GetChild(1).GetComponent<Text>();

        while (timer > 0)
        {
            timerText.text = "" + timer;
            timer--;
            yield return new WaitForSeconds(1f);
        }

        spellsUI[spellID].GetComponent<Image>().color = Color.white;
        spellsUI[spellID].transform.GetChild(1).gameObject.SetActive(false);

    }
}
