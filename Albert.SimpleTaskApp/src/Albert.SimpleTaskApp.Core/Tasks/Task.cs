using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Albert.SimpleTaskApp.Tasks
{
    /// <summary>
    /// 任务
    /// </summary>
    [Table("AppTasks")]
    public class Task : Entity, IHasCreationTime
    {
        /// <summary>
        /// 任务标题
        /// </summary>
        [Required]
        [StringLength(SimpleTaskAppConsts.MaxTitleLength)]
        public string Title { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        [StringLength(SimpleTaskAppConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public TaskState State { get; set; }

        public Task()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
        }

        public Task(string title, string description = null) : this()
        {
            Title = title;
            Description = description;
        }
    }

    /// <summary>
    /// 任务状态类型
    /// </summary>
    public enum TaskState : byte
    {
        Open = 0,
        Completed = 1
    }
}
