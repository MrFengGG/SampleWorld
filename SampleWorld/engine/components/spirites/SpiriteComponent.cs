using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components.spirites
{
    public class SpiriteComponent : LocalComponent
    {
        public SpiriteComponent(IGameObject gameObject) : base(gameObject)
        {
        }
    }
}
