using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeitorDeTxt
{
    string[] dialogos;

    string path;

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
        StreamReader leitor = new StreamReader(path);
        dialogos = leitor.ReadToEnd().Split('#');
    }

    public string RetornaDialogo(int personagem)
    {
        return dialogos[personagem];
    }
}