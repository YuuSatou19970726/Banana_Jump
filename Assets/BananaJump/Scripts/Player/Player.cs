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

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (player_Died)
            return;

        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);
        }
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

                SoundManager.instance.JumpSoundFX();

                // exit from thr on trigger enter because of initial push
                return;
            }

            // outside of the initial push

        } // because of the initial push

        if (target.tag == Tags.NORMAL_PUSH)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);

            target.gameObject.SetActive(false);

            push_Count++;

            SoundManager.instance.JumpSoundFX();
        }

        if (target.tag == Tags.EXTRA_PUSH)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, extra_Push);

            target.gameObject.SetActive(false);

            push_Count++;

            SoundManager.instance.JumpSoundFX();
        }

        if (push_Count == 2)
        {
            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if (target.tag == Tags.FALL_DOWN || target.tag == Tags.BIRD_TAG)
        {
            player_Died = true;

            // SoundManager
            SoundManager.instance.GameOverSoundFX();

            // GameManager
            GameManager.instance.RestartGame();
        }
    }
}
