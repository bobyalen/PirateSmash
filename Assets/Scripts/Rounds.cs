using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rounds : MonoBehaviour
{
    public int lives = 2;
    public GameObject player;
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
        player.GetComponent<Health>().resetHealth();
    }

    public IEnumerator Roundreset()
    {
        yield return(2);
        ResetRound();
    }


}
