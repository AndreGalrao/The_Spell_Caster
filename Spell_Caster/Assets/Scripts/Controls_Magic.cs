using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Magic : MonoBehaviour {

    //pega informações da classe que possui os estados da magia
    public Controls_Character infos;
    public Magic_Properties _magicp;


    //Estado que o personagem está no momento
    public enum MouseState
    {
        Basic_LeftClick,
        Combine_RightClick
    };

    [Range(0, 5)]
    public float Spell_Position;

    //Começa pelo LeftClick
    MouseState _actualstate = MouseState.Basic_LeftClick;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //Alteração de estados
        if (Input.GetMouseButtonDown(0))
            _actualstate = MouseState.Basic_LeftClick;
        if (Input.GetMouseButtonDown(1))
            _actualstate = MouseState.Combine_RightClick;


        //Pega em qual estado está a magia
		switch(infos.MagiaAtual)
        {
            //Pega as informações do construtor que está pegando dos atributos de magia
            //Associa o objeto que está na lista e a velocidade e passa como parametro para o método par lançar.
            //Se está no estado da magia, a particula da magia é associada a um objeto
            //Chama o método para lançar
            //Se clicar com o botão esquerdo, lança a magia
            case Controls_Character.Magias.Water:
                {
                    
                    GameObject _clone = infos.MagicLibrary["Water"].magic.MagicParticle;
                    float speed = infos.MagicLibrary["Water"].magic.MagicSpeed;
                    LaunchBasicMagic(_clone,speed);
                    break;
                }

            case Controls_Character.Magias.Fire:
                {
                    GameObject _clone = infos.MagicLibrary["Fire"].magic.MagicParticle;
                    float speed = infos.MagicLibrary["Fire"].magic.MagicSpeed;
                    LaunchBasicMagic(_clone, speed);
                    break;
                }
            case Controls_Character.Magias.Air:
                {
                    GameObject _clone = infos.MagicLibrary["Air"].magic.MagicParticle;
                    float speed = infos.MagicLibrary["Air"].magic.MagicSpeed;
                    LaunchBasicMagic(_clone, speed);
                    break;
                }
            case Controls_Character.Magias.Thunder:
                {
                    GameObject _clone = infos.MagicLibrary["Thunder"].magic.MagicParticle;
                    float speed = infos.MagicLibrary["Thunder"].magic.MagicSpeed;
                    LaunchBasicMagic(_clone, speed);
                    break;
                }
            case Controls_Character.Magias.Earth:
                {
                    GameObject _clone = infos.MagicLibrary["Earth"].magic.MagicParticle;
                    float speed = infos.MagicLibrary["Earth"].magic.MagicSpeed;
                    LaunchBasicMagic(_clone, speed);
                    break;
                }


        }
	}

    void LaunchBasicMagic(GameObject Magic, float Speed)
    {
        //Método de lançamento, se apertar o botão esquerdo, depois que foi chamado, pega os parametros que foi puxado.
        if(Input.GetMouseButtonDown(0))
        {
            //Se apertar o botão, instancia a mágica.
            //Colocar pra magia ser atirada na frente.

           
            //Para que a magia não saia de dentro do cubo.
            Vector3 _spellpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                gameObject.transform.position.z + Spell_Position);

           //Armazenar o clone em um objeto e instanciar ele
            GameObject MagicCreation = Instantiate(Magic, _spellpos, Quaternion.identity);
            MagicCreation.AddComponent<Rigidbody>(); //Adicionar Rigidbody nesse clone
            Rigidbody MagicRigidbody = MagicCreation.GetComponent<Rigidbody>(); //Adicionar rigidbody no clone
            MagicRigidbody.useGravity = false; //O clone não usar gravidade
            MagicRigidbody.freezeRotation = true; //O clone não poder girar
            MagicRigidbody.AddForce(transform.forward * Speed * 500 * Time.fixedDeltaTime, ForceMode.Impulse);
            //Lançar o clone, o 500 é o multiplicador para que não seja necessario alterar a speed para valores altos.
           





        }
    }
}
