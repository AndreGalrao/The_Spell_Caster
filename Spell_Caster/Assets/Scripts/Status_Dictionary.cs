using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Dictionary : MonoBehaviour {

    //---- Criação do dicionário de status
    [Header("Biblioteca de Status")]
    public StatusDictionary StatusLibrary;
    public IDictionary<string, StatusMethods> StatusDictionaryControl
    {
        get { return StatusLibrary; }
        set { StatusLibrary.CopyFrom(value); }
    }
    //---- Todos os scriptable objects dos status serão passados para aí.
   
}
