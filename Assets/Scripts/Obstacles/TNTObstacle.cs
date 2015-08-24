﻿using UnityEngine;
using System.Collections;

public class TNTObstacle : Obstacle {

    public Transform explosionPrefab;

    public override void OnTriggerEnter2D(Collider2D coll) {
        base.OnTriggerEnter2D(coll);
        if (explosionPrefab != null) {
            if ( !GlobalManager.rage.activated ) {
                GetExplostion ( );
            } else {
                StartCoroutine ( Explode ( 0.1f ) );
            }
        }
    }

    void GetExplostion ( ) {
        Instantiate ( explosionPrefab, transform.position, Quaternion.identity );
        transform.GetComponent<Renderer> ( ).enabled = false;
    }
    IEnumerator Explode ( float time ) {
        yield return new WaitForSeconds ( time );
        GetExplostion ( );
    }
}
