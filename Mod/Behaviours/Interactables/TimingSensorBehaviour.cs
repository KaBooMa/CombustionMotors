using CombustionMotors.Behaviours.Bases;

namespace CombustionMotors.Behaviours.Interactables;

public class TimingSensorBehaviour : CrankshaftBehaviourBase
{
    public override float stroke_length { get; set; } = 300f;
}