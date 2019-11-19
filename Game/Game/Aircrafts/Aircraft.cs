using System;
using System.Collections.Generic;
using System.Text;
using Urho;
using System.Threading.Tasks;
using Urho.Physics;
using Urho.Audio;
using Urho.Actions;
using Urho.Urho2D;
using Game.Aircrafts.Weapons;
namespace Game.Aircrafts
{
    public class Aircraft:Component
    {
        TaskCompletionSource<bool> liveTask;

        protected virtual Vector3 CollisionShapeSize => new Vector3(1.2f, 1.2f, 1.2f);

        protected virtual CollisionLayers CollisionLayer => CollisionLayers.Enemy;


        protected Aircraft()
        {
            ReceiveSceneUpdates = true; //接受场景更新
        }

        public int health { get; set; }
        public virtual int MaxHealth => 30;
        public bool IsAlive => health > 0 && Enabled && !IsDeleted;
        public Task Play()
        {
            liveTask = new TaskCompletionSource<bool>();
            health = MaxHealth;
            //下面是有关物理效果和碰撞（collision）的代码
            var node = Node;
            var body = node.CreateComponent<RigidBody>();

            body.Mass = 1;
            body.Kinematic = true;
            body.CollisionMask = (uint)CollisionLayer;
            CollisionShape shape = node.CreateComponent<CollisionShape>();
            shape.SetBox(CollisionShapeSize, Vector3.Zero, Quaternion.Identity);

            Init();
            node.SubscribeToNodeCollisionStart(OnCollided);
            return liveTask.Task;
        }

        //飞机爆炸的动画
        public async Task Explode()
        {
            health = 0;
            //在场景中创建用于爆炸的特殊独立节点
            var explosionNode = Scene.CreateChild();
            SoundSource soundSource = explosionNode.CreateComponent<SoundSource>();
            soundSource.Play(Application.ResourceCache.GetSound(Assets.Sounds.BigExplosion));
            soundSource.Gain = 0.5f;

            explosionNode.Position = Node.WorldPosition;
            OnExplode(explosionNode);
            var scaleAction = new ScaleTo(1f, 0f);       //Scale是比例尺
            Node.RemoveAllActions();
            Node.Enabled = false;
            await explosionNode.RunActionsAsync(scaleAction, new DelayTime(1f));
            liveTask.TrySetResult(true);
            explosionNode.Remove();

        }
        void OnCollided(NodeCollisionStartEventArgs args)//碰撞触发的方法
        {
            var bulletNode = args.OtherNode;
            if(IsAlive&&bulletNode.Name!=null&&bulletNode.Name.StartsWith(nameof(Weapon))&&
                args.Body.Node==Node)
            {
                var weapon = bulletNode.GetComponent<WeaponReferenceComponent>().Weapon;//这是武器
                health -= weapon.Damage;
                var killed = health <= 0;
                if (killed)
                {
                    Explode();
                }
                else if (weapon.Damage > 0)
                {
                    Hit();
                }
                weapon.OnHit(target: this, killed: killed, bulletNode: bulletNode);

            }

        }
        async void Hit() 
        {
            var material = Node.GetComponent<StaticModel>().GetMaterial();
            if (material == null)
                return;
            material.SetShaderParameter("MatSpecColor", new Color(0, 0, 0, 0));
            var specColorAnimation = new ValueAnimation();
            specColorAnimation.SetKeyFrame(0.0f, new Color(1.0f, 1.0f, 1.0f, 0.5f));
            specColorAnimation.SetKeyFrame(0.1f, new Color(0, 0, 0, 0));
            material.SetShaderParameterAnimation("MatSpecColor", specColorAnimation, WrapMode.Once, 1.0f);
            await Node.RunActionsAsync(new DelayTime(1f));

        }
        protected virtual void OnExplode(Node explodeNode)//这个是爆炸中的粒子效果
        {
            explodeNode.SetScale(2f);
            var particleEmitter = explodeNode.CreateComponent<ParticleEmitter2D>();
            particleEmitter.Effect = Application.ResourceCache.GetParticleEffect2D(Assets.Particles.Explosion);

        }
        protected virtual void Init()
        {

        }
        

    }
    public enum CollisionLayers : uint
    {
        Player = 2,
        Enemy = 4
    }


}
