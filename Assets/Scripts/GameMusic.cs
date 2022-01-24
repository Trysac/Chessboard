using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    #region // Public Variables

    public static GameMusic gameMusicInstance;

    #endregion

    // --------------------------------------------------------

    #region // Private Variables
    #endregion
    #region // Public Methods
    #endregion

    // --------------------------------------------------------

    #region // Private Methods

    private void Awake()
    {
        if (gameMusicInstance.Equals(null)) { gameMusicInstance = this; }
        else { Destroy(this.gameObject); }
    }

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties
    #endregion

}
