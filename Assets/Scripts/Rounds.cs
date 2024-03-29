using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rounds : MonoBehaviour
{
    public int lives = 2;
    public bool roundended;
    public GameObject player;
    public GameObject player2;
    public GameObject GameOverUI;
    public Transform respawn;
    public TextMeshProUGUI text;
    public TextMeshProUGUI winnerText;
    // Update is called once per frame

    private void Start()
    {
        GameOverUI.SetActive(false);
    }
    void Update()
    {
        text.text = lives.ToString();
    }

    public void liveLost()
    {
        if (!roundended)
        {
            lives--;
        }
    }

    public void ResetRound()
    {
        player.transform.position = respawn.position;
        player2.transform.position = player2.GetComponent<Rounds>().respawn.position;
        player.GetComponent<Health>().resetHealth();
        player2.GetComponent<Health>().resetHealth();
    }

    public IEnumerator Roundreset()
    {
        roundended = true;
        yield return new WaitForSeconds(0.5f);
        ResetRound();
        roundended = false;
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        winnerText.text = player2.name + " is swimming with the fishes";
    }
}
