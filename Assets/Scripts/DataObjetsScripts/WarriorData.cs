using UnityEngine;

[CreateAssetMenu(fileName = "New_Warrior_Data", menuName = "Warrior Data")]
public class WarriorData : ScriptableObject
{
    #region // Private Variables

    [Header("Visual Design")]
    [SerializeField] Mesh character3DModel;
    // [SerializeField] Animation characterAttackEffect;
    [SerializeField] string characterName;
    [SerializeField] string characterDescription;

    [Header("Character configuration")]
    [SerializeField] PieceType characterType;

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties

    public Mesh Character3DModel { get => character3DModel; set => character3DModel = value; }
    public string CharacterName { get => characterName; set => characterName = value; }
    public string CharacterDescription { get => characterDescription; set => characterDescription = value; }
    public PieceType CharacterType { get => characterType; set => characterType = value; }

    #endregion

}
