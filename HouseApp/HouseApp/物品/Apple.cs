using System;
using System.Collections.Generic;
using System.Text;
using Urho;
namespace HouseApp.物品
{
    public class Apple:Component
    {
        Node Tile;

        public void Start()
        {
            Tile = CreateTile();
        }
        Node CreateTile()
        {
            var cache = Application.ResourceCache;
            Node tile = Node.CreateChild();

            var AppleNode = tile.CreateChild();
            AppleNode.Rotate(new Quaternion(30f, 30f, 30f), TransformSpace.Local);
            AppleNode.Scale = new Vector3(1f, 1f, 1f);

            var AppleObj = AppleNode.CreateComponent<StaticModel>();
            AppleObj.Model = cache.GetModel(Assets.Models.Apple);
            AppleObj.SetMaterial(cache.GetMaterial(Assets.Materials.House));
            AppleNode.Position=new Vector3(0,2f,0);
            return tile;
        }
    }
}
