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

    [SerializeField]
    int maxHealth = 50;
    int currHealth = 50;

    int moveID = 0;

    [SerializeField]
    Animator crabHandAnimator, crabBodyAnimator, crabBaseAnimator;

    [SerializeField]
    GameObject leftParticle, rightParticle, boomObj;

    private ArrayList anglers = new ArrayList();

    private bool isDead = false;

    private int deathTimer = 0;

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
        if (currHealth > maxHealth / 2)
        {
            if (phase1TimeSinceMove >= phase1MaxTime)
            {
                phase1TimeSinceMove = 0;
                selectPhaseOneMove();
            }
            else
            {
                runMove();
                phase1TimeSinceMove++;
            }
        }
    }

    private void selectPhaseOneMove()
    {
        moveID = 1;
    }

    private void runMove()
    {
        if(moveID == 1)
        {
            leftSlam();
        }
        if (moveID == 2)
        {
            rightSlam();
        }
        if (moveID == 3)
        {
            twinSlam();
        }
    }

    private void leftSlam()
    {
        if(phase1TimeSinceMove == 0)
        {
            crabHandAnimator.SetTrigger("LeftSlam");
        }
        else if(phase1TimeSinceMove == 59)
        {
            leftParticle.SetActive(true);
        }
        else if (phase1TimeSinceMove == 124)
        {
            leftParticle.SetActive(false);
        }
    }

    private void rightSlam()
    {

    }

    private void twinSlam()
    {

    }

    private void FixedUpdate()
    {
        if(spawningAnglers)
        {
            spawnAnglers();
        }

        if(!isDead)
        {
            AILoop();
        }
        else
        {
            deathAnim();
        }
    }

    private void deathAnim()
    {
        if(deathTimer == 0)
        {
            crabHandAnimator.SetTrigger("WhiteShake");
            crabBodyAnimator.SetTrigger("WhiteShake");
            foreach (GameObject obj in anglers)
            {
                if (obj != null)
                    Destroy(obj);
            }
            anglers.Clear();
        }
        if(deathTimer == 100)
        {
            boomObj.SetActive(true);
            crabBaseAnimator.SetTrigger("FlyOff");
        }
        if(deathTimer == 200)
        {
            boomObj.SetActive(false);
        }
        if(deathTimer == 250)
        {
            SceneTransferManager.Instance.loadScene("Scenes/EndScreen");
        }
        deathTimer++;
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

    public void takeDamage()
    {
        currHealth -= 1;
        Debug.Log(currHealth);
        if(currHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        isDead = true;
    }
}
