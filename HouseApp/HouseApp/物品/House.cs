using System;
using System.Collections.Generic;
using System.Text;
using Urho;
namespace HouseApp
{
    class House:Component
    {
        Node Tile;
        
        public void start() 
        {
            Tile=CreateTile();
        }
         Node CreateTile()
        {
            var cache = Application.ResourceCache;
            Node tile = Node.CreateChild();

            var HouseNode = tile.CreateChild();
            HouseNode.Rotate(new Quaternion(0f, 200f, 0f),TransformSpace.Local);
            HouseNode.Scale = new Vector3(0.5f, 0.5f, 0.5f);

            var HouseObj = HouseNode.CreateComponent<StaticModel>();
            HouseObj.Model = cache.GetModel(Assets.Models.House);
            HouseObj.SetMaterial(cache.GetMaterial(Assets.Materials.House));

            return tile;
        }
    }
}
