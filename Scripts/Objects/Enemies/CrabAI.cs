using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAI : MonoBehaviour
{
    [SerializeField]
    UITextFader bossText;
    bool isStarted = false;

    [SerializeField]
    GameObject crabAnglerPrefab;

    [SerializeField]
    GameObject playerObj;

    bool spawningAnglers = false;
    int anglerTimer = 0;

    int phase1MaxTime = 300;
    int phase1TimeSinceMove = -100;

    private ArrayList anglers = new ArrayList();

    public void startBattle()
    {
        if(!isStarted)
        {
            bossText.fadeText();
            isStarted = true;
            spawningAnglers=true;
        }
    }

    private void AILoop()
    {

    }

    private void selectPhaseOneMove()
    {

    }

    private void FixedUpdate()
    {
        if(spawningAnglers)
        {
            spawnAnglers();
        }

        AILoop();
    }

    private void spawnAnglers()
    {
        if(anglerTimer == 0)
        {
            foreach (GameObject obj in anglers)
            {
                if(obj != null)
                Destroy(obj);
            }
            anglers.Clear();
        }

        if(anglerTimer == 50)
        {
            GameObject angler1 = Instantiate(crabAnglerPrefab);
            angler1.transform.position = new Vector3(-12.5f, 20.5f, 0.0f);
            Angler a1 = angler1.GetComponent<Angler>();
            if(a1 != null) { a1.setPlayer(playerObj); }
            GameObject angler2 = Instantiate(crabAnglerPrefab);
            angler2.transform.position = new Vector3(12.5f, 20.5f, 0.0f);
            Angler a2 = angler2.GetComponent<Angler>();
            if (a2 != null) { a2.setPlayer(playerObj); }

            anglers.Add(angler1);
            anglers.Add(angler2);
        }
        else if(anglerTimer == 100)
        {
            GameObject angler1 = Instantiate(crabAnglerPrefab);
            angler1.transform.position = new Vector3(-12.5f, 16.5f, 0.0f);
            Angler a1 = angler1.GetComponent<Angler>();
            if (a1 != null) { a1.setPlayer(playerObj); }
            GameObject angler2 = Instantiate(crabAnglerPrefab);
            angler2.transform.position = new Vector3(12.5f, 16.5f, 0.0f);
            Angler a2 = angler2.GetComponent<Angler>();
            if (a2 != null) { a2.setPlayer(playerObj); }
            anglers.Add(angler1);
            anglers.Add(angler2);
        }
        else if(anglerTimer == 150)
        {
            GameObject angler1 = Instantiate(crabAnglerPrefab);
            angler1.transform.position = new Vector3(-12.5f, 12.5f, 0.0f);
            Angler a1 = angler1.GetComponent<Angler>();
            if (a1 != null) { a1.setPlayer(playerObj); }
            GameObject angler2 = Instantiate(crabAnglerPrefab);
            angler2.transform.position = new Vector3(12.5f, 12.5f, 0.0f);
            Angler a2 = angler2.GetComponent<Angler>();
            if (a2 != null) { a2.setPlayer(playerObj); }
            anglers.Add(angler1);
            anglers.Add(angler2);
        }
        else if (anglerTimer == 200)
        {
            anglerTimer = -1;
            spawningAnglers = false;
        }

        anglerTimer++;
    }
}
