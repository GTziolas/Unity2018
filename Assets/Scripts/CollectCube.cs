using UnityEngine;

public class CollectCube : MonoBehaviour
{
    public string lootMaterial;
    public int howMuchLoot = 0;
    public bool isWithinRange = false;
    public Transform dirtParticleAnimation;
    public int durability;
    public Material GreenTook1;
    public Material GreenTook2;
    public Material RedTook1;


    // Start is called before the first frame update
    void Start()
    {
        howMuchLoot = Random.Range(1, 6);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {

        if (isWithinRange == true)
        {

            durability -= 1;

            if ((durability == 2) && lootMaterial == "green")
            {
                gameObject.GetComponent<Renderer>().material = GreenTook1;
            }

            if ((durability == 1) && lootMaterial == "green")
            {
                gameObject.GetComponent<Renderer>().material = GreenTook2;
            }

            if ((durability == 1) && lootMaterial == "red")
            {
                gameObject.GetComponent<Renderer>().material = RedTook1;
            }

            if (durability == 0)
            {
                if (gameflow.invSlot[0] == "")
                {
                    gameflow.invSlot[0] = lootMaterial;
                    gameflow.invSlotQuant[0] += 1;
                }
                else if (gameflow.invSlot[1] == "")
                {
                    gameflow.invSlot[1] = lootMaterial;
                    gameflow.invSlotQuant[1] += 1;
                }
                else if (gameflow.invSlot[2] == "")
                {
                    gameflow.invSlot[2] = lootMaterial;
                    gameflow.invSlotQuant[2] += 1;
                }

                Debug.Log(gameflow.invSlot[0] + " " + gameflow.invSlot[1] + " " + gameflow.invSlot[2]
                    + " " + gameflow.invSlotQuant[0] + " " + gameflow.invSlotQuant[1] + " " + gameflow.invSlotQuant[2]);
                //Debug.Log(lootMaterial + "    " + howMuchLoot);
                Instantiate(dirtParticleAnimation, transform.position, dirtParticleAnimation.rotation);
                Destroy(gameObject);
            }

        }
        if (lootMaterial == "magenta")
        {
            print("Magenta cubes are immovable");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isWithinRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isWithinRange = false;
    }
}
