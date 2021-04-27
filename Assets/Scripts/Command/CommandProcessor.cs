using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private List<Command> _commands = new List<Command>();
    private int _currentCommandIndex;

    public void ExecuteCommand(Command command)
    {
        var count = _commands.Count;
        if (count > _currentCommandIndex + 1) 
            _commands.RemoveRange(_currentCommandIndex + 1, count - (_currentCommandIndex + 1));
        _commands.Add(command);
        _currentCommandIndex = _commands.Count - 1;
        command.Execute();
    }

    public void Undo()
    {
        Debug.Log(_currentCommandIndex);
        
        if (_currentCommandIndex < 0)
            return;

        if (_currentCommandIndex == _commands.Count)
            _currentCommandIndex--;

        _commands[_currentCommandIndex].Undo();

        _currentCommandIndex = Mathf.Max(_currentCommandIndex - 1, -1);
    }

    public void Redo()
    {
        Debug.Log(_currentCommandIndex);

        if (_currentCommandIndex >= _commands.Count - 1)
            return;

        _currentCommandIndex = Mathf.Min(_currentCommandIndex + 1, _commands.Count);

        _commands[_currentCommandIndex].Execute();
    }
}
