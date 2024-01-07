using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Modular;

public class Crankshaft_60mmBehaviour : CrankshaftBehaviourBase
{
    public override float stroke_length { get; set; } = 60f;
}