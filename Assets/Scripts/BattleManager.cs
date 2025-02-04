using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{

    public Enemy player;
    public Enemy currentEnemy;
    public TMP_Text healthText;

    public float timeSinceMove = 1000f;
    public float moveSpeed = 10f;

    public int roundIndex = 0;
    public int killIndex = 0; //Current enemy index
    public Round[] rounds;

    float elapsedSinceDeath = 0;

    BuffMenuManager buffMenuManager;
    public int buffIndex;

    public GameObject[] buffs;

    // Update is called once per frame
    private void Awake()
    {
        buffMenuManager = FindFirstObjectByType<BuffMenuManager>();
        if (buffMenuManager != null) buffIndex = buffMenuManager.selectedBuffIndex;
        StartCoroutine(spawnNewEnemy());
        buffs[buffIndex].gameObject.SetActive(true);
    }


    void Update()
    {

        timeSinceMove += Time.deltaTime;
        
        if (player.health <= 0)
        {
            elapsedSinceDeath += Time.deltaTime;
            Debug.Log("You Died!");
            if (elapsedSinceDeath > 2)
            {
                player.health = 100;
                killIndex = 0;
                roundIndex = 0;
                player.gameObject.SetActive(false);

                foreach (GameObject obj in FindObjectsOfType<GameObject>())
                {
                    if (obj.scene.buildIndex == -1) // -1 means it's in DontDestroyOnLoad
                    {
                        Destroy(obj);
                    }
                }

                SceneManager.LoadScene("You Died");
            }
        }

        if (currentEnemy != null && currentEnemy.health <= 0)
        {
            currentEnemy.GetComponentInChildren<Animator>().SetBool("Dead", true);
        }

        if (currentEnemy == null)
        {
            StartCoroutine(spawnNewEnemy());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentEnemy.Attack();
        }
    }

    public IEnumerator spawnNewEnemy()
    {

        if (currentEnemy != null) Destroy(currentEnemy.gameObject);
        if (killIndex >= rounds[0].enemies.Length)
        {
            Debug.Log("STAGE CLEARED!");

            //killIndex = 0;

            yield return new WaitForSeconds(1);

            //player.gameObject.SetActive(false);

            foreach (GameObject obj in FindObjectsOfType<GameObject>())
            {
                if (obj.scene.buildIndex == -1) // -1 means it's in DontDestroyOnLoad
                {
                    Destroy(obj);
                }
            }

            SceneManager.LoadScene("StageClear");
        }
        GameObject enemy = Instantiate(rounds[0].enemies[killIndex]);
        enemy.transform.position = new Vector3(3.38f, 0.2f, 0);
        killIndex++;
        currentEnemy = enemy.GetComponent<Enemy>();
    }
}
