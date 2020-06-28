using Microsoft.Xna.Framework;
using SampleWorld.engine.events;
using SampleWorld.engine.support;

namespace SampleWorld.engine.components
{
    public interface ILocalComponent : IAdjustable
    {
        //更新组件状态
        void Update(GameTime gameTime);

        void OnEvent(EventArgs eventArgs);

        void Initlize();
    }
}
