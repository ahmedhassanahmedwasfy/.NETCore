using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace Target_NETCORE.DI
{
    public class UnityControllerActivator : IControllerActivator
    {
        private IUnityContainer _unityContainer;

        public UnityControllerActivator(IUnityContainer container)
        {
            _unityContainer = container;
        }

        #region Implementation of IControllerActivator

        public object Create(ControllerContext context)
        {
            return _unityContainer.Resolve(context.ActionDescriptor.ControllerTypeInfo.AsType());
        }


        public void Release(ControllerContext context, object controller)
        {
            //ignored
        }

        #endregion
    }
}
