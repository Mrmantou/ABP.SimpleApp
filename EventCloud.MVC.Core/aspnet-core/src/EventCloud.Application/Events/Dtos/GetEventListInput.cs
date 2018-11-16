using System;
using System.Collections.Generic;
using System.Text;

namespace EventCloud.Events.Dtos
{
    public class GetEventListInput
    {
        public bool IncludeCanceledEvents { get; set; }
    }
}
