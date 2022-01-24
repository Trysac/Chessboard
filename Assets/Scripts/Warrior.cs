using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warrior : MonoBehaviour
{
    #region // Private Variables

    [Header("Piece Configuration")]
    [SerializeField] WarriorData warriorData;
    [SerializeField] MeshFilter characterMeshFilter;
    [SerializeField] TextMeshProUGUI warriorNameText;

    private BoxCollider myBoxCollider;
    
    #endregion

    // --------------------------------------------------------

    #region // Public Methods
    #endregion

    // --------------------------------------------------------

    #region // Private Methods

    private void Start()
    {
        myBoxCollider = this.GetComponent<BoxCollider>();
        characterMeshFilter.mesh = WarriorData.Character3DModel;
        warriorNameText.text = WarriorData.CharacterName;
    }

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties

    public WarriorData WarriorData { get => warriorData; set => warriorData = value; }

    #endregion
}
