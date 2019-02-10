using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {

    Enemy_Spawn infoenemy;
	// Use this for initialization
	void Start () {

        infoenemy = GameObject.Find("EnemySpawnPoint").GetComponent<Enemy_Spawn>();

        //print(gameObject.name);
        //infoenemy.EnemyLibrary[gameObject.name];
	}
	
	// Update is called once per frame
	void Update () {

        print(infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.MagicType);
        /* O nome do inimigo vai ser o nome de sua chave no dicionário.
         * Ele vai colocar esse nome no game object que irá ser instanciado
         * Nesse script ele vai consultar a biblioteca e vai usar como referencia, o nome do objeto que é o mesmo nome da chave
         * ele vai pegar as propriedades
         * toda chave do dicionário tá associada a um scriptable object */
        gameObject.transform.position -= transform.forward * infoenemy.EnemyLibrary[gameObject.name].enemy.EnemySpeed * Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
    }
}
