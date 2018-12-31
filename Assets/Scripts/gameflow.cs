/* 1. TODO na dinei to N o user
   2. TODO na topotheteitai i camera sto (round(Ν/2), round(Ν/2), 2) 
   dld sto kentro tou epipedou 2
   
*/

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class gameflow : MonoBehaviour
{
    public Transform redCube;
    public Transform blueCube;
    public Transform greenCube;
    public Transform yellowCube;
    public Transform tealCube;
    public Transform magentaCube;
    public Camera cmr;
    public Light lght;
    public Transform slot0text;
    public Transform slot1text;
    public Transform slot2text;
    public Transform slot3text;

    public Transform slot0Qtext;
    public Transform slot1Qtext;
    public Transform slot2Qtext;
    public Transform slot3Qtext;

    //green,red,yellow,teal(cylinder)
    public static List<string> invSlot = new List<string>()
    {
        "green", "red", "yellow", "teal"
    };
    //green,red.yellow,teal(cylinder)
    public static List<int> invSlotQuant = new List<int>()
    {
        0,0,0,0
    };

    public int N;
    int floorSize;
    public int rand;
    private Vector3 vctr1 = new Vector3(45, 45, 0);
    private Vector3 vctr2 = new Vector3(135, 45, 0);


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        floorSize = N * 4; // each level is 4 in height
        if (N % 2 == 0) // N is even
        {
            createEvenGrid();
        }
        else //N is odd
        {

            createOddGrid();
        }

    }

    void Update()
    {
        slot0text.GetComponent<Text>().text = invSlot[0];
        slot1text.GetComponent<Text>().text = invSlot[1];
        slot2text.GetComponent<Text>().text = invSlot[2];
        slot3text.GetComponent<Text>().text = invSlot[3];

        slot0Qtext.GetComponent<Text>().text = invSlotQuant[0].ToString();
        slot1Qtext.GetComponent<Text>().text = invSlotQuant[1].ToString();
        slot2Qtext.GetComponent<Text>().text = invSlotQuant[2].ToString();
        slot3Qtext.GetComponent<Text>().text = invSlotQuant[3].ToString();
    }

    void createOddGrid()
    {
        Instantiate(magentaCube, new Vector3((N / 2), 0, (N / 2)), magentaCube.rotation);
        Instantiate(cmr, transform.position + transform.right * (N / 2) + transform.up * ((N / 2) + 4) + transform.forward * (N / 2), transform.rotation);
        Instantiate(lght, transform.position + transform.up * floorSize + transform.forward * (-(N / 2)) + transform.right * (-(N / 2)), Quaternion.Euler(vctr1));
        Instantiate(lght, transform.position + transform.up * floorSize + transform.forward * N + transform.right * N, Quaternion.Euler(vctr2));
        for (int xPos = 0; xPos < N; xPos++)

        {
            for (int zPos = 0; zPos < N; zPos++)
            {
                for (int yPos = 0; yPos < N * 4; yPos += 4) //ipsos kathe pistas 4
                {
                    rand = Random.Range(1, 6);
                    if (rand == 1)
                    {
                        if ((xPos == (N / 2)) && (yPos == 0) && (zPos == (N / 2)))
                        {
                            continue;
                        }
                        Instantiate(redCube, new Vector3(xPos, yPos, zPos), redCube.rotation);
                    }
                    else if (rand == 2)
                    {
                        if ((xPos == (N / 2)) && (yPos == 0) && (zPos == (N / 2)))
                        {
                            continue;
                        }
                        Instantiate(blueCube, new Vector3(xPos, yPos, zPos), blueCube.rotation);
                    }
                    else if (rand == 3)
                    {
                        if ((xPos == (N / 2)) && (yPos == 0) && (zPos == (N / 2)))
                        {
                            continue;
                        }
                        Instantiate(greenCube, new Vector3(xPos, yPos, zPos), greenCube.rotation);
                    }
                    else if (rand == 4)
                    {
                        if ((xPos == (N / 2)) && (yPos == 0) && (zPos == (N / 2)))
                        {
                            continue;
                        }
                        Instantiate(yellowCube, new Vector3(xPos, yPos, zPos), yellowCube.rotation);
                    }
                    else if (rand == 5)
                    {
                        if ((xPos == (N / 2)) && (yPos == 0) && (zPos == (N / 2)))
                        {
                            continue;
                        }
                        Instantiate(tealCube, new Vector3(xPos, yPos, zPos), tealCube.rotation);
                    }
                }
            }
        }
    }

    void createEvenGrid()
    {
        Instantiate(magentaCube, new Vector3(((N / 2) - 1), 0, ((N / 2) - 1)), magentaCube.rotation);
        Instantiate(cmr, transform.position + transform.right * ((N / 2) - 1) + transform.up * ((N / 2) + 3) + transform.forward * ((N / 2) - 1), transform.rotation);
        Instantiate(lght, transform.position + transform.up * floorSize + transform.forward * (-((N / 2) - 1)) + transform.right * (-((N / 2) - 1)), Quaternion.Euler(vctr1));
        Instantiate(lght, transform.position + transform.up * floorSize + transform.forward * N + transform.right * N, Quaternion.Euler(vctr2));

        for (int xPos = 0; xPos < N; xPos++)

        {
            for (int zPos = 0; zPos < N; zPos++)
            {
                for (int yPos = 0; yPos < N * 4; yPos += 4)
                {
                    rand = Random.Range(1, 6);
                    if (rand == 1)
                    {
                        if ((xPos == ((N / 2) - 1)) && (yPos == 0) && (zPos == ((N / 2) - 1)))
                        {
                            continue;
                        }
                        Instantiate(redCube, new Vector3(xPos, yPos, zPos), redCube.rotation);

                    }
                    else if (rand == 2)
                    {
                        if ((xPos == ((N / 2) - 1)) && (yPos == 0) && (zPos == ((N / 2) - 1)))
                        {
                            continue;
                        }
                        Instantiate(blueCube, new Vector3(xPos, yPos, zPos), blueCube.rotation);
                    }
                    else if (rand == 3)
                    {
                        if ((xPos == ((N / 2) - 1)) && (yPos == 0) && (zPos == ((N / 2) - 1)))
                        {
                            continue;
                        }
                        Instantiate(greenCube, new Vector3(xPos, yPos, zPos), greenCube.rotation);
                    }
                    else if (rand == 4)
                    {
                        if ((xPos == ((N / 2) - 1)) && (yPos == 0) && (zPos == ((N / 2) - 1)))
                        {
                            continue;
                        }
                        Instantiate(yellowCube, new Vector3(xPos, yPos, zPos), yellowCube.rotation);
                    }
                    else if (rand == 5)
                    {
                        if ((xPos == ((N / 2) - 1)) && (yPos == 0) && (zPos == ((N / 2) - 1)))
                        {
                            continue;
                        }
                        Instantiate(tealCube, new Vector3(xPos, yPos, zPos), tealCube.rotation);
                    }
                }
            }
        }
    }
}


