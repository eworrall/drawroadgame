using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour {

    public Transform blockGenerator;
    private Vector3 blockStartPoint;

    public Movement thePlayer;
    private Vector3 playerStartPoint;
    private string menuScene = "menuScene";
    private scoreScript thescoremanager;

    public scoreScript theScore;

    public GameObject[] redblock;
    public GameObject[] activeCoins;

    public TrailRenderer trail;
    

    void Start()
    {
        blockStartPoint = blockGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        thescoremanager = FindObjectOfType<scoreScript>();
    }

    public void RestartGame()
    {
        thePlayer.gameObject.SetActive(false);
        trail.Clear();
        thePlayer.transform.position = playerStartPoint;
        blockGenerator.position = blockStartPoint;
        redblock = GameObject.FindGameObjectsWithTag("collideBox");
        foreach (GameObject block in redblock)
            Destroy(block);
        activeCoins = GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject c in activeCoins)
            Destroy(c);
        theScore.score = 0;
        thePlayer.gameObject.SetActive(true);
    }
    public void restartGametoMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    private void Update()
    {
        if (!thePlayer.isActiveAndEnabled)
        {
            Wait(1.5f);
        }
    }

    public void Wait(float seconds)
    {
        StartCoroutine(_wait(seconds));
    }
    IEnumerator _wait(float time)
    {
        yield return new WaitForSeconds(time);
        restartGametoMenu(); //or set death menu active that displays a score and best score, as well as restart, home, or store button
    }


}
