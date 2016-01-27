using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	private float destroyTime = 10f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	
	}

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
       
            if (gameObject.tag == "Bad Company")
            {
                ScoreManager.score -= 15;

            }
            if (gameObject.tag == "Good Company")
            {
                ScoreManager.score += 10;
            }
            Destroy(gameObject);

        }
       

    }

}
