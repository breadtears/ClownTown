using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this lets you call images which are used in the UI buttons, toggles
using UnityEngine.SceneManagement; //this lets you call the scenemanager which loads levels
using UnityEngine.Audio; //this calls the audio mixer

public class csharpscriptnotes2 : MonoBehaviour
{
    //Jade Peters
    public csharpscriptnotes2 n2;
    public GameObject GO;
    public Image myimage;
    public Button mybutton;
    public float timer;
    // Start is called before the first frame update

    //AI
    //MOVE TOWARDS (moves object towards another) flying follower enemy uses this
    public Vector3 start; //the start location
    public Vector3 finish; //the end location or target
    public float speed; //how fast the mover goes from start to finish

    //LOOT
    public GameObject money;

    //ARRAY an array is a collection of gameObjects. Arrays allow us to affect large groups of objects

    public GameObject[] alltheenemies; //the straight brackets signify a collection of gameobjects

    //PLAYER PREFS
    //these are values that will save even after the player leaves the game this is good for unloackable content or ovrall progress. this can work for character skins

    public int GreenBird; //this is not a normal int

    void Start()
    {
        PlayerPrefs.SetInt("GreenBird", 2); //this will unloack the green bird, so only do it when it's ready to be unlocked
        //before this it would be set to a 0 or a 1

        if (PlayerPrefs.HasKey("GreenBird"))
        {
            GreenBird = PlayerPrefs.GetInt("GreenBird"); //if i beat the game it will be 2
            //if I didn't beat the game it will equal 1
        }

        if(GreenBird == 2)
        {
            //I can select the green bird
        }

        alltheenemies = GameObject.FindGameObjectsWithTag("enemy"); //this grabs all the enemies

        //ENABLED vs. SET ACTIVE
        //we enable and disable components attatched to gameObjects
        //we set active true or false entire gameObjects

        n2.enabled = true; //enabled the notes2 script (box collider, scripts, any component)
        GO.SetActive(true); //enabled the entire gameObject
        StartCoroutine(StarPower()); //this line calles the IEnumerator (don't do this in update)
    }

    // Update is called once per frame
    void Update()
    {
        //TIMERS
        //we can create timers using the command Time.deltaTime. This means time that has passed since the last frame (so a contsant timer)
        //We can take a float and add or subtract the Time.deltaTime to create a timer that counts up or down.
        timer -= Time.deltaTime; //-= subtracts time from the timer consistently
        timer += Time.deltaTime; //+= adds time to the timer

        if(timer >= 0)
        {
            mybutton.interactable = true; //this allows the button to be pressed
        }

        if (timer <= 0)
        {
            mybutton.interactable = false; //this greys out
        }

        Vector3.MoveTowards(start, finish, speed); //this line will move the object
        //the start position is set to the movers position
        //the target position gets set to another gameobject (usually the player)
        //the speed is constant

        //INSTANTIATE is a way to make things appear in our scene, this could be enemies' loot, powerups, etc

        GameObject Loot = Instantiate(money, transform.position, transform.rotation);
        //the above line makes a new gameobject by creating money at our current location
        //we say GameObject loot because we are creating a new game object in the hierarchy called loot
        //money is usually a prefab that we can call over and over again. This means money won't be in the hierarchy but inside the game's asset folder
        Destroy(money, 5f); //this destroys the money if we don't get it fast enough

        //AUTOPOOLING- we are using a plugin called Mobb Farm Auto Pooler
        GameObject loot2 = MF_AutoPool.Spawn(money, transform.position, transform.rotation);
        //this is the mobile friendly version
        MF_AutoPool.Despawn(this.gameObject, 5f); //this would be on the money itself and would put it back into the pool without any leftover issues

        //ARRAY (how to go through your list and affect each object one at a time)
        //FOR LOOP
        for (int i = 0; i < alltheenemies.Length; i++)
        {
            alltheenemies[i].SetActive(true); //we set each enemy active
        }
        //int i = 0 means we start at the top of the list
        //i < allenemies, emans as long as the number we're on isn't larger than the list
        //let's say that the list is 10 long- if we are at 0, 0 < 10 so we add another so on until we get to ten
        //i++ we move down the list by one

    }
    private void ontriggerenter2d(Collider2D collision)
    {
       //this statement is used when we want the player to walk into a specific area and trigger something
       //this could be animation, an enemy, anything you want
       //an event is triggered when the player apsses through a collider that is marked as a trigger. Either the player or the
       //collider must have a rigidbody in order for the hit to register

       if(collision.tag == "Player")
        {
            //then we trigger the event. this will only trigger if the collider has the tag "player" so enemies can't trigger this event

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //unlike a trigger a collision happens when 2 colliders bump into each other but do not pass through
    }


    //CO-ROUTINE which unit calls IEnumerator
    //normal functions in unity are read top to bottom all at once. sometimes we want to pause before finishing the function, which is when we use
    //IEnumerator. Think of this as the star power in SMB, when you get the star the player is invincible for a shortime, the sprite changes,
    //the music changes, and then eventually it wears off

    public IEnumerator StarPower()
    {
        //Give Mario star power
        //change music
        //change sprite graphics
        //then we want to wait
        yield return new WaitForSeconds(5f); //this line makes Unity wait for 5 seconds
        //star power wears off
        //change music back
        //change sprite back

        yield return new WaitForSeconds(5f);
    }

    //to call an IEnumerator we use the word Co-Routine (see Start loop)

}
