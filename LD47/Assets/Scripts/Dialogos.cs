using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
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
    public int nfalas;




    [Header("Botoes")]
    public GameObject botoesRespostas;
    public GameObject okReacao;




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
        string dialogoPersonagem;

        dialogoPersonagem = leitorDeTxt.RetornaDialogo(0);

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
                break;
            
            case 1: 
                akathizDate.SetActive(true);
                dateSprites = akathizDate;
                baseDate = baseAkathiz;
                dateN = akathizN;
                dateF = akathizF;
                dateP = akathizP;
                break;

            case 2:
                zarosDate.SetActive(true);
                dateSprites = zarosDate;
                baseDate = baseZaros;
                dateN = zarosN;
                dateF = zarosF;
                dateP = zarosP;
                break;

            case 3:
                azzaDate.SetActive(true);
                dateSprites = azzaDate;
                baseDate = baseAzza;
                dateN = azzaN;
                dateF = azzaF;
                dateP = azzaP;
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
    //stat.DateTimes[date]++;
}