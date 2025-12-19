using Unity.Properties;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    private bool isKickable;

    public void Move()
    {
        transform.position = new Vector2(Random.Range(-7f, 8f), Random.Range(-5f, 6f));
    }

    public void KickTime()
    {
        isKickable = true;
    }

    public bool IsKickable()
    {
        return isKickable;
    }

    public void NotKickTime()
    {
        isKickable = false;
    }

    public void TouchGround()
    {

    }

}
