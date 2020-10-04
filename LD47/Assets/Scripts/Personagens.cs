using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Personagens : Interacting
{
    public TMPro.TextMeshProUGUI falaCapetinha;
    public TMPro.TextMeshProUGUI resposta1;
    public TMPro.TextMeshProUGUI resposta2;
    public TMPro.TextMeshProUGUI resposta3;
    public TMPro.TextMeshProUGUI resposta4;

    public GameObject canvas;

    public GameObject tarrinDate, azzaDate, akathizDate, zarosDate;

    public GameObject bar;

    string[] dialogosSeparados;

    string[] resp1;
    string[] resp2;
    string[] resp3;
    string[] resp4;

    int fala;

    LeitorDeTxt leitorDeTxt;

    // Start is called before the first frame update
    void Start()
    {
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
                break;
            
            case 1: 
                akathizDate.SetActive(true);
                break;

            case 2:
                zarosDate.SetActive(true);
                break;

            case 3:
                azzaDate.SetActive(true);
                break;

            default:
                break;
        }

        DateDialogos();

    }

    public void DateDialogos()
    {
        fala =  Random.Range(0, 2);

        canvas.SetActive(true);
        falaCapetinha.SetText(dialogosSeparados[fala*6]);

        resp1 = dialogosSeparados[(fala*6)+1].Split('*');
        resposta1.SetText(resp1[0].Trim());
        resp2 = dialogosSeparados[(fala*6)+2].Split('*');
        resposta2.SetText(resp2[0].Trim());
        resp3 = dialogosSeparados[(fala*6)+3].Split('*');
        resposta3.SetText(resp1[0].Trim());
        resp4 = dialogosSeparados[(fala*6)+4].Split('*');
        resposta4.SetText(resp2[0].Trim());
    }

    public void Resposta1()
    {
        resp1[1] = resp1[1].Trim();

        switch (resp1[1])
        {
            case "++":
                Debug.Log("foi ++");
                break;

            case "+":
                Debug.Log("foi +");
                break;

            case "-":
                Debug.Log("foi -");
                break;

            case "--":
                Debug.Log("foi --");
                break;

            default:
                break;
        }
    }
     public void Resposta2()
    {
        resp2[1] = resp2[1].Trim();

        switch (resp2[1])
        {
            case "++":
                Debug.Log("foi ++");
                break;

            case "+":
                Debug.Log("foi +");
                break;

            case "-":
                Debug.Log("foi -");
                break;

            case "--":
                Debug.Log("foi --");
                break;

            default:
                break;
        }
    }
    public void Resposta3()
    {
        resp3[1] = resp3[1].Trim();

        switch (resp3[1])
        {
            case "++":
                Debug.Log("foi ++");
                break;

            case "+":
                Debug.Log("foi +");
                break;

            case "-":
                Debug.Log("foi -");
                break;

            case "--":
                Debug.Log("foi --");
                break;

            default:
                break;
        }
    }
    public void Resposta4()
    {
        resp4[1] = resp4[1].Trim();

        switch (resp4[1])
        {
            case "++":
                Debug.Log("foi ++");
                break;

            case "+":
                Debug.Log("foi +");
                break;

            case "-":
                Debug.Log("foi -");
                break;

            case "--":
                Debug.Log("foi --");
                break;

            default:
                break;
        }
    }
}