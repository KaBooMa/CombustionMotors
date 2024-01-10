using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Crankshafts;

public class Crankshaft_300mmBehaviour : CrankshaftBehaviourBase
{
    public override float stroke_length { get; set; } = 300f;
}