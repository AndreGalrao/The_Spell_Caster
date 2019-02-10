using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "New Enemy")]
public class Enemy_Attributes : ScriptableObject {

    //Atributos do inimigo
    public Magic_Attributes EnemyType;
    public string EnemyHP;
    public GameObject EnemyModel;
    public float EnemySpeed;
    
}
