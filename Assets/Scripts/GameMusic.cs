using UnityEngine;

public class GameMusic : MonoBehaviour
{
    #region // Public Variables

    public static GameMusic gameMusicInstance;

    #endregion

    // --------------------------------------------------------

    #region // Private Variables

    [SerializeField] AudioClip battleMusic;
    [SerializeField] AudioClip advebtureMusic;

    #endregion

    // --------------------------------------------------------

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

    public AudioClip BattleMusic { get => battleMusic; set => battleMusic = value; }
    public AudioClip AdvebtureMusic { get => advebtureMusic; set => advebtureMusic = value; }

    #endregion

}
