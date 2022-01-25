using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    #region // Public Variables

    public static bool isMovementCalculated = false;
    public static int tilesReported = 0;

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

    private bool isVisualActive;

    #endregion

    // --------------------------------------------------------

    #region // Public Methods



    #endregion

    // --------------------------------------------------------

    #region // Private Methods

    private void Start()
    {
        IsVisualActive = false;
        IsMoveValid = false;
        tilePosition = this.transform.position;
        gameManager = GameManager.gameManagerInstance;
    }

    private void Update()
    {
        if (gameManager.IsGameStarted && !gameManager.IsGameOver && !isMovementCalculated)
        {
            CalculateMovementValidation();
        }
    }

    private void CalculateMovementValidation()
    {
        if (gameManager.WarriorPieceSelected != null)
        {
            warriorData = gameManager.WarriorPieceSelected.WarriorData;
            TestIfMoveIsValid();
            tilesReported++;
            if (tilesReported >= 64)
            {
                isMovementCalculated = true;
                tilesReported = 0;
            }
            
            moveVisual.SetActive(IsVisualActive);
        }
        else
        {
            moveVisual.SetActive(false);
        }
    }


    private void TestIfMoveIsValid()
    {
        
        IsVisualActive = false;

        print("Calculando");

        if (warriorData == null) { return; }

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
                            IsVisualActive = true;
                        }
                    }
                    break;
                }
        }

        warriorData = null;      
    }

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties

    public Vector3 TilePosition { get => tilePosition; set => tilePosition = value; }
    public bool IsPieceInTile { get => isPieceInTile; set => isPieceInTile = value; }
    public Warrior PieceInTile { get => pieceInTile; set => pieceInTile = value; }
    public bool IsMoveValid { get => isMoveValid; set => isMoveValid = value; }
    public bool IsVisualActive { get => isVisualActive; set => isVisualActive = value; }

    #endregion
}
