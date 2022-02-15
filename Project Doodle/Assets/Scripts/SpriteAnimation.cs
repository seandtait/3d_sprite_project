using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    bool animate = false;
    Unit unit;
    SpriteRenderer sr;

    public List<Sprite> sprites;

    string action;

    public int index;
    public int offset;
    public int totalFrames;
    public float movingSpeed;
    float speed;
    float speedIndex;

    bool forward;

    
    Direction savedDirection;
    Direction savedRealDirection;

    public string DefaultAction = "Idle";

    private void Start()
    {
        unit = GetComponentInParent<Unit>();
        sr = GetComponent<SpriteRenderer>();

        if (DefaultAction == "Idle")
        {
            SetIdle();
        }
        if (DefaultAction == "Moving")
        {
            SetMoving();
        }
    }

    public void SetIdle()
    {
        if (action == "Idle")
        {
            return;
        }
        animate = false;
        action = "Idle";
        
        forward = true;

        speed = 0.3f;

        index = 0;

        GetOffset();
        CollectSprites();
        sr.sprite = sprites[index];


        animate = false;
    }

    public void SetMoving()
    {
        if (action == "Running")
        {
            return;
        }

        animate = false;
        action = "Running";

        forward = true;

        speed = movingSpeed;

        index = 0;

        GetOffset();
        CollectSprites();
        sr.sprite = sprites[index];



        animate = true;
    }

    public void SetDown()
    {
        if (action == "Down")
        {
            return;
        }
        
        animate = false;
        action = "Down";

        forward = true;
        speed = 1;

        index = Random.Range(0, totalFrames) - 1;

        //UpdateFacing();

        animate = false;
    }

    void GetOffset()
    {
        int o;
        switch (unit.spriteFacing)
        {
            case Direction.NORTH:
                o = totalFrames * 3;
                break;
            case Direction.EAST:
                o = totalFrames * 2;
                break;
            case Direction.SOUTH:
                o = totalFrames * 0;
                break;
            case Direction.WEST:
                o = totalFrames * 1;
                break;
            default:
                o = 0;
                break;
        }
        offset = o;
    }

    void CollectSprites()
    {
        sprites = new List<Sprite>();
        
        for (int i = offset; i < offset + totalFrames; i++)
        {
            sprites.Add(unit.spriteSheet[i]);
        }
    }

    public void Update()
    {
        if (savedDirection != unit.spriteFacing)
        {
            savedDirection = unit.spriteFacing;
            UpdateFacing();
        }
        if (savedRealDirection != unit.facing)
        {
            savedRealDirection = unit.facing;
            UpdateFacing();
        }

        speedIndex += Time.deltaTime;
        if (animate && speedIndex >= speed)
        {
            speedIndex = 0;
            DoUpdate();
        }
    }

    void DoUpdate()
    {
        index += 1;
        ValidateIndex();
        sr.sprite = sprites[index];
    }

    public void UpdateFacing()
    {
        index = 0;
        GetOffset();
        CollectSprites();
        sr.sprite = sprites[index];
    }

    void ValidateIndex()
    {
        if (index >= totalFrames)
        {
            index = 0;
        }
    }


}
