using UnityEngine;

public class Nuez : MonoBehaviour
{
    public float maxTime;
    public float currentTime;

    public TimeBar timeBar;
    private bool floor = false;

    public SpriteRenderer spriteRenderer;
    public Sprite nuezRotten1;
    public Sprite nuezRotten2;
    public Sprite nuezRotten3;

    void Start()
    {
        currentTime = maxTime;
        timeBar.gameObject.SetActive(false);
        // timeBar.SetMaxTime(0);
        // timeBar.gameObject.SetActive(false);
    }

    void Update()
    {
        if (floor)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                timeBar.SetTime(currentTime);
                if (currentTime / maxTime <= 0.70f && currentTime / maxTime > 0.40f && spriteRenderer.sprite != nuezRotten1)
                {
                    spriteRenderer.sprite = nuezRotten1;
                }
                else if (currentTime / maxTime <= 0.40f && spriteRenderer.sprite != nuezRotten2)
                {
                    spriteRenderer.sprite = nuezRotten2;
                }
            }
            else
            {
                timeBar.gameObject.SetActive(false);
                spriteRenderer.sprite = nuezRotten3;
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
        floor = true;
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

