using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {

    Enemy_Spawn infoenemy;
    Enemy_Waves infowaves;
    Player_LifeSettings infolifes;
    Game_PointComboControl infopoints;
    Rigidbody EnemyPhysics;

    GameObject Player;

    //[SerializeField]
    float _enemyHP;
    float _destroyAfterPass;

    float multiplicadordeefetividade = 1;

	// Use this for initialization
	void Start () {
        
        //Procura o objeto do Spawn do inimigo e pega os scripts.
        infoenemy = GameObject.Find("EnemySpawnPoint").GetComponent<Enemy_Spawn>();
        infowaves = GameObject.Find("WaveController").GetComponent<Enemy_Waves>();
        infolifes = GameObject.Find("Player").GetComponent<Player_LifeSettings>();
        infopoints = GameObject.Find("MasterControl").GetComponent<Game_PointComboControl>();
        //Procura o jogador para comparar mais pra frente a posição
        Player = GameObject.Find("Player");
        _enemyHP = infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyHP; //Coloca no dicionario o nome do inimigo e puxa o HP
        _destroyAfterPass = infoenemy.EnemyLibrary[gameObject.name].enemy.DestroyDistance;
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

        //Compara o Z do inimigo com o Z do personagem, se o Z do inimigo for menor, significa que 
        //O inimigo passou o player, e aí já destrói.
        if (gameObject.transform.position.z < Player.transform.position.z - _destroyAfterPass)
        {
            infowaves.DestroyandCheck(gameObject);
            infolifes.TakeLive();
            infopoints.LostLife();
        }

        if (_enemyHP <= 0)
        {
            infowaves.DestroyandCheck(gameObject);
            
            //Criar um método próprio para destruir e lista
        }
	}

    private void OnCollisionEnter(Collision collision)
    {

        //Como não é possivel atribuir uma palavra a um objeto, foi utilizado tag.
        //Tag tem que estar com o mesmo nome que o "MagicType"

        //Detectar colisões somente quando tiver uma tag com "Magic"
        if (collision.gameObject.tag == "Magic")
        {
           
            //Atribui a uma nova variavel o valor da variavel do que foi colidido
            //Pega a efetividade da magia que foi lançada. Caso essa efetividade seja igual ao tipo do personagem..
            string Effectiveness = collision.gameObject.GetComponent<Magic_Information>().LaunchedMagicTypeEff;
            if (Effectiveness == infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.MagicType)
            {
                //Se possuir o mesmo nome do inimigo, toma o dobro de dano
                multiplicadordeefetividade = 2;
                print("It's Super Effective!");
                infopoints.SuperEffective(); //Já que acertou o inimigo super efetivamente chama o método para dobrar pontos
                Formuladedano(collision, multiplicadordeefetividade);
            }

            //Se por acaso a magia tiver imunidade ao mesmo tipo do inimigo, não causa dano.
            //Ex: Fire, tem Water, se Water for igual ao tipo do inimigo (Water), Fire não dará dano.
            string Immunity = collision.gameObject.GetComponent<Magic_Information>().LaunchedMagicTypeImm;
            if (Immunity == infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.MagicType)
            {
                multiplicadordeefetividade = 0;
                infopoints.NotEffective(); //Para zerar o contador
                print("It's not very effective...");
                Formuladedano(collision, multiplicadordeefetividade);
                
                
            }

            //Caso a efetividade não exista, e não é imunidade, ele considera que é qualquer magia que acertou.
            if (Effectiveness != infoenemy.EnemyLibrary[gameObject.name].enemy.EnemyType.MagicType)
            {
                infopoints.NeutralEffective(); //5 pontos e zerar contador.
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
        //print(_enemyHP);
    }
}
