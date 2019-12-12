using System.Diagnostics;
using System.Threading.Tasks;
using Urho;
using Urho.Gui;
using Urho.Physics;
using Urho.Actions;
using Urho.Shapes;
using HouseApp.物品;
using System.IO;

namespace HouseApp
{
    public class Houseapp:Application
    {
        [Preserve]
        public Houseapp() :base(new ApplicationOptions(assetsFolder: "Data") 
        { Height=1024,Width=578,Orientation=ApplicationOptions.OrientationType.Portrait})
        { }

        [Preserve]
        public Houseapp(ApplicationOptions opts) : base(opts) { }

        public Viewport Viewport { get; private set; }
        
        protected override void Start()
        {
            base.Start();
            CreateScence();
        }

        public void CreateScence()
        {
            Scene scene = new Scene();
            scene.CreateComponent<Octree>();

            //camera
            var cameraNode = scene.CreateChild();
            cameraNode.Position = (new Vector3(0.0f, 0.0f, -8.0f));
            cameraNode.SetDirection(new Vector3(0.1f, 0f, 900f));
            /*string filepath = "D:\\dir.txt";
            var dir =  cameraNode.Direction;
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
                File.WriteAllText(filepath, "X:" + dir.X.ToString() + "Y:" + dir.Y.ToString() + "Z:" + dir.Z.ToString() + "\n");
            }
            else
            {
                File.AppendAllText(filepath, "X:" + dir.X.ToString() + "Y:" + dir.Y.ToString() + "Z:" + dir.Z.ToString() + "\n");
            }*/
            cameraNode.CreateComponent<Camera>();
            Viewport = new Viewport(Context, scene, cameraNode.GetComponent<Camera>(), null);
            if (Platform != Platforms.Android && Platform != Platforms.iOS)
            {
                RenderPath effectRenderPath = Viewport.RenderPath.Clone();
                var fxaaRp = ResourceCache.GetXmlFile(Assets.PostProcess.FXAA3);
                effectRenderPath.Append(fxaaRp);
                Viewport.RenderPath = effectRenderPath;
            }
            Renderer.SetViewport(0, Viewport);

            
            //zone construct- 构造分区
            var zoneNode = scene.CreateChild();
            var zone = zoneNode.CreateComponent<Zone>();
            zone.SetBoundingBox(new BoundingBox(-300.0f, 300.0f));
            zone.AmbientColor = new Color(1, 1, 1);

            //生成背景
            var backgroud = new Backgroud();
            scene.AddComponent(backgroud);
            backgroud.Start();
            //生成house
            var house = new House();
            scene.AddComponent(house);
            house.Start();
            //生成Apple
            var apple = new Apple();
            scene.AddComponent(apple);
            apple.Start();
            


        }
    }
}
