using GearLib.API;
using GearLib.API.Fields;

namespace CombustionMotors.Behaviours.Heads;

public class HeadBehaviour : Behaviour
{
    public bool has_fired = false;
    public int stroke = 1;

    [IntField(label = "Timing", tooltip_text = "Offset degrees from TDC to fire piston", initial_value = 5, minimum_value = -30, maximum_value = 30)]
    public int timing;

    [IntField(label = "Offset", tooltip_text = "Offsets the TDC for the piston", initial_value = 0, minimum_value = 0, maximum_value = 360)]
    public int offset;
}