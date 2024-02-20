using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGrid : MonoBehaviour
{
    private Vector3 RIGHT = new Vector3(1, 0, 0);
    private Vector3 LEFT = new Vector3(-1, 0, 0);

    private Vector3 UP = new Vector3(0, 1, 0);
    private Vector3 DOWN = new Vector3(0, -1, 0);

    private Vector3 FORWARD = new Vector3(0, 0, 1);
    private Vector3 BACK = new Vector3(0, 0, -1);

    [HideInInspector] public static List<GameObject> gridObjects = new List<GameObject>();
    [HideInInspector] public List<Player> players = new List<Player>();
    private List<Pushable> levelPushables = new List<Pushable>();

    private List<List<Vector3>> undoPositions = new List<List<Vector3>>();
    private List<Vector3> positionsToSave = new List<Vector3>();
    
    [HideInInspector] public int currentPlayerIndex;
    private int maxIndex;

    [HideInInspector] public bool pushablesCanFall = true;

    public PlayerControls playerControls;

    private Animator screenTransition = null;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        //gets all the gameobjects the player interacts with in one list
        gridObjects.Clear();

        foreach(Transform child in gameObject.transform)
        {
            gridObjects.Add(child.gameObject);
            
            //adds all players to the list
            if (child.gameObject.name.Contains("Player"))
            {
                Player player = child.gameObject.GetComponent<Player>();
                players.Add(player);

                if(player.activationIndex > maxIndex)
                {
                    maxIndex = player.activationIndex;
                }

                levelPushables.Add(player);
            }
            else if (child.gameObject.name.Contains("Box"))
            {
                levelPushables.Add(child.gameObject.GetComponent<Pushable>());
            }
        }

        GameObject managerObject = GameObject.Find("SaveManager");
        if(managerObject != null)
        {
            SaveManager saveManager = managerObject.GetComponent<SaveManager>();
            saveManager.GetAndSetUnlockedLevels();

            if (SceneManager.GetActiveScene().name.Contains("LevelSelect") && saveManager.secretLevelsUnlocked[SceneManager.GetActiveScene().buildIndex - 37])
            {
                WinPlate plate = GameObject.Find("WinPlate").GetComponent<WinPlate>();

                if (saveManager.secretLevelsCompleted[SceneManager.GetActiveScene().buildIndex - 37])
                    plate.activated = false;
                else
                    plate.activated = true;
            }
        }

        GameObject screen = GameObject.Find("ScreenTransition");
        if (screen != null)
            screenTransition = screen.GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        
        if (playerControls.Player.MoveLeft.triggered && !ObjectsAreFalling())
        {
            StartCoroutine(MoveAll(LEFT));
        }
        else if (playerControls.Player.MoveRight.triggered && !ObjectsAreFalling())
        {
            StartCoroutine(MoveAll(RIGHT));
        }
        else if (playerControls.Player.MoveBack.triggered && !ObjectsAreFalling())
        {
            StartCoroutine(MoveAll(BACK));
        }
        else if (playerControls.Player.MoveForward.triggered && !ObjectsAreFalling())
        {
            StartCoroutine(MoveAll(FORWARD));
        }
        else if (playerControls.Player.ChangePlayers.triggered)
        {
            ChangePlayers();
        }
        else if (playerControls.Player.Number1.triggered)
        {
            ChangePlayers(0);
        }
        else if (playerControls.Player.Number2.triggered)
        {
            ChangePlayers(1);
        }
        else if (playerControls.Player.Number3.triggered)
        {
            ChangePlayers(2);
        }
        else if (playerControls.Player.Number4.triggered)
        {
            ChangePlayers(3);
        }
        else if (playerControls.Player.Number5.triggered)
        {
            ChangePlayers(4);
        }
        else if (playerControls.Player.Undo.triggered)
        {
            StartCoroutine(RetrievePositions());
        }
        else if (playerControls.Player.Restart.triggered)
        {
            StartCoroutine(LoadThisLevel(SceneManager.GetActiveScene().buildIndex));
        }
        else if (playerControls.Player.Pause.triggered && !SceneManager.GetActiveScene().name.Contains("Select"))
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName.Contains("W1"))
                StartCoroutine(LoadThisLevel(37));
            else if (sceneName.Contains("W2"))
                StartCoroutine(LoadThisLevel(38));
            else if (sceneName.Contains("W3"))
                StartCoroutine(LoadThisLevel(39));
            else if (sceneName.Contains("W4"))
                StartCoroutine(LoadThisLevel(40));
        }
    }

    IEnumerator MoveAll(Vector3 direction)
    {
        SavePositionsTemporary();
        
        //lists determining whether or not pushables will move horizontally
        List<Pushable> allPushables = new List<Pushable>();
        List<bool> pushablesCanMove = new List<bool>();

        //lists determining whether or not pushables will move up
        List<Pushable> allPushablesMovingUp = new List<Pushable>();
        List<bool> pushablesCanMoveUp = new List<bool>();

        foreach (Player player in players)
        {
            bool playerIsAlreadyInStack = false;
            foreach (Pushable pushDown in player.GetAllPushablesInDirection(DOWN))
            {              
                if (pushDown.name.Contains("Player"))
                {                    
                    Player playerScript = pushDown.gameObject.GetComponent<Player>();
                    if (playerScript.activationIndex == currentPlayerIndex && (playerScript.CanClimbUpwards(direction) || playerScript.CanMoveInDirection(direction)))
                    {
                        playerIsAlreadyInStack = true;
                        break;
                    }
                }
                else
                {
                    List<Pushable> pushablesInDirection = pushDown.GetAllPushablesInDirectionWithNoLimits(-direction);

                    foreach(Pushable pu in pushablesInDirection)
                    {
                        if(pu.name.Contains("Player") && pu.GetComponent<Player>().activationIndex == currentPlayerIndex)
                        {
                            playerIsAlreadyInStack = true;
                            break;
                        }
                           
                    }
                }
            }

            if (!playerIsAlreadyInStack && player.activationIndex == currentPlayerIndex)
            {

                List<Pushable> pushables = player.GetAllPushablesInDirection(direction);
                List<bool> canMove = new List<bool>();

                //gets all objects that are on the same horizontal level
                List<Pushable> horizontalPushables = new List<Pushable>(pushables);

                foreach (Pushable push in horizontalPushables)
                {
                    canMove.Add(push.CanMoveInDirection(direction));
                }

                //gets all objects that are on top of each horizontal one
                foreach (Pushable push in horizontalPushables)
                {
                    List<Pushable> pushablesAbove = push.GetAllPushablesInDirection(UP);
                    player.SortPushablesFromBottomToTop(ref pushablesAbove);

                    bool topWillMove = true;
                    foreach (Pushable abovePush in pushablesAbove)
                    {
                        pushables.Add(abovePush);

                        if (topWillMove)
                        {
                            Pushable below = abovePush.GetPushableInDirection(DOWN);
                            topWillMove = below != null && below.CanMoveInDirection(direction) && abovePush.CanMoveInDirection(direction);
                            canMove.Add(topWillMove);
                        }
                        else
                        {
                            canMove.Add(false);
                        }
                    }
                }

                //moves the player and all the blocks stacked on their head upwards
                if (!player.CanMoveInDirection(direction) && player.CanClimbUpwards(direction))
                {
                    //takes care of moving player and row on top of player when moving up
                    List<Pushable> pushablesMovingWithPlayer = player.GetAllPushablesInDirection(UP);
                    List<bool> pushablesWithPlayerCanMove = new List<bool>();

                    pushablesMovingWithPlayer.Add(player);

                    player.SortPushablesFromBottomToTop(ref pushablesMovingWithPlayer);

                    bool topWillMove = true;
                    foreach (Pushable push in pushablesMovingWithPlayer)
                    {
                        if (topWillMove)
                        {
                            Pushable below = push.GetPushableInDirection(DOWN);
                            topWillMove = (push == player || below != null && below.CanMoveInDirection(direction + UP)) && push.CanClimbUpwards(direction);
                            pushablesWithPlayerCanMove.Add(topWillMove);
                        }
                        else
                        {
                            pushablesWithPlayerCanMove.Add(false);
                        }
                    }

                    //appends all pushables to master list
                    AppendPushableListToList(ref allPushablesMovingUp, ref pushablesMovingWithPlayer);
                    AppendBoolListToList(ref pushablesCanMoveUp, ref pushablesWithPlayerCanMove);

                }
                else
                {
                    //takes care of moving player and row on top of player when not moving up
                    pushables.Add(player);
                    canMove.Add(player.CanMoveInDirection(direction));

                    List<Pushable> pushablesAbove = player.GetAllPushablesInDirection(UP);
                    player.SortPushablesFromBottomToTop(ref pushablesAbove);

                    bool topWillMove = true;
                    foreach (Pushable abovePush in pushablesAbove)
                    {
                        pushables.Add(abovePush);

                        if (topWillMove)
                        {
                            Pushable below = abovePush.GetPushableInDirection(DOWN);
                            topWillMove = below != null && below.CanMoveInDirection(direction) && abovePush.CanMoveInDirection(direction);
                            canMove.Add(topWillMove);
                        }
                        else
                        {
                            canMove.Add(false);
                        }
                    }
                }

                //appends all pushables to master list
                AppendPushableListToList(ref allPushables, ref pushables);
                AppendBoolListToList(ref pushablesCanMove, ref canMove);
            }
        }

        pushablesCanFall = false;

        bool anyHasMoved = false;
        //pushes all the objects, excluding the player and all objects stacked on top of player when moving upwards
        for (int i = 0; i < allPushables.Count; i++)
        {
            if (pushablesCanMove[i])
            {
                allPushables[i].MoveInDirection(direction);
                anyHasMoved = true;
            }
        }

        //moves all the objects on top of players upwards
        for (int i = 0; i < allPushablesMovingUp.Count; i++)
        {
            if (pushablesCanMoveUp[i])
            {
                allPushablesMovingUp[i].MoveInDirection(direction + UP);
                anyHasMoved = true;
            }
        }

        if (anyHasMoved && !AllPlayersOfIndexAreFalling())
        {            
           SavePositionsFinal();
        }

        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        pushablesCanFall = true;
    }




    //adds contents of one pushable list to another
    public void AppendPushableListToList(ref List<Pushable> gainsContents, ref List<Pushable> usesContents)
    {
        foreach(Pushable push in usesContents)
        {
            gainsContents.Add(push);
        }
    }

    //adds contents of one bool list to another
    public void AppendBoolListToList(ref List<bool> gainsContents, ref List<bool> usesContents)
    {
        foreach (bool push in usesContents)
        {
            gainsContents.Add(push);
        }
    }

    //changes player index to change active players
    private void ChangePlayers()
    {
        if (currentPlayerIndex < maxIndex)
            currentPlayerIndex++;
        else
            currentPlayerIndex = 0;
    }

    //changes player index to change active players
    private void ChangePlayers(int num)
    {
        if(num <= maxIndex)
        {
            currentPlayerIndex = num;
        }  
    }

    //returns whether or not any player is falling
    private bool ObjectsAreFalling()
    {
        foreach(Pushable push in levelPushables)
        {
            if (push.isFalling && !push.FallingOffAnEdge())
            {
                return true;
            }
        }
        return false;
    }

    //returns whether or not all players of a specific index are falling
    private bool AllPlayersOfIndexAreFalling()
    {
        foreach (Player player in players)
        {
            if (!player.isFalling && player.activationIndex == currentPlayerIndex)
            {
                return false;
            }
        }
        return true;
    }

    //records positions for undoing in a temporary variable
    private void SavePositionsTemporary()
    {
        positionsToSave = new List<Vector3>();

        foreach(GameObject obj in gridObjects)
        {
            positionsToSave.Add(obj.transform.position);
        }
    }

    //finalizes the saved position
    private void SavePositionsFinal()
    {
        undoPositions.Insert(0, positionsToSave);

        if(undoPositions.Count > 200)
        {
            undoPositions.RemoveAt(undoPositions.Count - 1);
        }

    }

    //retrieves positions for undoing and delays falling by 0.1 seconds
    private IEnumerator RetrievePositions()
    {
        pushablesCanFall = false;

        if (undoPositions.Count > 0)
        {
            for (int i = 0; i < gridObjects.Count; i++)
            {
                gridObjects[i].transform.position = undoPositions[0][i];
            }

            undoPositions.RemoveAt(0);
        }

        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        pushablesCanFall = true;
    }

    private IEnumerator LoadThisLevel(int loadIndex)
    {
        if (screenTransition != null)
        {
            screenTransition.SetTrigger("EndTransition");
        }
        yield return new WaitForSeconds(0.45f);
        SceneManager.LoadScene(loadIndex);
    }

}
