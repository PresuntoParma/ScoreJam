using System.Collections;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Transform target;
    public float duration = 1.5f;
    public float arcHeight = 3f;

    [SerializeField] private float kickDistance;
    [SerializeField] private TargetScript targetScript;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject canvasLose;
    [SerializeField] private TextMeshProUGUI textScoreLose;

    private void Start()
    {
        Launch();
        canvasLose.SetActive(false);
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
        yield return new WaitForSeconds(0.1f);
        canvasLose.SetActive(true);
        textScoreLose.text = "Score: " + scoreManager.ScoreLose().ToString();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Kick" && targetScript.IsKickable())
        {
            scoreManager.Score();
            targetScript.Move();
            StopAllCoroutines();
            Launch();
        }
    }

    
}
