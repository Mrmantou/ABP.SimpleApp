using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.SimpleTaskApp.Tasks.Dtos
{
    public class GetAllTasksInput
    {
        public TaskState? State { get; set; }
    }
}
