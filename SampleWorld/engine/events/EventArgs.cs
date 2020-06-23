
using SampleWorld.engine.components;
using SampleWorld.engine.components.events;

namespace SampleWorld.engine.events
{
    public class EventArgs
    {
        public EventTypeEnum EventType { get; }


        public LocalComponent Other { get; }

        public EventArgs(EventTypeEnum eventType, LocalComponent other)
        {
            EventType = eventType;
            Other = other;
        }
    }
}
