using Unity.Properties;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    private bool isKickable;

    public void Move()
    {
        transform.position = new Vector2(Random.Range(-6.1f, 6.2f), Random.Range(-4f, 2.1f));
    }

    public void KickTime()
    {
        isKickable = true;
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public bool IsKickable()
    {
        return isKickable;
    }

    public void NotKickTime()
    {
        isKickable = false;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void TouchGround()
    {

    }

}
