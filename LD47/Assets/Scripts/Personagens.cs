using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Personagens : MonoBehaviour
{

    public int personagem;

    string[] dialogosSeparados;

    LeitorDeTxt leitorDeTxt;

    // Start is called before the first frame update
    void Start()
    {
        leitorDeTxt.SetIdioma("ptbr");
        leitorDeTxt.LerTxt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefineDialogo()
    {
        string dialogoPersonagem;

        dialogoPersonagem = leitorDeTxt.RetornaDialogo(personagem);

        dialogosSeparados = dialogoPersonagem.Split('\n');
    }
}
