using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{

    Arrow equippedArrow;
    public Transform weaponHold;
    public Arrow startingArrow;
    public bool canShoot = true;

    void Start()
    {
        if (startingArrow != null)
        {
            equipArrow(startingArrow);
        }
    }

    public void equipArrow(Arrow arrowToEquip)
    {
        if (equippedArrow != null)
        {
            Destroy(equippedArrow.gameObject);
        }

        equippedArrow = Instantiate(arrowToEquip, weaponHold.position, weaponHold.rotation) as Arrow;
        //  equippedArrow.transform.parent = weaponHold;

    }
    public void Shoot()
    {

        if (equippedArrow != null)
        {

        }
    }
}
