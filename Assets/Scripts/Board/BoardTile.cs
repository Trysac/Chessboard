using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    #region // Public Variables

    

    #endregion

    // --------------------------------------------------------

    #region // Private Variables

    [SerializeField] GameObject moveVisual;
    [SerializeField] GameObject attackVisual;

    private bool isMoveValid;
    private Vector3 tilePosition;
    private GameManager gameManager;
    private WarriorData warriorData;

    private bool isCalculated = false;

    #endregion

    // --------------------------------------------------------

    #region // Public Methods
    #endregion

    // --------------------------------------------------------

    #region // Private Methods

    private void Start()
    {
        isMoveValid = false;
        tilePosition = this.transform.position;
        gameManager = GameManager.gameManagerInstance;
    }

    private void Update()
    {
        if (gameManager.IsGameStarted && !gameManager.IsGameOver)
        {
            if (gameManager.WarriorPieceSelected != null)
            {
                if (!isCalculated)
                {
                    warriorData = gameManager.WarriorPieceSelected.WarriorData;
                    moveVisual.SetActive(TestIfMoveIsValid());
                    isCalculated = true;
                }
            }
            else
            {
                isCalculated = false;
                moveVisual.SetActive(isCalculated);
            }
        }
    }

    private bool TestIfMoveIsValid()
    {
        print(warriorData.CharacterType);
        switch (warriorData.CharacterType)
        {
            case PieceType.Pawn:
                {
                    Vector3 warriorPosition = gameManager.WarriorPieceSelected.transform.position;
                    if (Vector3.Distance(tilePosition, warriorPosition) == 1) { return true; }
                    else { return false; }             
                }
            default:
                {
                    return false;
                }
        }
    }

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties

    public Vector3 TilePosition { get => tilePosition; set => tilePosition = value; }

    #endregion
}
