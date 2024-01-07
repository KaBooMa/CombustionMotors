using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Modular;

public class Crankshaft_80mmBehaviour : CrankshaftBehaviourBase
{
    public override float stroke_length { get; set; } = 80f;
}