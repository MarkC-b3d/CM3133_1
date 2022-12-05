using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour

{

    public static LevelManager instance;

    public float waitToRespawn;

    public int gemsCollected;

    public string levelToLoad;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false); //disables player
        yield return new WaitForSeconds(waitToRespawn); //waits a few seconds
        PlayerController.instance.gameObject.SetActive(true); //enables player again
        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth; //resets health
        UIController.instance.UpdateHealthDisplay(); //updates health UI


    }

    public void endLevel()
    {
        StartCoroutine(endLevelCo());
    }

    public IEnumerator endLevelCo()
    {
        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelToLoad);
    }
}
