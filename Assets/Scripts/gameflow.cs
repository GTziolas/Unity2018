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

    public Transform redCubeToPlace;
    public Transform blueCubeToPlace;
    public Transform greenCubeToPlace;
    public Transform yellowCubeToPlace;
    public Transform tealCylinderToPlace;

    public Transform wall;
    public Transform character;
    public Light lght;

    public Transform slot0text;
    public Transform slot1text;
    public Transform slot2text;
    public Transform slot3text;

    public Transform slot0Qtext;
    public Transform slot1Qtext;
    public Transform slot2Qtext;
    public Transform slot3Qtext;

    public Transform canvasObj;
    public KeyCode toggleInventory;
    public KeyCode buttonB;
    public string inventoryStatus = "closed";
    public Vector3 cmrpos;

    public Vector3 currentSelectedTile;

    //green,red,yellow,teal(cylinder)
    public static List<string> invSlot = new List<string>()
    {
        "greenCube", "redCube", "yellowCube", "tealCube"
    };
    //green,red.yellow,teal(cylinder)
    public static List<int> invSlotQuant = new List<int>()
    {
        0,0,0,0
    };

    public int N;
    int floorSize;
    public int rand;
    public int randomCube;
    private Vector3 vctr1 = new Vector3(45, 45, 0);
    private Vector3 vctr2 = new Vector3(135, 45, 0);


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        canvasObj.GetComponent<Canvas>().enabled = false;
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
        if (Input.GetKeyDown(toggleInventory))
        {
            if (inventoryStatus == "closed")
            {
                canvasObj.GetComponent<Canvas>().enabled = true;
                inventoryStatus = "open";
            }
            else
            {
                canvasObj.GetComponent<Canvas>().enabled = false;
                inventoryStatus = "closed";
            }
        }

        if (Input.GetKeyDown(buttonB))
        {
            randomCube = Random.Range(0, 4);
            print("pressed b and got " + invSlot[randomCube]);
            if (invSlotQuant[randomCube] > 0)
            {
                cmrpos = Camera.main.transform.position + Camera.main.transform.forward * 1;
                print("camera is at " + cmrpos);
                if (invSlot[randomCube].Equals("redCube"))
                {
                    Instantiate(redCubeToPlace, new Vector3(cmrpos.x, cmrpos.y, cmrpos.z), redCubeToPlace.rotation);
                }
                else if (invSlot[randomCube].Equals("greenCube"))
                {
                    Instantiate(greenCubeToPlace, new Vector3(cmrpos.x, cmrpos.y, cmrpos.z), greenCubeToPlace.rotation);
                }
                else if (invSlot[randomCube].Equals("yellowCube"))
                {
                    Instantiate(yellowCubeToPlace, new Vector3(cmrpos.x, cmrpos.y, cmrpos.z), yellowCubeToPlace.rotation);
                }
                else if (invSlot[randomCube].Equals("tealCube"))
                {
                    Instantiate(tealCylinderToPlace, new Vector3(cmrpos.x, cmrpos.y, cmrpos.z), tealCylinderToPlace.rotation);
                }
                invSlotQuant[randomCube] -= 1;
                print("placed " + invSlot[randomCube] + " cube ");
            }
        }

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
        Instantiate(character, transform.position + transform.right * (N / 2) + transform.up * ((N / 2) + 4) + transform.forward * (N / 2), transform.rotation);
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
                        //Space for magenta cube
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

        //Create walls
        // for (int y = 0; y < N * 4; y += 4)
        //{
        //    for (int x = 0; x < N + 1; x++)
        //    {
        //        Instantiate(wall, new Vector3(x, y, -1), wall.rotation);
        //    }
        //    for (int z = 0; z < N + 1; z++)
        //   {
        //       Instantiate(wall, new Vector3(5, y, z), wall.rotation);
        //    }
        //  for (int x = 4; x > -2; x--)
        //  {
        //        Instantiate(wall, new Vector3(x, y, 5), wall.rotation);
        //   }

        //   for (int z = 4; z > -2; z--)
        //    {
        //       Instantiate(wall, new Vector3(-1, y, z), wall.rotation);
        //  }
        // }

    }


    void createEvenGrid()
    {
        Instantiate(magentaCube, new Vector3(((N / 2) - 1), 0, ((N / 2) - 1)), magentaCube.rotation);
        Instantiate(character, transform.position + transform.right * ((N / 2) - 1) + transform.up * ((N / 2) + 3) + transform.forward * ((N / 2) - 1), transform.rotation);
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


