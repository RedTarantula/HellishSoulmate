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
        path = "Assets/Resources/Dialogos.txt";
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