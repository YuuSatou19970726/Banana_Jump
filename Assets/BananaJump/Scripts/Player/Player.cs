using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float move_Speed = 2f;

    public float normal_Push = 10f;
    public float extra_Push = 14f;

    private bool inital_Push;

    private int push_Count;

    private bool player_Died;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.EXTRA_PUSH)
        {
            if (!inital_Push)
            {
                inital_Push = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);

                target.gameObject.SetActive(false);

                // SoundManager

                // exit from thr on trigger enter because of initial push
                return;
            }
        }
    }
}
