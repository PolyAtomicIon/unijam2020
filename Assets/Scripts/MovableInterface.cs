using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovableInterface
{

    void set_movement_data(player a, float b);

    void Freeze_position();

    void reFreeze_position();

    void reset_pushable();

    void in_range(bool a);

    bool is_pushable();

}
