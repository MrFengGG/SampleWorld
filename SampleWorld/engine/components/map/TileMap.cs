
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.components.physic;
using SampleWorld.engine.respurces;
using System;
using System.Collections.Generic;
using TiledSharp;

namespace SampleWorld.engine.components.map
{
    public class TileMap
    {
        Texture2D[] tileArray;

        TmxMap tmxMap;

        World world;

        int[] tileWidthArray;
        int[] tileHeightArray;
        int[] tilesetTilesWideArray;
        int[] tilesetTilesHighArray;

        int layerCount;

        List<Collider> colliders = new List<Collider>(); 

        public TileMap(string tmxFile, World world)
        {
            this.world = world;
            tmxMap = new TmxMap(tmxFile);
            layerCount = tmxMap.Layers.Count;

            tileArray = new Texture2D[layerCount];
            tileWidthArray = new int[layerCount];
            tileHeightArray = new int[layerCount];
            tilesetTilesWideArray = new int[layerCount];
            tilesetTilesHighArray = new int[layerCount];
            for (int i = 0; i < layerCount; i++)
            {
                string textureName = tmxMap.Tilesets[0].Name.ToString();
                tileArray[i] = ResourceLoader.LoadTexture2D(world.GraphicsDevice, textureName, "Content/" + textureName + ".png");
                tileWidthArray[i] = tmxMap.Tilesets[0].TileWidth;
                tileHeightArray[i] = tmxMap.Tilesets[0].TileHeight;

                tilesetTilesWideArray[i] = tileArray[0].Width / tileWidthArray[i];
                tilesetTilesHighArray[i] = tileArray[0].Height / tileHeightArray[i];
            }

            TmxList<TmxObjectGroup> groups = tmxMap.ObjectGroups;
            foreach(TmxObjectGroup group in groups)
            {
                if(group.Name == "collisions")
                {
                    TmxList<TmxObject> tmxObjects = group.Objects;
                    foreach(TmxObject tmxObject in tmxObjects)
                    {
                        Collider collider = new SampleCollider(new Rectangle((int)tmxObject.X, (int)tmxObject.Y, (int)tmxObject.Width, (int)tmxObject.Height));
                        colliders.Add(collider);
                    }
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            for(var i = 0; i < layerCount; i++)
            {
                TmxLayer layer = tmxMap.Layers[i];
                float depth = 1f - 0.1f * i;
                for (var j = 0; j < layer.Tiles.Count; j++)
                {
                    int gid = layer.Tiles[j].Gid;
                    if (gid != 0)
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWideArray[i];
                        int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWideArray[i]);

                        float x = (j % tmxMap.Width) * tmxMap.TileWidth;
                        float y = (float)Math.Floor(j / (double)tmxMap.Width) * tmxMap.TileHeight;

                        Rectangle tilesetRec = new Rectangle(tileWidthArray[i] * column, tileHeightArray[i] * row, tileWidthArray[i], tileHeightArray[i]);

                        world.SpriteBatch.Draw(tileArray[i], new Rectangle((int)x, (int)y, tileWidthArray[i], tileHeightArray[i]), tilesetRec, Color.White, 0, new Vector2(1,1), SpriteEffects.None, depth);
                    }
                }
            }
        }

        public bool DetectionMove(ColliderComponent component, ref Vector2 moveDelta)
        {

            foreach (Collider collider in colliders)
            {
                if (component.Collider.IsRigid)
                {
                    if (component.Collider.Detection(collider, ref moveDelta))
                    {
                        return true;
                    }
                }
                else
                {
                    if (component.Collider.Detection(collider))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
