using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.support;

namespace SampleWorld.engine.components
{
    public interface ILocalComponent : IAdjustable
    {
        //更新组件状态
        void Update(GameTime gameTime);
        //获取持有组件的对象
        IGameObject GetParent();
    }
}
