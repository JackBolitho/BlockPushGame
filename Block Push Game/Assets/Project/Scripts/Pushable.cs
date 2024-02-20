using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    //directions because I am lazy
    protected Vector3 RIGHT = new Vector3(1, 0, 0);
    protected Vector3 LEFT = new Vector3(-1, 0, 0);

    protected Vector3 UP = new Vector3(0, 1, 0);
    protected Vector3 DOWN = new Vector3(0, -1, 0);

    protected Vector3 FORWARD = new Vector3(0, 0, 1);
    protected Vector3 BACK = new Vector3(0, 0, -1);

    private LevelGrid levelGrid;
    [HideInInspector] public bool isFalling = false;

    public bool isGhost;

    private void Start()
    {
        levelGrid = GetComponentInParent<LevelGrid>();
        graphicsObject = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (levelGrid.pushablesCanFall)
            isFalling = MoveInDirectionAndCheck(DOWN);
        else
            isFalling = true;
    }

    //if an object can move in a specific direction, it is moved in that direction
    public bool MoveInDirectionAndCheck(Vector3 direction)
    {
        if (CanMoveInDirection(direction))
        {
            MoveInDirection(direction);
            return true;
        }
        return false;
    }

    //moves an object in a specified direction
    public void MoveInDirection(Vector3 direction)
    {
        MoveToPosition(transform.position + direction);
        StartCoroutine(AnimateMovement(direction));
    }

    //moves an object to a specified position
    public void MoveToPosition(Vector3 position)
    {
        transform.position = position;
    }

    //checks if a space in a direction is avaliable to move to, meaning that there are no walls in the space
    public bool CanMoveInDirection(Vector3 direction)
    {
        List<GameObject> objectsInPosition = ObjectsAtPosition(transform.position + direction);
        foreach(GameObject obj in objectsInPosition)
        {
            if (obj.name.Contains("Wall") || (obj.name.Contains("Ghost") && isGhost))
            {
                return false;
            }          
        }

        foreach (GameObject obj in objectsInPosition)
        {
            //recursively checks the next box to see if it can move there
            Pushable push = obj.GetComponent<Pushable>();
            Player player = obj.GetComponent<Player>();

            if(player != null && !direction.Equals(DOWN) && player.activationIndex == levelGrid.currentPlayerIndex)
            {
                return push.CanMoveInDirection(direction) || push.CanClimbUpwards(direction);
            }
            else if (push != null)
            {
                return push.CanMoveInDirection(direction);
            }
        }

        return true;
    }

    //returns all of the objects in a specific direciton 
    public List<GameObject> ObjectsInDirection(Vector3 direction)
    {
        return ObjectsAtPosition(transform.position + direction);
    }

    //returns all of the objects at a specific position
    public List<GameObject> ObjectsAtPosition(Vector3 position)
    {
        List<GameObject> inPosition = new List<GameObject>();

        foreach (GameObject obj in LevelGrid.gridObjects)
        {
            if (PositionIsInObject(position, obj))
            {
                inPosition.Add(obj);
            }
        }

        return inPosition;
    }

    //returns all of the objects at a specific position
    public List<GameObject> ObjectsAtPosition(Vector3 position, List<GameObject> objects)
    {
        List<GameObject> inPosition = new List<GameObject>();

        foreach(GameObject obj in objects)
            if(PositionIsInObject(position, obj))
                inPosition.Add(obj);

        return inPosition;
    }

    //gets one pushable from a specific direction
    public Pushable GetPushableInDirection(Vector3 direction)
    {
        List<GameObject> adjacentObjects = ObjectsInDirection(direction);
        foreach(GameObject obj in adjacentObjects)
        {
            Pushable push = obj.GetComponent<Pushable>();
            if (push != null)
                return push;
        }
        return null;
    }

    //gets all pushables in a specific direction until it hits a player, unless it goes up or down
    public List<Pushable> GetAllPushablesInDirection(Vector3 direction)
    {
        List<Pushable> pushables = new List<Pushable>();

        Pushable push = GetPushableInDirection(direction);
        Pushable previousPush = this;

        Player player = null;
        if (push != null && push.name.Contains("Player"))
            player = push.gameObject.GetComponent<Player>();

        while (push != null && (player == null || player.activationIndex != levelGrid.currentPlayerIndex || direction.Equals(UP) || direction.Equals(DOWN)))
        {
            //checks to make sure pushable list does not include objects in walls
            List<GameObject> objectsInPosition = ObjectsInDirection(direction);
            bool containsGhostWall = false;
            foreach(GameObject inPos in objectsInPosition)
            {
                if (inPos.name.Contains("Ghost"))
                    containsGhostWall = true;
            }

            if (previousPush.isGhost && !push.isGhost && containsGhostWall && !direction.Equals(UP) && !direction.Equals(DOWN))
            {
                return pushables;
            }

            //checks to make sure player is not under pushables, which prevents repeat pushes when using multiple players
             Pushable bottom = push.GetBottomPushable();

             if (bottom != null && bottom.name.Contains("Player") && bottom != player && !direction.Equals(UP) && !direction.Equals(DOWN))
             {
                 Player play = bottom.gameObject.GetComponent<Player>();
                 if(play != null && play.activationIndex == levelGrid.currentPlayerIndex && play.CanClimbUpwards(direction))
                     return pushables;
             }

            pushables.Add(push);
            previousPush = push;
            push = push.GetPushableInDirection(direction);
            
            if (push != null && push.name.Contains("Player"))
                player = push.gameObject.GetComponent<Player>();
        }

        return pushables;
    }

    //gets all pushables in a specific direction
    public List<Pushable> GetAllPushablesInDirectionWithNoLimits(Vector3 direction)
    {
        List<Pushable> pushables = new List<Pushable>();

        Pushable push = GetPushableInDirection(direction);
        while (push != null)
        {
            pushables.Add(push);
            push = push.GetPushableInDirection(direction);
        }

        return pushables;
    }

    //gets the bottommost pushable in a stack
    public Pushable GetBottomPushable()
    {
        Pushable push = this;
        Pushable nextPush = push.GetPushableInDirection(DOWN);
        while(nextPush != null)
        {
            push = nextPush;
            nextPush = push.GetPushableInDirection(DOWN);
        }

        return push;
    }

    //returns if a specific point is within the area of an object
    public bool PositionIsInObject(Vector3 position, GameObject obj)
    {
        return obj != null && obj.transform.position.x - obj.transform.localScale.x / 2 < position.x &&
               obj.transform.position.x + obj.transform.localScale.x / 2 > position.x &&
               obj.transform.position.y - obj.transform.localScale.y / 2 < position.y &&
               obj.transform.position.y + obj.transform.localScale.y / 2 > position.y &&
               obj.transform.position.z - obj.transform.localScale.z / 2 < position.z &&
               obj.transform.position.z + obj.transform.localScale.z / 2 > position.z;
    }

    //orders [ushables from lowest y value to highest y value
    public void SortPushablesFromBottomToTop(ref List<Pushable> pushables)
    {
        for (int i = 0; i < pushables.Count - 1; i++)
        {
            for (int j = 0; j < pushables.Count - 1; j++)
            {
                if(pushables[j].transform.position.y > pushables[j + 1].transform.position.y)
                {
                    Pushable temp = pushables[j];
                    pushables[j] = pushables[j + 1];
                    pushables[j + 1] = temp;
                }
            }
        }
    }

    //determines whether or not an object can climb upwards
    public bool CanClimbUpwards(Vector3 direction)
    {
        return CanMoveInDirection(direction + UP) && CanMoveInDirection(UP) && GetPushableInDirection(direction + UP) == null;
    }

    //makes motion look smooth
    protected GameObject graphicsObject;

    private IEnumerator AnimateMovement(Vector3 direction)
    {
        graphicsObject.transform.position -= direction;

        while (!CloseEnough(graphicsObject.transform.position, transform.position, 0.05f))//!graphicsObject.transform.position.Equals(transform.position))
        {
            if(levelGrid.playerControls.Player.Undo.triggered)
            {
                graphicsObject.transform.position = transform.position;
                break;
            }

            graphicsObject.transform.position = Vector3.Lerp(graphicsObject.transform.position, transform.position, 0.3f);     // = (gameObject.transform.position + graphicsObject.transform.position) / 2f;

            yield return new WaitForEndOfFrame();
        }

        graphicsObject.transform.position = transform.position;
    }

    //returns whether or not two vectors are close enough, determined by variance
    private bool CloseEnough(Vector3 v1, Vector3 v2, float var)
    {
        return v1.x + var > v2.x && v1.x - var < v2.x &&
               v1.y + var > v2.y && v1.y - var < v2.y &&
               v1.z + var > v2.z && v1.z - var < v2.z;
    }

    //determines whether or not an object is falling indefinitely
    public bool FallingOffAnEdge()
    {
        return transform.position.y < 0f;
    }

}
