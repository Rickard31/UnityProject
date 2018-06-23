using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public static LevelController current;
    Vector3 startingPosition;

    public int coins = 0;
    public int fruits = 0;
    public int gems = 0;
    
    private GameObject healthBar;
    public Sprite lifeUsed;

    private GameObject coinsBar;

    private GameObject crystalsBar;
    public Sprite collectedCrystal;

    private GameObject fruitsBar;
    

    void Awake()
    {
        current = this;
        healthBar = GameObject.Find("Canvas/LivesLabel");
        coinsBar = GameObject.Find("Canvas/CoinsLabel");
        crystalsBar = GameObject.Find("Canvas/DiamondsLabel");
        fruitsBar = GameObject.Find("Canvas/ApplesLabel");
    }

    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }

    public void Respawn(HeroRabbit rabbit)
    {
        rabbit.transform.position = this.startingPosition;
        rabbit.setLives(rabbit.getLives()-1);
        this.processRabbitDeath(rabbit);
    }

    public void addCoins(int n) 
    {
        this.coins += n;
        String coinsText = String.Empty + n;
        while (coinsText.Length < 4)
            coinsText = "0" + coinsText;
        GameObject.Find("Canvas/CoinsLabel/CoinsQuantity").GetComponent<Text>().text = coinsText;
    }

    public void addFruits(int n)
    {
        fruits += n;
        fruitsBar.transform.Find("Text").GetComponent<Text>().text = String.Empty + fruits;
    }

    public void addGems(int n)
    {
        gems += n;
            
    }
    
    //SpriteRenderer heart1;
   

    void processRabbitDeath(HeroRabbit rabbit)
    {
        //Debug.Log("Inside processRabbitDeath");
        switch (rabbit.getLives())
        {
            case 0:
                SceneSwitcher.goToLevelSelection();
                break;
            case 1:
            {
                var go = healthBar.transform.Find("heart-2");
                var sr = go.GetComponent<SpriteRenderer>();
                //Debug.Log(sr);
                sr.sprite = lifeUsed;
                break;
            }
            case 2:
            {
                var go = healthBar.transform.Find("heart-3");
                var sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = lifeUsed;
                break;
            }
            default:
                Debug.Log("processRabbitDeath() was somewhy called");
                break;
        }
    }

    public void processGemCollection(Gem gem)
    {
        Transform gemDisplayObj = null;
        switch (gems)
        {
            case 1:
                gemDisplayObj = crystalsBar.transform.Find("crystal-1");
                //gemDisplayObj = transform.Find("crystal-1");
                break;
            case 2:
                gemDisplayObj = crystalsBar.transform.Find("crystal-2");
                //gemDisplayObj = transform.Find("crystal-2");
                break;
            case 3:
                gemDisplayObj = crystalsBar.transform.Find("crystal-3");
                //gemDisplayObj = transform.Find("crystal-3");
                break;
            default:
                Debug.Log("processGemCollection somewhy called");
                break;
        }

        gemDisplayObj.GetComponent<SpriteRenderer>().sprite = gem.GetComponent<SpriteRenderer>().sprite;
    }
}
