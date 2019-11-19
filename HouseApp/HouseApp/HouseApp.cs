using System.Diagnostics;
using System.Threading.Tasks;
using Urho;
using Urho.Gui;
using Urho.Physics;
using Urho.Actions;
using Urho.Shapes;
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
            cameraNode.Position = (new Vector3(0.0f, 0.0f, -10.0f));
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
            zone.AmbientColor = new Color(1f, 1f, 1f);


            var house = new House();
            scene.AddComponent(house);
            house.start();



        }
    }
}
