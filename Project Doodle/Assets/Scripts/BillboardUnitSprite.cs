using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUnitSprite : MonoBehaviour
{
    private static Camera cam;
    private static float cameraFacing;
    static bool updatedThisFrame = false;
    int framesPerAnimation = 3;

    private Unit unit;
    private SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponentInParent<Unit>();
        
        if (cam == null)
        {
            cam = Camera.main;
        }

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        updatedThisFrame = false;
    }

    void LateUpdate()
    {
        // Billboard
        transform.rotation = cam.transform.rotation;
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

        // Update Sprite
        if (!updatedThisFrame)
        {
            updatedThisFrame = true;
            cameraFacing = cam.transform.eulerAngles.y;
            //Debug.Log(cameraFacing);
        }

        Direction cameraDirection = GetCamDirectionFromAngle(cameraFacing);
        //Debug.Log(cameraDirection);
        GetSpriteFromFacingAndCameraFacing(unit.facing, cameraDirection);

    }

    // 0 = Front, 1 = Right,  2 = Back,     3 = Left
    // 0 degrees, 90 degrees, 180 degrees,  270 degrees
    Direction GetCamDirectionFromAngle(float angle)
    {
        if (angle >= 0 && angle < 0 + 45)
        {
            return Direction.NORTH;
        } else if (angle > 360 - 45 && angle <= 360)
        {
            return Direction.NORTH;
        }
        else if (angle > 90 - 45 && angle < 90 + 45)
        {
            return Direction.EAST;
        } else if (angle > 180 - 45 && angle < 180 + 45)
        {
            return Direction.SOUTH;
        } else
        {
            return Direction.WEST;
        }
    }

    void GetSpriteFromFacingAndCameraFacing(Direction _facing, Direction _cameraDir)
    {
        // CAM NORTH
        if (_facing == Direction.NORTH && _cameraDir == Direction.NORTH)
        {
            //sr.sprite = unit.spriteSheet[IdleNorth()];
            unit.spriteFacing = Direction.NORTH;
        }
        if (_facing == Direction.EAST && _cameraDir == Direction.NORTH)
        {
            //sr.sprite = unit.spriteSheet[IdleEast()];
            unit.spriteFacing = Direction.EAST;
        }
        if (_facing == Direction.SOUTH && _cameraDir == Direction.NORTH)
        {
            //sr.sprite = unit.spriteSheet[IdleSouth()];
            unit.spriteFacing = Direction.SOUTH;
        }
        if (_facing == Direction.WEST && _cameraDir == Direction.NORTH)
        {
            //sr.sprite = unit.spriteSheet[IdleWest()];
            unit.spriteFacing = Direction.WEST;
        }

        // CAM EAST
        if (_facing == Direction.NORTH && _cameraDir == Direction.EAST)
        {
            //sr.sprite = unit.spriteSheet[IdleWest()];
            unit.spriteFacing = Direction.WEST;
        }
        if (_facing == Direction.EAST && _cameraDir == Direction.EAST)
        {
            //sr.sprite = unit.spriteSheet[IdleNorth()];
            unit.spriteFacing = Direction.NORTH;
        }
        if (_facing == Direction.SOUTH && _cameraDir == Direction.EAST)
        {
            //sr.sprite = unit.spriteSheet[IdleEast()];
            unit.spriteFacing = Direction.EAST;
        }
        if (_facing == Direction.WEST && _cameraDir == Direction.EAST)
        {
            //sr.sprite = unit.spriteSheet[IdleSouth()];
            unit.spriteFacing = Direction.SOUTH;
        }

        // CAM SOUTH
        if (_facing == Direction.NORTH && _cameraDir == Direction.SOUTH)
        {
            //sr.sprite = unit.spriteSheet[IdleSouth()];
            unit.spriteFacing = Direction.SOUTH;
        }
        if (_facing == Direction.EAST && _cameraDir == Direction.SOUTH)
        {
            //sr.sprite = unit.spriteSheet[IdleWest()];
            unit.spriteFacing = Direction.WEST;
        }
        if (_facing == Direction.SOUTH && _cameraDir == Direction.SOUTH)
        {
            //sr.sprite = unit.spriteSheet[IdleNorth()];
            unit.spriteFacing = Direction.NORTH;
        }
        if (_facing == Direction.WEST && _cameraDir == Direction.SOUTH)
        {
            //sr.sprite = unit.spriteSheet[IdleEast()];
            unit.spriteFacing = Direction.EAST;
        }

        // CAM WEST
        if (_facing == Direction.NORTH && _cameraDir == Direction.WEST)
        {
            //sr.sprite = unit.spriteSheet[IdleEast()];
            unit.spriteFacing = Direction.EAST;
        }
        if (_facing == Direction.EAST && _cameraDir == Direction.WEST)
        {
            //sr.sprite = unit.spriteSheet[IdleSouth()];
            unit.spriteFacing = Direction.SOUTH;
        }
        if (_facing == Direction.SOUTH && _cameraDir == Direction.WEST)
        {
            //sr.sprite = unit.spriteSheet[IdleWest()];
            unit.spriteFacing = Direction.WEST;
        }
        if (_facing == Direction.WEST && _cameraDir == Direction.WEST)
        {
            //sr.sprite = unit.spriteSheet[IdleNorth()];
            unit.spriteFacing = Direction.NORTH;
        }

    }

    int IdleNorth()
    {
        return framesPerAnimation * 0 + 1;
    }

    int IdleEast()
    {
        return framesPerAnimation * 1 + 1;
    }

    int IdleSouth()
    {
        return framesPerAnimation * 2 + 1;
    }

    int IdleWest()
    {
        return framesPerAnimation * 3 + 1;
    }

}
