using System;
using System.Collections.Generic;
using System.IO;

namespace KizhiPart1
{
    public class Interpreter
    {
        private TextWriter _writer;

        private Dictionary<string, int> variableValuePairs = new Dictionary<string, int>();

        public Interpreter(TextWriter writer)
        {
            _writer = writer;
        }

        public void ExecuteLine(string command)
        {
            var commandSplit = command.Split(' ');
            var commandName = commandSplit[0];
            var variable = commandSplit[1];
            int value = 0;
            if (commandName != "print" && commandName != "rem")
                value = int.Parse(commandSplit[2]);

            if (commandName == "set")
            {
                if (variableValuePairs.ContainsKey(variable))
                    variableValuePairs[variable] = value;
                else
                    variableValuePairs.Add(variable, value);
            }
            else if (commandName == "sub")
            {
                if (variableValuePairs.ContainsKey(variable))
                {
                    if (variableValuePairs[variable] - value > 0)
                        variableValuePairs[variable] -= value;
                    else
                        _writer.WriteLine("Числа должны быть натуральными!");
                }
                else
                    _writer.WriteLine("Переменная отсутствует в памяти");
            }
            else if (commandName == "print")
            {
                if (variableValuePairs.ContainsKey(variable))
                    _writer.WriteLine(variableValuePairs[variable].ToString());
                else
                    _writer.WriteLine("Переменная отсутствует в памяти");
            }
            else if (commandName == "rem")
            {
                if (variableValuePairs.ContainsKey(variable))
                    variableValuePairs.Remove(variable);
                else
                    _writer.WriteLine("Переменная отсутствует в памяти");
            }
            else
                _writer.WriteLine("Такой команды не существует!");
        }
    }
}