using UnityEngine;

public class GameMusic : MonoBehaviour
{
    #region // Public Variables

    public static GameMusic gameMusicInstance;

    #endregion

    // --------------------------------------------------------

    #region // Private Variables

    [Header("Audio Clips To Play")]
    [SerializeField] AudioClip battleMusic;

    [Header("Sources")]
    [SerializeField] AudioSource battleAudioSorce;

    private AudioSource advebtureAudioSorce;

    #endregion

    // --------------------------------------------------------

    #region // Public Methods

    public void PlayBattleDrumsMusic()
    {
        if (BattleAudioSorce.clip.Equals(null) && !BattleMusic.Equals(null))
        {
            BattleAudioSorce.clip = BattleMusic;
        }
    }

    #endregion

    // --------------------------------------------------------

    #region // Private Methods

    private void Awake()
    {
        gameMusicInstance = this; // @TODO Set acorrect Singlento Pattern for this instance
        advebtureAudioSorce = this.GetComponent<AudioSource>();
    }


    #endregion

    // --------------------------------------------------------

    #region // Variables Properties

    public AudioClip BattleMusic { get => battleMusic; set => battleMusic = value; }
    public AudioSource BattleAudioSorce { get => battleAudioSorce; set => battleAudioSorce = value; }

    #endregion

}
