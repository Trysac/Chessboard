using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region // Public Variables

    public static GameManager gameManagerInstance;

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
        if (gameManagerInstance.Equals(null)) { gameManagerInstance = this; }
        else { Destroy(this.gameObject); }
    }

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties
    #endregion

}
