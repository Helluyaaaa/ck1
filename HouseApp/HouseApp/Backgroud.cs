using System;
using System.Collections.Generic;
using System.Text;
using Urho;
namespace HouseApp
{
    class Backgroud : Component
    {
        Node tile;
        public void Start()
        {
            tile = CreateTile();
        }
        Node CreateTile()
        {
            var cache = Application.ResourceCache;
            Node tile = Node.CreateChild();

            var backgroud = tile.CreateChild();
            backgroud.Rotate(new Quaternion(0f,60f,0f));
            backgroud.Scale = new Vector3(40f,0.01f,40f);
            backgroud.Position = new Vector3(0, -2f, 0);

            var backgroudobj = backgroud.CreateComponent<StaticModel>();
            backgroudobj.Model = cache.GetModel(Assets.Models.Backgroud);
            backgroudobj.SetMaterial(cache.GetMaterial(Assets.Materials.Grass));
            return tile;

        }
    }
}
