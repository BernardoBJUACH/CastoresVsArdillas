using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuez : MonoBehaviour
{
    public float maxTime;
    public float currentTime;

    public TimeBar timeBar;
    private bool rotate = true;

    public SpriteRenderer spriteRenderer;
    public Sprite nuezRoten1;
    public Sprite nuezRoten2;
    public Sprite nuezRoten3;

    void Start()
    {
        currentTime = maxTime;
        timeBar.gameObject.SetActive(false);
        // timeBar.SetMaxTime(0);
        // timeBar.gameObject.SetActive(false);
    }

    void Update()
    {
        if (rotate)
        {
            // timeBar.gameObject.SetActive(false);
            // transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
        else
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                timeBar.SetTime(currentTime);
                if (currentTime / maxTime <= 0.70f && currentTime / maxTime > 0.40f && spriteRenderer.sprite != nuezRoten1)
                {
                    Debug.Log("nuezRoten1");
                    spriteRenderer.sprite = nuezRoten1;
                }
                else if (currentTime / maxTime <= 0.40f && spriteRenderer.sprite != nuezRoten2)
                {
                    Debug.Log("nuezRoten2");
                    spriteRenderer.sprite = nuezRoten2;
                }
            }
            else
            {
                if (spriteRenderer.sprite != nuezRoten3)
                {
                    spriteRenderer.sprite = nuezRoten3;
                    timeBar.gameObject.SetActive(false);

                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /*
        LeanTween.scale(gameObject, Vector3.one * 5, .5f).setEaseInBack();
        this.rotate = false;
        */
        // timeBar.gameObject.SetActive(true);
        timeBar.gameObject.SetActive(true);
        timeBar.SetMaxTime(maxTime);
        currentTime = maxTime;
        // ((TimeBar) timeBar).SetMaxTime(maxTime);
        // timeBar.SetMaxTime(maxTime);
        rotate = false;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Debug.Log("OnCollisionExit2D");
    }

    void OnCollisionStay2D(Collision2D other)
    {
        // Debug.Log("OnCollisionStay2D");
    }
}


