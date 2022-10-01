﻿using System.ComponentModel.DataAnnotations;

namespace DragaliaAPI.Models.Database.Savefile
{
    public interface IDbSavefile
    {
        /// <summary>
        /// The device account ID which identifies the owner of this information.
        /// </summary>
        public string DeviceAccountId { get; set; }
    }
}
