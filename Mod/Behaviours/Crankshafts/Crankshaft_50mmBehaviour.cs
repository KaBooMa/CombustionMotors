using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Crankshafts;

public class Crankshaft_50mmBehaviour : CrankshaftBehaviour
{
    public override float stroke_length { get; set; } = 50f;
}