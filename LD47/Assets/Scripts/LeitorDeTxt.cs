using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeitorDeTxt
{
    string[] dialogos;

    public void LerTxt ()
    {
        StreamReader leitor = new StreamReader( "Assets/Resources/Dialogos.txt");
        dialogos = leitor.ReadToEnd().Split('#');
    }

    public string RetornaDialogo(int personagem)
    {
        return dialogos[personagem];
    }
}