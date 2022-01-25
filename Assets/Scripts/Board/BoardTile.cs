using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    #region // Public Variables

    

    #endregion

    // --------------------------------------------------------

    #region // Private Variables

    [Header("General Parameters")]
    [SerializeField] GameObject moveVisual;
    [SerializeField] bool isMoveValid;

    [Header("Enemy Info")]
    [SerializeField] GameObject attackVisual;
    [SerializeField] bool isPieceInTile;
    [SerializeField] Warrior pieceInTile;

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
        IsMoveValid = false;
        tilePosition = this.transform.position;
        gameManager = GameManager.gameManagerInstance;
    }

    private void Update()
    {
        if (gameManager.IsGameStarted && !gameManager.IsGameOver)
        {
            if (gameManager.WarriorPieceSelected != null)
            {

                warriorData = gameManager.WarriorPieceSelected.WarriorData;
                moveVisual.SetActive(TestIfMoveIsValid());

                //if (!isCalculated)
                //{
                //    warriorData = gameManager.WarriorPieceSelected.WarriorData;
                //    moveVisual.SetActive(TestIfMoveIsValid());
                //    isCalculated = true;
                //}
            }
            //else
            //{
            //    isCalculated = false;
            //    moveVisual.SetActive(isCalculated);
            //}
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
                    if (Vector3.Distance(tilePosition, warriorPosition) == 1) 
                    {
                        if (this.tilePosition.z > warriorPosition.z) 
                        {
                            IsMoveValid = true;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
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
    public bool IsPieceInTile { get => isPieceInTile; set => isPieceInTile = value; }
    public Warrior PieceInTile { get => pieceInTile; set => pieceInTile = value; }
    public bool IsMoveValid { get => isMoveValid; set => isMoveValid = value; }

    #endregion
}
