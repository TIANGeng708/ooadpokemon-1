﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Left Attacks, Right Hurts
//Set: Left object, Right object
public class SpecialAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pokemon1;
    public GameObject pokemon2;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject water1;
    public GameObject water2;
    public GameObject dirt1;
    public GameObject dirt2;
    public GameObject lighting1;
    public GameObject lighting2;
    public GameObject wind1;
    public GameObject wind2;
    public Animator animator1;
    public Animator animator2;
    public bool judge1;
    public bool judge2;
    public bool leftHitRight;
    public bool dodge;
    public bool dead;
    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;
    private String music1;
    private String music2;

    // Update is called once per frame
    void Update()
    {
        if (judge1)
        {
            animator1.SetTrigger("special");
            // effort
            if (music1 == "dragon1" || music1 == "dragon2")
            {
                if (music1 == "dragon1")
                {
                    Invoke("fire1set",1f);
                }
                else
                {
                    Invoke("fire2set",1f);
                }

                sound_manager.play_effect("sounds/dragonFire");
            } else if (music1 == "mouse1" || music1 == "mouse2")
            {
                if (music1 == "mouse1")
                {
                    Invoke("lighting1set",0.5f);
                }
                else
                {
                    Invoke("lighting2set",0.5f);
                }
                sound_manager.play_effect("sounds/mouseLight");
            } else if (music1 == "turtle1" || music1 == "turtle2")
            {
                if (music1 == "turtle1")
                {
                    Invoke("water1set",1f);
                }
                else
                {
                    Invoke("water2set",1f);
                }
                sound_manager.play_effect("sounds/turtleWater");
            } else if (music1 == "bird1" || music1 == "bird2")
            {
                if (music1 == "bird1")
                {
                    Invoke("wind1set",0.5f);
                }
                else
                {
                    Invoke("wind2set",0.5f);
                }
                sound_manager.play_effect("sounds/birdHit");
            } else if (music1 == "seed1" || music1 == "seed2")
            {
                sound_manager.play_effect("sounds/seedHit");
            }
            else
            {
                if (music1 == "mud1")
                {
                    Invoke("dirt1set",1f);
                }
                else
                {
                    Invoke("dirt2set",1f);
                }
                sound_manager.play_effect("sounds/mudHoul");
            }
            judge1 = false;
            Invoke("hurt",1f);
        }
        else
        {
            if (dodge && pokemon2.transform.position != p3 && judge2)
            {
                pokemon2.transform.position = Vector3.MoveTowards(pokemon2.transform.position, p3, Time.deltaTime * 10);
            }
            else if (judge2)
            {
                judge2 = false;
            }
            else
            {
                if (pokemon2.transform.position != p2)
                {
                    animator2.SetBool("move",true);
                    Invoke("run",0.5f);
                }
                else
                {
                    animator2.SetBool("move",false);
                    if (dead)
                    {
                        Invoke("die",4f);
                    }
                    enabled = false;
                }
            }
        }
    }

    public void fire1set()
    {
        fire1.SetActive(true);
        Invoke("reset",2f);
    }
    public void fire2set()
    {
        fire2.SetActive(true);
        Invoke("reset",2f);
    }
    public void lighting1set()
    {
        lighting1.SetActive(true);
        Invoke("reset",2f);
    }
    public void lighting2set()
    {
        lighting2.SetActive(true);
        Invoke("reset",2f);
    }
    public void water1set()
    {
        water1.SetActive(true);
        Invoke("reset",2f);
    }
    public void water2set()
    {
        water2.SetActive(true);
        Invoke("reset",2f);
    }
    public void dirt1set()
    {
        dirt1.SetActive(true);
        Invoke("reset",2f);
    }
    public void dirt2set()
    {
        dirt2.SetActive(true);
        Invoke("reset",2f);
    }
    public void wind1set()
    {
        wind1.SetActive(true);
        Invoke("reset",2f);
    }
    public void wind2set()
    {
        wind2.SetActive(true);
        Invoke("reset",2f);
    }

    public void reset()
    {
        fire1.SetActive(false);
        fire2.SetActive(false);
        water1.SetActive(false);
        water2.SetActive(false);
        dirt1.SetActive(false);
        dirt2.SetActive(false);
        wind1.SetActive(false);
        wind2.SetActive(false);
        lighting1.SetActive(false);
        lighting2.SetActive(false);
    }

    public void hurt()
    {
        if (dodge)
        {
            pokemon2.transform.position = p1;
        }
        else if (dead)
        {
            animator2.SetTrigger("dead");
        }
        else
        {
            animator2.SetTrigger("hurt");
        }
    }

    public void run()
    {
        pokemon2.transform.position = Vector3.MoveTowards(pokemon2.transform.position, p2, Time.deltaTime * 10);
    }

    public void die()
    {
        if (dead)
        {
            GameObject go = GameObject.Find("Window");
            if (leftHitRight)
            {
                go.GetComponent<DataBase>().Disappear2();
            }
            else
            {
                go.GetComponent<DataBase>().Disappear1();
            }
        }
    }

    public void Set(string name1, string name2,bool dir,bool miss,bool death)
    {
        music1 = name1;
        music2 = name2;
        pokemon1 = GameObject.Find(name1);
        pokemon2 = GameObject.Find(name2);
        judge1 = true;
        judge2 = true;
        leftHitRight = dir;
        dodge = miss;
        dead = death;
        animator1 = pokemon1.GetComponent<Animator>();
        animator2 = pokemon2.GetComponent<Animator>();
        if (leftHitRight)
        {
            p1 = new Vector3(14, 0, 5);
            p2 = new Vector3(10, 0, 5);
            p3 = new Vector3(14.1f, 0, 5);
        }
        else
        {
            p1 = new Vector3(-14, 0, 5);
            p2 = new Vector3(-10, 0, 5);
            p3 = new Vector3(-14.1f, 0, 5);
        }
    }
}