﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ConfigsSpace;

/*
Chance = ValorBase + ValorResposta1 + ValorResposta2 + ValorRsposta3 + ValorPresente + ValorStatus

Resposta ++ = ValorBase/6
Resposta + = ValorBase/12
Resposta - = -ValorBase/12
Resposta -- = -ValorBase/6

Presente + = ValorBase/2
Presente +- = 0
Presente - = -ValorBase/2

Status = StatusPreferencial/5
*/

public class Dialogos : Interacting
{
    public Stats stat;
    public GameObject canvas;
    public GameObject bar;
    public GameObject UICanvas;
    public int nfalas;




    [Header("Botoes")]
    public GameObject botoesRespostas;
    public GameObject okReacao;
    public GameObject botoesPresentes;
    public GameObject botaoFimDoDate;




    [Header("Texto dos botoes de presente")]
    public TMPro.TextMeshProUGUI presenteFlorMurcha;
    public TMPro.TextMeshProUGUI presenteLingerie;
    public TMPro.TextMeshProUGUI presenteIsqueiro;
    public TMPro.TextMeshProUGUI presenteUrsinho;
    public TMPro.TextMeshProUGUI presenteDrink;




    [Header("Variaveis de acerto e erro de resposta")]
    [Tooltip("Para ++ e -- vou multiplicar por 2 esses valores")]
    public int acertouResposta;
    public int errouResposta;
    public int baseTarrin, baseAkathiz, baseZaros, baseAzza;




    [Header("Textos das falas")]
    public TMPro.TextMeshProUGUI falaCapetinha;
    public TMPro.TextMeshProUGUI resposta1;
    public TMPro.TextMeshProUGUI resposta2;
    public TMPro.TextMeshProUGUI resposta3;
    public TMPro.TextMeshProUGUI resposta4;




    [Header("Personagem perto")]
    public GameObject tarrinDate, azzaDate, akathizDate, zarosDate;

    [Header("Sprites Personagens")]
    public Sprite tarrinN;
    public Sprite tarrinF, tarrinP;
    public Sprite azzaN, azzaF, azzaP;
    public Sprite akathizN, akathizF, akathizP;
    public Sprite zarosN, zarosF, zarosP;
    




    int[] presentes;


    GameObject dateSprites;
    Sprite dateF, dateN, dateP;


    string[] dialogosSeparados;


    string[] resp1;
    string[] resp2;
    string[] resp3;
    string[] resp4;


    int fala;
    int[] vetFalas;
    int date;
    int qtdfalas = 0;


    float baseDate, chance;

    int presentePreferido, presenteOdiado;
    int presente;

    int atributoPreferido;
    int multiplierAtributo;
    int deuDate;
    string falaPosDate;


    LeitorDeTxt leitorDeTxt;

    // Start is called before the first frame update
    void Start()
    {
        vetFalas = new int[3] {-1, -1, -1};
        presentes = new int[4] {1, 2, 3, 4};

        leitorDeTxt = Camera.main.GetComponent<LeitorDeTxt>();
    }

    public void DefineDialogo(int personagem)
    {
        UICanvas.SetActive(false);

        string dialogoPersonagem;

        dialogoPersonagem = leitorDeTxt.RetornaDialogo(personagem);

        dialogosSeparados = dialogoPersonagem.Split('\n');

        Debug.Log("clicou" + personagem);

        bar.SetActive(false);

        switch (personagem)
        {  
            case 0:
                tarrinDate.SetActive(true);
                dateSprites = tarrinDate;
                baseDate = baseTarrin;
                dateN = tarrinN;
                dateF = tarrinF;
                dateP = tarrinP;
                presentePreferido = 0;
                presenteOdiado = 2;
                atributoPreferido = 2;
                multiplierAtributo = 1;
                break;
            
            case 1: 
                akathizDate.SetActive(true);
                dateSprites = akathizDate;
                baseDate = baseAkathiz;
                dateN = akathizN;
                dateF = akathizF;
                dateP = akathizP;
                presentePreferido = 1;
                presenteOdiado = 0;
                atributoPreferido = 3;
                multiplierAtributo = 1;
                break;

            case 2:
                zarosDate.SetActive(true);
                dateSprites = zarosDate;
                baseDate = baseZaros;
                dateN = zarosN;
                dateF = zarosF;
                dateP = zarosP;
                presentePreferido = 2;
                presenteOdiado = 3;
                atributoPreferido = 0;
                multiplierAtributo = 1;
                break;

            case 3:
                azzaDate.SetActive(true);
                dateSprites = azzaDate;
                baseDate = baseAzza;
                dateN = azzaN;
                dateF = azzaF;
                dateP = azzaP;
                presentePreferido = 3;
                presenteOdiado = 1;
                atributoPreferido = 1;
                multiplierAtributo = -1;
                break;

            default:
                break;
        }
        chance = baseDate;

        date = personagem;

        DateDialogos();

    }

    public void DateDialogos()
    {
        dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 
        botoesRespostas.SetActive(true);
        okReacao.SetActive(false);

        for(int i = 0; i < 5; i++)
        {
            fala =  Random.Range(0, nfalas);

            if (fala != vetFalas[0] && fala != vetFalas[1] && fala != vetFalas[2])
            {
                vetFalas[qtdfalas] = fala;
                i = 5;
            }else
            {
                i = 0;
            }
             
        }
        

        canvas.SetActive(true);
        falaCapetinha.SetText(dialogosSeparados[fala*6]);
        resp1 = dialogosSeparados[(fala*6)+1].Split('*');
        resposta1.SetText(resp1[0].Trim());
        resp2 = dialogosSeparados[(fala*6)+2].Split('*');
        resposta2.SetText(resp2[0].Trim());
        resp3 = dialogosSeparados[(fala*6)+3].Split('*');
        resposta3.SetText(resp3[0].Trim());
        resp4 = dialogosSeparados[(fala*6)+4].Split('*');
        resposta4.SetText(resp4[0].Trim());

        
        
        qtdfalas++;
    }

    public void Resposta1()
    {
        resp1[1] = resp1[1].Trim();

        switch (resp1[1])
        {
            case "++":
                chance = chance + (baseDate/(acertouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateF; 

                Debug.Log("foi ++");   
                break;

            case "+":
                chance = chance + (baseDate/acertouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi +");
                break;

            case "-":
                chance = chance + (baseDate/errouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi -");
                break;

            case "--":
                chance = chance + (baseDate/(errouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateP; 

                Debug.Log("foi --");
                break;

            default:
                break;
        }
        botoesRespostas.SetActive(false);
        okReacao.SetActive(true);
        
        falaCapetinha.SetText(resp1[2]);

    }
    public void Resposta2()
    {
        resp2[1] = resp2[1].Trim();

        switch (resp2[1])
        {
           case "++":
                chance = chance + (baseDate/(acertouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateF; 

                Debug.Log("foi ++");   
                break;

            case "+":
                chance = chance + (baseDate/acertouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi +");
                break;

            case "-":
                chance = chance + (baseDate/errouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi -");
                break;

            case "--":
                chance = chance + (baseDate/(errouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateP; 

                Debug.Log("foi --");
                break;

            default:
                break;
        }
        botoesRespostas.SetActive(false);
        okReacao.SetActive(true);

        falaCapetinha.SetText(resp2[2]);
    }
    public void Resposta3()
    {
        resp3[1] = resp3[1].Trim();

        switch (resp3[1])
        {
            case "++":
                chance = chance + (baseDate/(acertouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateF; 

                Debug.Log("foi ++");   
                break;

            case "+":
                chance = chance + (baseDate/acertouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi +");
                break;

            case "-":
                chance = chance + (baseDate/errouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi -");
                break;

            case "--":
                chance = chance + (baseDate/(errouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateP; 

                Debug.Log("foi --");
                break;

            default:
                break;
        }
        botoesRespostas.SetActive(false);
        okReacao.SetActive(true);

        falaCapetinha.SetText(resp3[2]);
    }
    public void Resposta4()
    {
        resp4[1] = resp4[1].Trim();

        switch (resp4[1])
        {
            case "++":
                chance = chance + (baseDate/(acertouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateF; 

                Debug.Log("foi ++");   
                break;

            case "+":
                chance = chance + (baseDate/acertouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi +");
                break;

            case "-":
                chance = chance + (baseDate/errouResposta);

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateN; 

                Debug.Log("foi -");
                break;

            case "--":
                chance = chance + (baseDate/(errouResposta/2));

                dateSprites.GetComponent<SpriteRenderer>().sprite = dateP; 

                Debug.Log("foi --");
                break;

            default:
                break;
        }
        botoesRespostas.SetActive(false);
        okReacao.SetActive(true);

        falaCapetinha.SetText(resp4[2]);
    }
    public void Next()
    {
        if (qtdfalas < 3)
        {
            DateDialogos();
            
        }
        else{
            Debug.Log("cabou " + chance);
            qtdfalas = 0;
            Presente();
            vetFalas[0] = -1;
            vetFalas[1] = -1;
            vetFalas[2] = -1;

        }
    }
    public void Presente()
    {

        okReacao.SetActive(false);
        botoesPresentes.SetActive(true);

        falaCapetinha.SetText("(Give him a Gift)");

        presenteFlorMurcha.SetText("X " + stat.florMurcha); 

        presenteLingerie.SetText("X " + stat.lingerie);

        presenteIsqueiro.SetText("X " + stat.isqueiro);

        presenteUrsinho.SetText("X " + stat.ursinho);

        presenteDrink.SetText("X " + stat.drink);
        //fav:
        //0 = flores murchas
        //1 = lingerie
        //2 = isqueiro
        //3 = ursinho
        //hate:
        //0 = isqueiro
        //1 = flores murchas
        //2 = ursinho
        //3 = lingerie
    }
    public void FlorMurcha()
    {
        presente = 0;

        

        if(stat.florMurcha > 0){

            if (presente == presenteOdiado)
            {
                chance = chance - (baseDate/2);
            }
            else if (presente == presentePreferido)
            {
                chance = chance + (baseDate/2);
            }

            stat.florMurcha--;

            CalculaStatus();
        }
    }
    public void Lingerie()
    {
        presente = 1;

        

        if(stat.lingerie > 0){

            if (presente == presenteOdiado)
            {
                chance = chance - (baseDate/2);
            }
            else if (presente == presentePreferido)
            {
                chance = chance + (baseDate/2);
            }
            
            stat.lingerie--;

            CalculaStatus();
        }
    }
    public void Isqueiro()
    {
        presente = 2;

        

        if(stat.isqueiro > 0){

            if (presente == presenteOdiado)
            {
                chance = chance - (baseDate/2);
            }
            else if (presente == presentePreferido)
            {
                chance = chance + (baseDate/2);
            }
            
            stat.isqueiro--;

            CalculaStatus();
        }
    }
    public void Ursinho()
    {
        presente = 3;

        

        if(stat.ursinho > 0){

            if (presente == presenteOdiado)
            {
                chance = chance - (baseDate/2);
            }
            else if (presente == presentePreferido)
            {
                chance = chance + (baseDate/2);
            }
            
            stat.ursinho--;

            CalculaStatus();
        }
    }
    public void presenteNeutro()
    {
        
        if(stat.drink > 0){
            
            stat.drink--;

            CalculaStatus();
        }

    }
    public void CalculaStatus()
    {
        //zaros: impulsive = 0
        //akathiz: exhibitionist = 3
        //tarrin: civilized = 2
        //azza: shy = 1
        chance = chance + ((stat.bars[atributoPreferido] * multiplierAtributo)/5);

        Debug.Log(chance);

        deuDate = Random.Range(0, 100);

        if (deuDate <= chance )
        {
            Debug.Log("datou");
            stat.DateTimes[date]++;

            switch(date)
            {
                case 0:
                    stat.scoreMinigameUpgrade = true;
                    falaPosDate = "(Your MiniGame bonus is " + stat.scoreMinigameValue.ToString() + " now)";
                    break;
                case 1:
                    stat.attributeUpgrade = true;
                    falaPosDate = "(Your Attribute bonus is " + stat.attributeValue.ToString() + " now)";
                    break;
                case 2:
                    stat.IdleUpgrade = true;
                    falaPosDate = "(Your Idle bonus is " + stat.IdleSoul.ToString() + " now)";
                    break;
                case 3:
                    stat.soulsPerClickUpgrade = true;
                    falaPosDate = "(Your Souls per Click bonus is " + stat.soulsPerClickValue.ToString() + " now)";
                    break;
                default:
                    break;

            }
        }
        else
        {
            falaPosDate = "(He's not happy enough to go out with you)";
        }
        botoesPresentes.SetActive(false);
        FimDoDate();
        

    }
    public void FimDoDate()
    {
        falaCapetinha.SetText(falaPosDate);
        botaoFimDoDate.SetActive(true);
    }
    public void SaiDoDate()
    {
        SceneManager.LoadScene("Bar");
    }
}