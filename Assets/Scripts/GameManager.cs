using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region // Public Variables

    public static GameManager gameManagerInstance;

    #endregion

    // --------------------------------------------------------

    #region // Private Variables

    [SerializeField] LayerMask tileLayerMask;
    [SerializeField] LayerMask warriorsLayerMask;
    [SerializeField] Warrior warriorPieceSelected;

    //Control Variables
    private bool isGameStarted;
    private bool isGameOver;
    private Transform cursorSelectedTile;
    private Ray ray;
    private RaycastHit hit;

    #endregion

    // --------------------------------------------------------

    #region // Public Methods
    #endregion

    // --------------------------------------------------------

    #region // Private Methods

    private void Awake()
    {
        gameManagerInstance = this; // @TODO Set acorrect Singlento Pattern for this instance
    }

    private void Start()
    {
        IsGameStarted = true;
        IsGameOver = false;
    }

    private void Update()
    {
        if (IsGameStarted && !IsGameOver)
        {
            ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            // shoot a raycast from our mouse cursor
            if (Physics.Raycast(ray, out hit, 99, warriorsLayerMask) && WarriorPieceSelected == null)
            {
                if (Mouse.current.leftButton.isPressed)
                {
                    BoardTile.isMovementCalculated = false;
                    WarriorPieceSelected = hit.collider.GetComponent<Warrior>();
                }
            }
            else if (Physics.Raycast(ray, out hit, 99, tileLayerMask))
            {
                cursorSelectedTile = hit.collider.GetComponent<Transform>();
            }
            else
            {
                cursorSelectedTile = null;
            }

            if (Mouse.current.leftButton.isPressed && cursorSelectedTile != null)
            {
                MoveWarrior();
            }

            if (Mouse.current.rightButton.isPressed)
            {
                CancelWarriorMovement();
            }
        }
    }

    private void MoveWarrior()
    {

        //if (Physics.Raycast(ray, out hit, 99, warriorsLayerMask)) 
        //{
        //    warriorPieceSelected = hit.collider.GetComponent<Warrior>();
        //}

        if (warriorPieceSelected != null && cursorSelectedTile.GetComponent<BoardTile>().IsMoveValid)
        {
            if (Vector3.Distance(WarriorPieceSelected.transform.position, cursorSelectedTile.transform.position) != Mathf.Epsilon)
            {
                WarriorPieceSelected.MoveWarrior(cursorSelectedTile.transform.position);
                CancelWarriorMovement();
            }
        }
    }

    private void CancelWarriorMovement()
    {
        if (WarriorPieceSelected != null)
        {
            print("Cancelar Movimiento de pieza");
            cursorSelectedTile.GetComponent<BoardTile>().IsMoveValid = false;           
            cursorSelectedTile.GetComponent<BoardTile>().IsVisualActive = false;
            BoardTile.isMovementCalculated = false;
            WarriorPieceSelected = null;

        }
    }

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties

    public bool IsGameStarted { get => isGameStarted; set => isGameStarted = value; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
    public Warrior WarriorPieceSelected { get => warriorPieceSelected; set => warriorPieceSelected = value; }

    #endregion

}