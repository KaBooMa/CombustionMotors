using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Crankshafts;

public class Crankshaft_90mmBehaviour : CrankshaftBehaviourBase
{
    public override float stroke_length { get; set; } = 90f;
}