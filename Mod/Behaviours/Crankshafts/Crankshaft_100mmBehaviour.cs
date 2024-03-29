using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Crankshafts;

public class Crankshaft_100mmBehaviour : CrankshaftBehaviour
{
    public override float stroke_length { get; set; } = 100f;
}