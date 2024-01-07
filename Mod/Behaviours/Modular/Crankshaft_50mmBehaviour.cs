using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Modular;

public class Crankshaft_50mmBehaviour : CrankshaftBehaviourBase
{
    public override float stroke_length { get; set; } = 50f;
}