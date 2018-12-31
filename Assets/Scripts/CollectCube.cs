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
        howMuchLoot = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {

        if (isWithinRange == true)
        {
            //green,red,yellow,teal
            durability -= 1;

            if ((durability == 2) && lootMaterial == "green")
            {
                gameObject.GetComponent<Renderer>().material = GreenTook1;
                gameflow.invSlotQuant[0] += 1;
            }

            if ((durability == 1) && lootMaterial == "green")
            {
                gameObject.GetComponent<Renderer>().material = GreenTook2;
                gameflow.invSlotQuant[0] += 1;
            }

            if ((durability == 1) && lootMaterial == "red")
            {
                gameObject.GetComponent<Renderer>().material = RedTook1;
                gameflow.invSlotQuant[1] += 1;
            }

            if ((durability == 0) && lootMaterial == "green")
            {

                gameflow.invSlotQuant[0] += 1;
            }

            if ((durability == 0) && lootMaterial == "red")
            {

                gameflow.invSlotQuant[1] += 1;
            }
            if ((durability == 0) && lootMaterial == "yellow")
            {

                gameflow.invSlotQuant[2] += 1;
            }

            if ((durability == 0) && lootMaterial == "teal")
            {

                gameflow.invSlotQuant[3] += 1;
            }

            if (durability == 0 && lootMaterial != "blue")
            {

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
        if (lootMaterial == "blue")
        {
            doNothingOnBlue();
            Destroy(gameObject);
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

    void doNothingOnBlue()
    {
        print("Blue has 0 mini cubes in it");
    }
}
