using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    private int temp_scoreValue = 0;
    private int scoreNeed = 5;
    public Animator animator;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();

        if (MainMenu.level_value == 1)
        {
            scoreNeed = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue + " / " + scoreNeed;

        if (scoreValue != temp_scoreValue)
        {
            animator.SetTrigger("Change");
        }

        temp_scoreValue = scoreValue;
    }
}
