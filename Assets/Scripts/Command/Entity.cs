using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    private InputReader _inputReader;
    private CommandProcessor _commandProcessor;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = _inputReader.ReadInput();
        if (dir != Vector3.zero)
        {
            var moveCommand = new MoveCommand(this, dir);
            _commandProcessor.ExecuteCommand(moveCommand);
        }
        else if (_inputReader.ReadUndo())
        {
            _commandProcessor.Undo();
        }
        else if (_inputReader.ReadRedo())
        {
            _commandProcessor.Redo();
        }

        float scaleDir = _inputReader.ReadScale();

        if (scaleDir != 0f)
            _commandProcessor.ExecuteCommand(new ScaleCommand(this, scaleDir));
    }
}
