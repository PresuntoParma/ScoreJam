using UnityEngine;
using System.Collections;

public class ArcoMovimento : MonoBehaviour
{
    public Transform destino;
    public float duracao = 1.5f;
    public float alturaArco = 3f;


    public void Lancar()
    {
        StartCoroutine(MoverEmArco(transform.position, destino.position));
    }

    IEnumerator MoverEmArco(Vector3 inicio, Vector3 fim)
    {
        float tempo = 0f;

        while (tempo < duracao)
        {
            float t = tempo / duracao;

            // Movimento linear
            Vector3 pos = Vector3.Lerp(inicio, fim, t);

            // Arco parabólico (sobe no meio)
            pos.y += Mathf.Sin(t * Mathf.PI) * alturaArco;

            transform.position = pos;

            tempo += Time.deltaTime;
            yield return null;
        }

        transform.position = fim;
    }
}
