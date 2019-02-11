using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {

    Enemy_Spawn infoenemy;
    Rigidbody EnemyPhysics;

    [SerializeField]
    float _enemyHP;

    


    float multiplicadordeefetividade = 1;

	// Use this for initialization
	void Start () {

        infoenemy = GameObject.Find("EnemySpawnPoint").GetComponent<Enemy_Spawn>();
        _enemyHP = infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyHP;
        gameObject.tag = "Enemy";

        EnemyPhysics = gameObject.GetComponent<Rigidbody>();
        EnemyPhysics.mass = infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyWeight;


        //print(infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.Immunity);

        //print(gameObject.name);
        //infoenemy.EnemyLibrary[gameObject.name];
	}
	
	// Update is called once per frame
	void Update () {


        //print(infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.MagicType);
        /* O nome do inimigo vai ser o nome de sua chave no dicionário.
         * Ele vai colocar esse nome no game object que irá ser instanciado
         * Nesse script ele vai consultar a biblioteca e vai usar como referencia, o nome do objeto que é o mesmo nome da chave
         * ele vai pegar as propriedades
         * toda chave do dicionário tá associada a um scriptable object */
        gameObject.transform.position -= transform.forward * infoenemy.EnemyLibrary[gameObject.name].enemy.EnemySpeed * Time.deltaTime;

        if (_enemyHP <= 0)
            Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision collision)
    {

        //Como não é possivel atribuir uma palavra a um objeto, foi utilizado tag.
        //Tag tem que estar com o mesmo nome que o "MagicType"

        //Detectar colisões somente quando tiver uma tag com "Magic"
        if (collision.gameObject.tag == "Magic")
        {
           
            //Atribui a uma nova variavel o valor da variavel do que foi colidido
            string Effectiveness = collision.gameObject.GetComponent<Magic_Information>().LaunchedMagicTypeEff;
            if (Effectiveness == infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.MagicType)
            {
                //Se possuir o mesmo nome do inimigo, toma o dobro de dano
                multiplicadordeefetividade = 2;
                print("It's Super Effective!");
                Formuladedano(collision, multiplicadordeefetividade);
            }

            //Se por acaso a magia tiver imunidade ao mesmo tipo do inimigo, não causa dano.
            //Ex: Fire, tem Water, se Water for igual ao tipo do inimigo (Water), Fire não dará dano.
            string Immunity = collision.gameObject.GetComponent<Magic_Information>().LaunchedMagicTypeImm;
            if (Immunity == infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.MagicType)
            {
                multiplicadordeefetividade = 0;
                print("It's not very effective...");
                Formuladedano(collision, multiplicadordeefetividade);
                
                
            }

            else
            {
                multiplicadordeefetividade = 0.1f;
                Formuladedano(collision, multiplicadordeefetividade);
            }

       
        }

        
        
    }

    void Formuladedano(Collision magic, float mult)
    {
        
        //Quando o objeto for colidido, ele vai pegar a informação do dano base que tem aquele objeto
        float BaseDmg = magic.gameObject.GetComponent<Magic_Information>().LaunchedBaseDamage;

        Magic_Information call = magic.gameObject.GetComponent<Magic_Information>(); //pegar info do outro script
        call.DestroyMagicApplyEffect(); //chamar o outro método

        //Dependendo de onde ele foi chamado, ele vai multiplicar.
        _enemyHP -= BaseDmg * mult;
        print(_enemyHP);
    }
}
