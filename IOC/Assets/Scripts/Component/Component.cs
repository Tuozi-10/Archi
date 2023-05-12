using UnityEngine;

namespace  Components
{
    public abstract class Component
    {
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                if (value)
                {
                    Enable();
                }
                else
                {
                    Disable();
                }
                
            }
        }

        private bool _enabled;

        protected virtual void Enable()
        {
            
        }

        protected virtual void Disable()
        {
            
        }
        protected Entity _entity;
        protected Component()
        {
          
        }

    

        public virtual void Init(Entity entity, params object[] args)
        {
            _entity = entity;
        }

        public  bool TryUpdate()
        {
            if(!Enabled) return false;
            Update();
            return true;
        }
        
        protected virtual void Update()
        {
           
        }
   
    }
}