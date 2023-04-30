using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rounds : MonoBehaviour
{
    public int lives = 2;
    public GameObject player;
    public GameObject player2;
    public Transform respawn;
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = lives.ToString();
    }

    public void liveLost()
    {
        lives--;
    }

    public void ResetRound()
    {
        player.transform.position=respawn.position;
        player2.transform.position= player2.GetComponent<Rounds>().respawn.position;
        player.GetComponent<Health>().resetHealth();
        player2.GetComponent<Health>().resetHealth();
    }

    public IEnumerator Roundreset()
    {
        yield return new WaitForSeconds(0.5f);
        ResetRound();
    }


}
