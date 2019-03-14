using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_PointComboControl : Game_MasterSettings {


    
    #region SuperEffective
    public void SuperEffective()
    //Caso o personagem tenha atingido super efetivamente
    {
        ComboCounter += 1; //Aumenta o combo counter em um
        GameScore += 10 * ComboCounter; //Ganha 10 pontos + adiciona na contagem do combo
       
        
    }
    #endregion

    #region NeutralEffective
    public void NeutralEffective()
    {

        ComboCounter = 0; //Zera o contador de combos
        GameScore += 5; //Dá 5 pontos
        
    }
    #endregion

    #region NotVeryEffective
    public void NotEffective()
    {
        ComboCounter = 0; //Zera o contador de pontos
        GameScore += 0; //Não ganha pontos
    }
    #endregion

    #region LostLife
    public void LostLife()
    {
        ComboCounter = 0; //Zera o contador de combos
        GameScore -= 5; //Perde 5 pontos
    }
    #endregion



}
