using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA.GOAP
{
    public interface IInjectable
    {
        public void Inject(DependencyInjector injector);
    }
}

