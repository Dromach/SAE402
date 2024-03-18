using UnityEngine;
using System.Collections;

public class BlockHit : MonoBehaviour {

    public int MaxHits = -1;
    private bool isAnimating = false;
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player") && !isAnimating && MaxHits != 0) {
            Vector3 upDirection = transform.TransformDirection(Vector3.up);
            Vector3 compareDirection = (collision.transform.position - transform.position).normalized;

            if(Vector3.Dot(upDirection, compareDirection) < 0) {
                StartCoroutine(Hit());
            }
        }
    }
    IEnumerator Hit() {
        isAnimating = true;
        Vector3 endPosition = transform.position + Vector3.up = 0.5f;
        yield return transform.MoveBackAndForth(endPosition);
        isAnimating = false;
        MaxHits--;
    }
}