using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeitorDeTxt : MonoBehaviour
{
    string[] dialogos;

    string path;
    void Start()
    {
        SetIdioma("ptbr");
        LerTxt();
    }
    

    public void SetIdioma(string linguagem)
    {
        switch (linguagem)
        {
            case "ptbr":
                path = "Assets/Resources/Dialogos.txt";
                break;
            default:
                break;
        }
    }

    public void LerTxt ()
    {
        
        var textFile = Resources.Load<TextAsset>("Dialogos");
        dialogos = textFile.text.Split('#');
        
    }

    public string RetornaDialogo(int personagem)
    {
        return dialogos[personagem];
    }
}