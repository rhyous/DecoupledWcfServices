using System;
using System.ServiceModel.Configuration;

namespace DecoupledWcfServices.Behavior
{
    public class SampleBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType { get { return typeof(SampleBehavior); } }

        protected override object CreateBehavior() => new SampleBehavior();
    }
}