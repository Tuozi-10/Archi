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

        private bool _enabled = true;

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


        protected void Init(Entity entity, bool enableValue = true)
        {
            _entity = entity;
            Enabled = enableValue; 
        }

        public void TryUpdate()
        {
            
            if(Enabled == false) return;
            Update();
            return ;
        }
        
        protected virtual void Update()
        {

        }
   
    }
}