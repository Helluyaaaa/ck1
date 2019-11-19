using System;
using System.Collections.Generic;
using System.Text;
using Urho;
using System.Threading.Tasks;
using Urho.Physics;
namespace Game.Aircrafts.Weapons
{
    public abstract class Weapon:Component
    {
        bool isInited;
        public DateTime LastLaunchDate { get; set; }

        // Reload duration (between two launches)
        //武器正在重新装弹
        public virtual TimeSpan ReloadDuration => TimeSpan.FromSeconds(0.5f);
        public virtual int Damage => 1;

        
        public bool IsReloading => LastLaunchDate + ReloadDuration > DateTime.Now;

        public async Task<bool> FireAsync(bool byPlayer)
        {
            if (!isInited)
            {
                isInited = true;
                Init();
            }

            if (IsReloading)
            {
                return false;
            }
            LastLaunchDate = DateTime.Now;
            await OnFire(byPlayer);
            return true;
        }
        public virtual void OnHit(Aircraft target,bool killed,Node bulletNode)//击中时
        {
            var body = bulletNode.GetComponent<RigidBody>();
            if (body != null)
            
                body.Enabled = false;
                bulletNode.SetScale(0);
            
        }
        protected virtual void Init() { }

        protected Node CreateRigidBullet(bool byPlayer,Vector3 collisionBox)//创造子弹
        {
            var carrier = Node;
            var bullet = carrier.Scene.CreateChild(nameof(Weapon) + GetType().Name);

            var carrierPos = carrier.Position;
            bullet.Position = carrierPos;     //子弹的位置
            
            var body = bullet.CreateComponent<RigidBody>();
            CollisionShape shape=bullet.CreateComponent<CollisionShape>();
            shape.SetBox(collisionBox, Vector3.Zero, Quaternion.Identity);
            body.Kinematic = true;
            body.CollisionLayer = byPlayer ? (uint)CollisionLayers.Enemy :  
                                             (uint)CollisionLayers.Player; //物理碰撞和运动相关

            bullet.AddComponent(new WeaponReferenceComponent(this));
            return bullet;
        }

        protected Node CreateRigidBullet(bool byPlayer)
        {
            return CreateRigidBullet(byPlayer, Vector3.One);
        }

        protected abstract Task OnFire(bool byPlayer);
    }
    public class WeaponReferenceComponent : Component
    {
        public Weapon Weapon { get; set; }
        public WeaponReferenceComponent(Weapon weapon)
        {
            Weapon = weapon;
        }
    }
}
