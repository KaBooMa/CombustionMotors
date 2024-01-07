using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Modular;

public class Crankshaft_100mmBehaviour : CrankshaftBehaviourBase
{
    public override float stroke_length { get; set; } = 100f;
}