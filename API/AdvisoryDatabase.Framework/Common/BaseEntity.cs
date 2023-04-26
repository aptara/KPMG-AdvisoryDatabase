using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Common
{
    [Serializable]
    public class BaseEntity<TId>
    {
        /// <summary>
        /// Id for the entity instance.
        /// </summary>
        /// 
        public virtual TId Id { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the entity instance was created
        /// </summary>
        /// 

        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the user id who had created the entity instance.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date/timw when the entity instance was last updated.
        /// </summary>
        public DateTime LastUpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the user id who has last updated the entity instance.
        /// </summary>
        public int LastUpdatedBy { get; set; }

        public bool IsActive { get; set; }
        /// <summary>
        /// Gets time stamp information about this entity instance
        /// </summary>
        public TimeStamp GetTimeStamp()
        {
            return new TimeStamp()
            {
                CreatedBy = this.CreatedBy,
                CreatedOn = this.CreatedOn,
                LastUpdatedBy = this.LastUpdatedBy,
                LastUpdatedOn = this.LastUpdatedOn
            };
        }
    }

    public struct TimeStamp
    {
        /// <summary>
        /// Gets or sets the date/time when the entity instance was created
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the user id who had created the entity instance.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date/timw when the entity instance was last updated.
        /// </summary>
        public DateTime LastUpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the user id who has last updated the entity instance.
        /// </summary>
        public int LastUpdatedBy { get; set; }
    }
}
