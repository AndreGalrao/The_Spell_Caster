using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game_MasterSettings : MonoBehaviour {


    //Chama o GameOver
    public void GameOver()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentscene.name);

    }
}
