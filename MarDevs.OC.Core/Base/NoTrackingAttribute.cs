using System;
using System.Collections.Generic;
using System.Text;

namespace MarDevs.OC.Core
{
    /// <summary>
    /// Especifica que una propiedad no debe incluirse en la determinación de cambios de un objeto
    /// </summary>
    public class NoTrackingAttribute: Attribute
    {
    }
}
