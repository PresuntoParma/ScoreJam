using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public Transform target;
    public float duration = 1.5f;
    public float arcHeight = 3f;

    [SerializeField] private float kickDistance;
    [SerializeField] private TargetScript targetScript;

    private void Start()
    {
        Launch();
    }

    private void Update()
    {
        CheckDistance();
    }

    public void Launch()
    {
        StartCoroutine(Move(transform.position, target.position));
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, target.position) <= kickDistance)
        {
            targetScript.KickTime();
            print("kick time");
        }
        else
        {
            targetScript.NotKickTime();
            print("not kick time");
        }
    }

    IEnumerator Move(Vector3 inicio, Vector3 fim)
    {
        float tempo = 0f;

        while (tempo < duration)
        {
            float t = tempo / duration;

            Vector3 pos = Vector3.Lerp(inicio, fim, t);
            pos.y += Mathf.Sin(t * Mathf.PI) * arcHeight;
            transform.position = pos;

            tempo += Time.deltaTime;
            yield return null;
        }

        transform.position = fim;
    }
}
