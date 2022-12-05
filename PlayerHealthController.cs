using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour


{

    public float invincibleLength;

    private float invincibleCounter;

    private SpriteRenderer theSR;


    public static PlayerHealthController instance;

    public static int number;

    private void Awake()
    {
        instance = this;
    }

    public int currentHealth, maxHealth;





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            
            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {

        if(invincibleCounter <= 0)
        {
            //removes a value of one from current health
            currentHealth--;

            if (currentHealth <= 0)
            {
                //sanity check to make sure that the lowest value the health can be will always be 0
                currentHealth = 0;

                //gameObject.SetActive(false);
                AudioManager.instance.PlaySFX(8); //plays sound effect on respawn
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);

                PlayerController.instance.knockBack();

            }

            UIController.instance.UpdateHealthDisplay();
        }

    }

    public void HealPlayer()
    {
        //currentHealth = maxHealth;
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
