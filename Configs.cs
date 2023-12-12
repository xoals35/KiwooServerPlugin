using Exiled.API.Interfaces;
using Exiled.Events;

namespace PeutiPlugin
{
    public class Configs : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
    }
}