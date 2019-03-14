using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Game_MasterSettings : MonoBehaviour {

    public Text Score;
    

    //Lugar onde as coisas principais do jogo estão.
    [HideInInspector]
    public int GameScore = 0;
    [HideInInspector]
    public int ComboCounter = 0;
    //Chama o GameOver
    public void GameOver()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentscene.name);

    }


    //Provisório
    private void Update()
    {
        print("O Score atual é:" + GameScore);
        Score.text = "Score:" + " " + GameScore.ToString();
        
    }
}
