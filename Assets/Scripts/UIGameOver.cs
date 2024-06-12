using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    ASM_MN asm;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        asm = FindObjectOfType<ASM_MN>();
    }

    void Start()
    {
        scoreText.text = "You Scored:\n" + ScoreKeeper.Instance.GetScore();

        ASM_MN.Instance.YC1();
        ASM_MN.Instance.YC2();
        ASM_MN.Instance.YC3();
        ASM_MN.Instance.YC4();
        ASM_MN.Instance.YC5();
        ASM_MN.Instance.YC6();





        /* 
        asm.YC3();
        asm.YC4();
        asm.YC5();
        asm.YC6();
        asm.YC7();
        */
    }




}
