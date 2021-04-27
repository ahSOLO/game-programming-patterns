using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCommand : Command
{
    private readonly float _scaleFactor;

    public ScaleCommand(IEntity entity, float scaleDir) : base(entity)
    {
        this._scaleFactor = scaleDir == 1f ? 1.1f : 0.9f;
    }

    public override void Execute()
    {
        _entity.transform.localScale *= _scaleFactor;
    }

    public override void Undo()
    {
        _entity.transform.localScale /= _scaleFactor;
    }
}
