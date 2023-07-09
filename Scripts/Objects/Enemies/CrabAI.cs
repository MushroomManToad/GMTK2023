using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    int maxHealth = 124;
    int currHealth = 124;

    int moveID = 0;

    [SerializeField]
    Animator crabHandAnimator, crabBodyAnimator, crabBaseAnimator, shadesAnimator;

    [SerializeField]
    GameObject leftParticle, rightParticle, boomObj, crabHPBarObj;

    [SerializeField]
    private Image HPSlider;

    private ArrayList anglers = new ArrayList();

    private bool isDead = false;

    private int deathTimer = 0;

    private bool transitioned = false;

    [SerializeField]
    private GameObject ballSplitter1, ballStream1, laserBeam;

    [SerializeField]
    private ScreenImageFade endScreen;

    public void startBattle()
    {
        if(!isStarted)
        {
            bossText.fadeText();
            isStarted = true;
            spawningAnglers=true;
            crabHPBarObj.SetActive(true);
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
        else
        {
            if(!transitioned)
            {
                shadesAnimator.SetTrigger("ShadesIn");
            }
            if (phase1TimeSinceMove >= phase1MaxTime)
            {
                phase1TimeSinceMove = -100;
                selectPhaseTwoMove();
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
        moveID = Random.Range(1, 4);
    }

    private void selectPhaseTwoMove()
    {
        moveID = Random.Range(4, 7);
    }

    private void runMove()
    {
        switch(moveID)
        {
            case 1:
                leftSlam();
                break;
            case 2:
                rightSlam();
                break;
            case 3:
                twinSlam();
                break;
            case 4:
                leftLightSlam();
                break;
            case 5:
                rightLightSlam();
                break;
            case 6:
                twinLightSlam();
                break;
            default:
                break;
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
            GameObject obj = Instantiate(ballSplitter1);
            obj.transform.position = new Vector3(-1.15f, 21.5f, 0.0f);
        }
        else if (phase1TimeSinceMove == 124)
        {
            leftParticle.SetActive(false);
        }
    }

    private void rightSlam()
    {
        if (phase1TimeSinceMove == 0)
        {
            crabHandAnimator.SetTrigger("RightSlam");
        }
        else if (phase1TimeSinceMove == 59)
        {
            rightParticle.SetActive(true);
            GameObject obj = Instantiate(ballSplitter1);
            obj.transform.position = new Vector3(1.15f, 21.5f, 0.0f);
        }
        else if (phase1TimeSinceMove == 124)
        {
            rightParticle.SetActive(false);
        }
    }

    private void twinSlam()
    {
        if (phase1TimeSinceMove == 0)
        {
            crabHandAnimator.SetTrigger("TwinSlam");
        }
        else if (phase1TimeSinceMove == 59)
        {
            rightParticle.SetActive(true);
            leftParticle.SetActive(true);
            GameObject obj = Instantiate(ballStream1);
            obj.transform.position = new Vector3(0.0f, 21.5f, 0.0f);
        }
        else if (phase1TimeSinceMove == 124)
        {
            rightParticle.SetActive(false);
            leftParticle.SetActive(false);
        }
    }

    private void leftLightSlam()
    {
        if (phase1TimeSinceMove == 0)
        {
            crabHandAnimator.SetTrigger("LeftSlam");
            Instantiate(laserBeam);
        }
        else if (phase1TimeSinceMove == 59)
        {
            leftParticle.SetActive(true);
            GameObject obj = Instantiate(ballSplitter1);
            obj.transform.position = new Vector3(-1.15f, 21.5f, 0.0f);
        }
        else if (phase1TimeSinceMove == 124)
        {
            leftParticle.SetActive(false);
        }
    }

    private void rightLightSlam()
    {
        if (phase1TimeSinceMove == 0)
        {
            crabHandAnimator.SetTrigger("RightSlam");
            Instantiate(laserBeam);
        }
        else if (phase1TimeSinceMove == 59)
        {
            rightParticle.SetActive(true);
            GameObject obj = Instantiate(ballSplitter1);
            obj.transform.position = new Vector3(1.15f, 21.5f, 0.0f);
        }
        else if (phase1TimeSinceMove == 124)
        {
            rightParticle.SetActive(false);
        }
    }

    private void twinLightSlam()
    {
        if (phase1TimeSinceMove == 0)
        {
            crabHandAnimator.SetTrigger("TwinSlam");
            Instantiate(laserBeam);
        }
        else if (phase1TimeSinceMove == 59)
        {
            rightParticle.SetActive(true);
            leftParticle.SetActive(true);
            GameObject obj = Instantiate(ballStream1);
            obj.transform.position = new Vector3(0.0f, 21.5f, 0.0f);
        }
        else if (phase1TimeSinceMove == 124)
        {
            rightParticle.SetActive(false);
            leftParticle.SetActive(false);
        }
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
            shadesAnimator.SetTrigger("ShadesYeet");
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
            endScreen.fadeIn();
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
        HPSlider.fillAmount = (float)currHealth / (float) maxHealth;
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
