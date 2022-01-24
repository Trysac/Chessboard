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
    

    #endregion
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
        isGameStarted = true;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameStarted && !isGameOver)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            // shoot a raycast from our mouse cursor
            if (Physics.Raycast(ray, out hit, 99, warriorsLayerMask) && warriorPieceSelected == null)
            {
                if (Mouse.current.leftButton.isPressed)
                {
                    warriorPieceSelected = hit.collider.GetComponent<Warrior>();
                }             
            }           
            else if (Physics.Raycast(ray, out hit, 99, tileLayerMask))
            {
                cursorSelectedTile = hit.collider.GetComponent<Transform>();
                print(cursorSelectedTile.gameObject.name);
                print(cursorSelectedTile.position);
            }
            else
            {
                cursorSelectedTile = null;
            }

            // Moving the Warrior
            if (Mouse.current.leftButton.isPressed && cursorSelectedTile != null)
            {
                //if (Physics.Raycast(ray, out hit, 99, warriorsLayerMask)) 
                //{
                //    warriorPieceSelected = hit.collider.GetComponent<Warrior>();
                //}

                print("Moviendo Pieza");
                // warriorPieceSelected = null;
            }

            // cancelling the Warrior move
            if (Mouse.current.rightButton.isPressed)
            {
                print("Cancelar Movimiento de pieza");
                warriorPieceSelected = null;
            }
        }
    }

    #endregion

    // --------------------------------------------------------

    #region // Variables Properties
    #endregion

}
