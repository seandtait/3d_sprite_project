using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Direction facing; // Actual facing in the world.
    public Direction spriteFacing; // False direction based on the camera facing.
    public Sprite[] spriteSheet;

}
