using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csharpscripty : MonoBehaviour
{

    //Jade Peters
    //Two forward slashes allows for comments, not read by engine
    //the top part of the script is generally where variables are stored
    //things like numbers, references to objects or references to other scripts
    //variables have 3 parts, the 1st part is public or private, the 2nd part is the type of variable, 3rd part is whatever variable is named

    //NUMBER VARIABLES
    //2 common types of number variables- floats and ints
    public float number; //float stands for floating point decimal which means the number has a decimal point. 1.25 is a float
    public int wholenumber; //1,2,3 are ints (integers)
    private float myhiddennumber; //a private variable is not visible inside the inspector

    //BOOLS (true/false statements)
    public bool yesorno; //a bool is a yes or no statement, a binary, think of it like a light switch- on or off, no inbetween

    //other common variables
    public GameObject mygameobject; //we can refernce any object in our scene, all items in the hierarchy are considered game objects- everything in list on the sidde
    public csharpscripty CSN; //we can also reference any script that is written as long as it is public
    public Rigidbody2D myRB2D; //we can use rigid body on players andd anything we want to be affected by unity's physics
    public BoxCollider2D myboxcollider; //colliders of all types can be referenced
    public CircleCollider2D mycirclecollider;
    //we usually put these refernces at the top of the script, we need to call them here first if we want to manipulate them further in the script


    // Start is called before the first frame update
    void Start()
    {
        //anything we want to happen when the game starts (and only then) goes here
        //sometimes we don't want to have to manually drag and drop items in the inspector
        //sometimes we want to spawn new items during gameplay. In this case we can use a few simple commands to have the script automatically find objects

        myRB2D = GetComponent<Rigidbody2D>(); //this will get the rigid body but only if it's on the same object as our script
        myRB2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //this will find any object in our scene that has the tag player and get its rigidbody
        myRB2D = GameObject.FindObjectOfType<Rigidbody2D>();
        //this only works when there is no more than one rigidbody

        //when the game starts we also might want to look at a few different properties of our gameobjects, transform, position, rotation, and scale
        transform.position = new Vector2(0, 0);
        //the transform position is our location on x and y. Transforms are read by unity as something calledd a vector (Vector 2 or Vector 3). Think of a vector like a
        //bar graph- the x is the horizontal axis and the y is the vertical axis. the Vector 2 above is at origin position. Another example would be:
        transform.position = new Vector2(24, 128); //this would move us 24 units right and 128 units up.
        //We can also manipulate the scale this way:
        transform.localScale = new Vector2(0, 0); //2D
        transform.localScale = new Vector3(0,0,0) //3d
        //both these scalles would be invisible
        //rotation is a little more complicated. We use quaternion and EULER (oiler)
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
     //inside the update function we call things that we want to update in real time as we play the game

        //IF STATEMENTS
        if (yesorno == true)
        {
            //we say yes
            //the player lives
        }

        if (yesorno == false)
        {
            //we say no
            //the player dies
        }

        if(number >= 10)
        {
            //we do something
        }

        //we can also use if statements to control the player
        if(Input.GetAxis("Horizontal") > 0)
        {
            //we move the player
            myRB2D.velocity = new Vector2(25,0)
        }
        if (Input.GetAxis("Horizontal") == 0)

            //we want to stop the player
            myRB2D.velocity = new Vector2(0, 0); //this is a zero velocity
        //to see all the different rigidbody options we have just have to start typing myRB2D
        myRB2D.gravityScale = .5F //gives me half gravity
        myRB2D.simulated = false; //this means the rigid body is no longer affected by the physics engine
        myRB2D.isKinematic = true; //kinematic rigidbody only mobves if the code tells it too
        myRB2D.isKinematic = false; //nonkinematic is the same dynamic which means it is affected by the physics engine

        //this is also an example of how bools can work. If the bool is true, then one thing happens, if the bool is false, something else happens
    }
    //for the 'if' statement to work we need a double equal sign. a single equal sign means that the bool IS true or IS false
    //whereas a double equal sign checks to see IF it's true or false


    //IF ELSE STATEMENTS
    //if statements get read one after the other ehich can sometimes can cause weird behavior. we can avoid this by using if else statements

    if (yesorno == true)
        {
            //we say yes
            //the player lives
            //if this turns out true we won't read the below statement
        }

    else if (yesorno == false)
        {
            //we say no
            //the player dies
            //if the above statement is not true we will then read this statement
        }

    //because the code is in the update loop changes can happen quickly and we can cycle thru multiple if statements faster than we want to. This is why we use else
}

public void FixedUpdate()
{
    //regular update is based on frame rate which means that a newer computer will run the code faster and an older one will run the code slower. this is not ideal
    //for the most part graphcial elements can live inside the update loop without any issue. the fixed update loop is used for physics calculations as it's called
    //on a set interval whoch means that all computers run the code at the same speed
}